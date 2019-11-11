using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient
{
    public class ClientController
    {
        private ClientModel itsModel;
        private ClientState itsState;
        private List<Observer> registry;
        public LoginHandler loginHangler { get; }
        public PlaceBidHandler placeBidHandler { get; }

        public ClientController(ClientModel model)
        {
            itsModel = model;
            registry = new List<Observer>();
            itsState = ClientState.UNAUTENTIZED;
            loginHangler = new LoginHandler(this.loginHangler);
            placeBidHandler = new PlaceBidHandler(this.placeBidHandler);
        }

        public void registerObserver(Observer observer)
        {
            registry.Add(observer);
        }
    }
}
