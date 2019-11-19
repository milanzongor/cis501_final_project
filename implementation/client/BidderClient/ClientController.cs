using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidderClient.Proxy;
using BidderClient.Shared;

namespace BidderClient
{
    public class ClientController
    {
        private ClientModel itsModel;
        private ClientState itsState;
        private List<ClientObserver> registry;
        public LoginHandler loginHandler { get; }
        public PlaceBidHandler placeBidHandler { get; }
        public ProductListViewHandler productListViewHandler { get; }
        private ServerProxy serverProxy;

        public ClientController(ClientModel model)
        {
            this.itsModel = model;
            this.itsState = ClientState.UNAUTENTIZED;
            this.loginHandler = new LoginHandler(this.tryToAutentize);
            this.placeBidHandler = new PlaceBidHandler(this.bidProduct);
            this.productListViewHandler = new ProductListViewHandler(this.showSelectedProduct);
            this.registry = new List<ClientObserver>();
            this.serverProxy = new ServerProxy();
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
            User autentizedUser = serverProxy.autentizate(new Credentials(name, password));
            bool wasLoginSuccessful = autentizedUser != null;
            if (wasLoginSuccessful)
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
            Product product = this.itsModel.productsInventory[productID];
            if( price > product.currentHighestBid.value)
            {
                setState(ClientState.BID_PLACED_OK);
                setState(ClientState.PRODUCT_SELECTED);
            }
            else
            {
                setState(ClientState.BID_REJECTED);
                setState(ClientState.PRODUCT_SELECTED);
            }
        }

        private void showSelectedProduct(int productID)
        {
            setState(ClientState.PRODUCT_SELECTED);
        }

        private void updateProductList(List<Shared.Product> productsInventory)
        {

        }

        private void setAutentizedUser(Shared.User user)
        {

        }
    }
}
