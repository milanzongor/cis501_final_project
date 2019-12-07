using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidderClient.Proxy;
using BidderClient.Shared;
using BidderClient.Shared.Communication;
using System.Windows.Forms;

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
            this.serverProxy = new ServerProxy(this);
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
                setAutentizedUser(autentizedUser);
                setState(ClientState.AUTENTIZED_SUCCESSFULLY);
                setState(ClientState.ALL_PRODUCTS_OFFERED);
            }
            else
            {
                setState(ClientState.AUTENTIZATION_FAILED);
                setState(ClientState.UNAUTENTIZED);
            }
        }

        private bool validateBid(int productID, double price)
        {
            Product product = this.itsModel.productsInventory[productID];
            if (product.currentHighestBid == null)
            {
                return price > product.item.startingBidPrice;
            }
            else
            {
                return price > product.currentHighestBid.value;
            }
        }

        private void bidProduct(int productID, double price)
        {
            if (validateBid(productID, price))
            {
                bool wasBidPlaced = serverProxy.bidProduct(productID, price, itsModel.loggedUser);
                if (wasBidPlaced)
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

        public void updateProductList(Dictionary<int, Product> productsInventory)
        {
            this.itsModel.productsInventory = productsInventory;
            if(this.itsState == ClientState.PRODUCT_SELECTED)
            {
                notifyObservers();
            }
        }

        private void setAutentizedUser(Shared.User user)
        {
            this.itsModel.loggedUser = user;
        }

        public void productAuctionResultMessage(ProductAuctionResultWrapper result)
        {
            string didYouWin;
            if (result.didYouWin)
            {
                didYouWin = "You won";
            }
            else
            {
                didYouWin = "You lost";
            }

            MessageBox.Show(didYouWin + " on product " + result.product.item.name);
        }
    }
}
