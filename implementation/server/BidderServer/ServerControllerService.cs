using BidderClient.Shared;
using BidderClient.Shared.Communication;
using BidderServer.MVC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace BidderServer
{
    public class ServerControllerService : WebSocketBehavior, ServerAPI
    {
        private ServerController serverController;

        public ServerControllerService(ServerController serverController)
        {
            this.serverController = serverController;
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            this.serverController.lastConnectedControllerService = this;
            // this.Log.Level = LogLevel.Debug;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Client says: " + e.Data);
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(e.Data);
            if (!credentials.userName.IsNullOrEmpty() && !credentials.userName.IsNullOrEmpty())
            {
                // authentization message came
                Console.WriteLine("Authentization message came");
                User autentizedUser = autentizate(credentials);
                bool wasAutentized = autentizedUser != null;
                DidUserAutentizeWrapper didUserAutentizeWrapper = new DidUserAutentizeWrapper(wasAutentized, wasAutentized ? autentizedUser : new User(0, credentials));
                Console.WriteLine("Client " + credentials.userName + " has tried to autentizate");
                Console.WriteLine("Result " + (wasAutentized ? "Succeeded" : "Failed"));
                Sessions.SendTo(JsonConvert.SerializeObject(didUserAutentizeWrapper), this.ID); // notify client
            }
            else
            {
                // bid product message must have come
                Console.WriteLine("Bidding message came");
                BidProductParamsWrapper bidProductParams = JsonConvert.DeserializeObject<BidProductParamsWrapper>(e.Data);
                if (bidProductParams.hasValidValues())
                {
                    bool wasSuccessful = bidProduct(
                        bidProductParams.productID, bidProductParams.bidValue, bidProductParams.bidder
                    );
                    Sessions.SendTo(JsonConvert.SerializeObject(new WasBidPlacedWrapper(wasSuccessful)), this.ID); // notify client
                }
                else
                {
                    throw new Exception("Unknown message came from the client");
                }
            }
        }

        public User autentizate(Credentials credentials)
        {
            User user = serverController.autentizate(credentials);
            if (user != null)
            {
                user.sessionID = this.ID;
            }
            return user;
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            return serverController.bidProduct(productID, bidValue, bidder);
        }

        public WebSocketSessionManager getAllServerSocketSessions()
        {
            return this.Sessions;
        }
    }
}
