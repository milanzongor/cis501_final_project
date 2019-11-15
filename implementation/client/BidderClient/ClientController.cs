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
        private List<ClientObserver> registry;
        public LoginHandler loginHandler { get; }
        public PlaceBidHandler placeBidHandler { get; }

        public ClientController(ClientModel model)
        {
            this.itsModel = model;
            this.itsState = ClientState.UNAUTENTIZED;
            this.loginHandler = this.loginHandler; // here will be a mistake
            this.placeBidHandler = this.placeBidHandler;
            this.registry = new List<ClientObserver>();
        }

        public void registerObserver(ClientObserver observer)
        {
            registry.Add(observer);
        }

        public void notifyObservers()
        {
            foreach (ClientObserver observer in registry)
            {
                observer(itsState); // equals to update(newState) call
            }
        }

        /* based on state transitions of Controller State Diagram */
        private void setState(ClientState state)
        {
            itsState = state;
            notifyObservers();
        }

        private bool tryToAutentize(string name, string password)
        {
            return true;
        }

        private void validateBid(int productID, double price)
        {
            
        }

        private bool bidProduct(int productID, double price)
        {
            return true;
        }

        private void updateProductList(List<Shared.Product> productsInventory)
        {

        }

        private void setAutentizedUser(Shared.User user)
        {

        }
    }
}
