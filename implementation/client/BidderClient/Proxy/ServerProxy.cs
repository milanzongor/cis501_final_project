using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidderClient.Shared;
using BidderClient.Shared.Communication;
using Newtonsoft.Json;
using WebSocketSharp;

namespace BidderClient.Proxy
{
    public class ServerProxy : ServerAPI
    {
        private WebSocket webSocketToRealServer;
        private Dictionary<int, Product> productsInventory;
        private static string REAL_SERVER_URL = "ws://127.0.0.1:80/bidder";

        public ServerProxy()
        {
            this.productsInventory = new Dictionary<int, Product>();

            this.webSocketToRealServer = new WebSocket(REAL_SERVER_URL);
            this.webSocketToRealServer.OnMessage += (sender, e) =>
                Console.WriteLine("Server says: " + e.Data);
            this.webSocketToRealServer.Connect();
        }

        ~ServerProxy()
        {
            this.webSocketToRealServer.Close();
        }

        public bool autentizate(Credentials credentials)
        {
            if (webSocketToRealServer.IsAlive)
            {
                webSocketToRealServer.Send(JsonConvert.SerializeObject(credentials));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            if (webSocketToRealServer.IsAlive)
            {
                webSocketToRealServer.Send(JsonConvert.SerializeObject(
                    new BidProductParamsWrapper(productID, bidValue, bidder))
                );
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, Product> getUpToDateProductsInventory()
        {
            return productsInventory;
        } 
    }
}
