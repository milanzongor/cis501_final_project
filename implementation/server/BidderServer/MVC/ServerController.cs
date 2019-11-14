using BidderClient.Shared;
using BidderServer.Config;
using BidderServer.Proxy;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ProductsFormClosedHandler productsFormClosedHandler { get; }

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
            this.productsFormClosedHandler = this.handleProductFormClosed;

            fillProductInventoryFromStartupConfiguration();
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

        private int getHighestID()
        {
            int highestID = 0;

            foreach(var entry in this.itsModel.productsInventory)
            {
                if (entry.Key > highestID)
                {
                    highestID = entry.Key;
                }
            }

            return highestID;
        }

        private bool isDuplicateInDB(string productName)
        {
            foreach (var entry in this.itsModel.productsInventory)
            {
                if (entry.Value.item.name.Equals(productName))
                {
                    return true;
                }
            }
            return false;
        }

        private void handleAddProduct(string productName, double productStartingPrice)
        {
            if (!isDuplicateInDB(productName))
            { 
                int highestProductID = getHighestID();
                Item newItem = new Item(productName, productStartingPrice);
                Product newProduct = new Product(highestProductID + 1, newItem, ProductStatus.DISABLED);

                this.itsModel.productsInventory.Add(highestProductID + 1, newProduct);
                notifyObservers();
            }
        }
        private void handleRemoveProduct(int productID)
        {
            this.itsModel.productsInventory.Remove(productID);
            notifyObservers();
        }
        private void handleModifyProduct(int productID, string newProductName, double newProductStartingPrice)
        {

        }
        private void handleStartProductAuction(int productID)
        {
            Product product;
            this.itsModel.productsInventory.TryGetValue(productID, out product);
            if (product != null)
            {
                product.productStatus = ProductStatus.ACTIVE;
            }
            notifyObservers();
        }
        private void handleStopProductAuction(int productID)
        {
            Product product;
            this.itsModel.productsInventory.TryGetValue(productID, out product);
            if (product != null)
            {
                product.productStatus = ProductStatus.DISABLED;
            }
            notifyObservers();
        }

        private void handleProductFormClosed()
        {
            setState(ServerState.MONITORING_STATE);
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
            Dictionary<int, Product> productsInventory = new Dictionary<int, Product>();
            using (var reader = new StringReader(Properties.Resources.products_config))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<CSVProductEntry>();
                List<CSVProductEntry> productsList = records.ToList();

                foreach (CSVProductEntry productEntry in productsList)
                {
                    ProductStatus productStatus;
                    if (productEntry.status.Equals("active"))
                    {
                        productStatus = ProductStatus.ACTIVE;
                    } else
                    {
                        productStatus = ProductStatus.DISABLED;
                    }
                    Item item = new Item(productEntry.productName, productEntry.startingBidPrice);
                    Product product = new Product(productEntry.productID, item, productStatus);
                    productsInventory.Add(product.productID, product);
                }
            }

            this.itsModel.productsInventory = productsInventory;
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
