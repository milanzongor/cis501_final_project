using BidderClient.Shared;
using BidderServer.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using WebSocketSharp;

namespace BidderServer.MVC
{
    public class ServerController : ServerAPI
    {
        private ServerModel itsModel;
        private ServerState itsState;
        private List<ServerObserver> registry;
        public ManageProductsHandler manageProductsHandler { get; }
        public AddProductHandler addProductHandler { get; }
        public RemoveProductHandler removeProductHandler { get; }
        public ModifyProductHandler modifyProductHandler { get; }
        public StartProductAuctionHandler startProductAuctionHandler { get; }
        public StopProductAuctionHandler stopProductAuctionHandler { get; }

        public ServerController(ServerModel model)
        {
            this.itsModel = model;
            this.itsState = ServerState.MONITORING_STATE;
            this.registry = new List<ServerObserver>();
            this.manageProductsHandler = this.handleManageProductsButton;
            this.addProductHandler = this.handleAddProduct;
            this.removeProductHandler = this.handleRemoveProduct;
            this.modifyProductHandler = this.modifyProductHandler;
            this.startProductAuctionHandler = this.handleStartProductAuction;
            this.stopProductAuctionHandler = this.handleStopProductAuction;
        }

        public void registerObserver(ServerObserver observer)
        {
            registry.Add(observer);
        }
        private void notifyObservers()
        {
            foreach (ServerObserver observer in registry)
            {
                observer(itsState);
            }
        }
        private void setState(ServerState newState)
        {
            this.itsState = newState;
            notifyObservers();
        }

        private void handleManageProductsButton()
        {
            setState(ServerState.MANAGING_PRODUCTS);
        }
        private void handleAddProduct(Product product)
        {

        }
        private void handleRemoveProduct(int productID)
        {

        }
        private void handleModifyProduct(Product product)
        {

        }
        private void handleStartProductAuction(int productID)
        {

        }
        private void handleStopProductAuction(int productID)
        {

        }

        public bool autentizate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            throw new NotImplementedException();
        }

        private void fillProductInventoryFromStartupConfiguration()
        {

        }
        private bool validateBid(Bid bid)
        {
            throw new NotImplementedException();
        }

        void getClientsSocket(string userID) // TODO WebSocketSharp
        {
            throw new NotImplementedException();
        }
        void notifyAllClientsAboutProductChange(List<Product> updatedProductsInventory)
        {

        }
    }
}
