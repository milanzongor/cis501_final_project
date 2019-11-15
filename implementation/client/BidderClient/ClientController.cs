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
            this.loginHandler = new LoginHandler(this.tryToAutentize);
            this.placeBidHandler = new PlaceBidHandler(this.bidProduct);
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
            this.itsState = state;
            notifyObservers();
        }

        private void tryToAutentize(string name, string password)
        {
            bool returnedValue = true; // will be changed to return value of proxy
            if (returnedValue)
            {
                setState(ClientState.AUTENTIZED_SUCCESSFULLY);
                setState(ClientState.ALL_PRODUCTS_OFFERED);
            }
            else
            {
                setState(ClientState.AUTENTIZATION_FAILED);
                setState(ClientState.UNAUTENTIZED);
            }
        }

        private void validateBid(int productID, double price)
        {
            
        }

        private void bidProduct(int productID, double price)
        {

        }

        private void updateProductList(List<Shared.Product> productsInventory)
        {

        }

        private void setAutentizedUser(Shared.User user)
        {

        }
    }
}
