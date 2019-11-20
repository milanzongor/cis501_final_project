using BidderClient.Shared;
using BidderClient.Shared.Communication;
using BidderServer.Config;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

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
            this.modifyProductHandler = this.handleModifyProduct;
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
                    }
                    else
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

        private void handleManageProductsButton()
        {
            setState(ServerState.MANAGING_PRODUCTS);
        }

        private int getHighestProductID()
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
                int highestProductID = getHighestProductID();
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
            if (!isDuplicateInDB(newProductName))
            {
                Product productToModify = this.itsModel.productsInventory[productID];
                productToModify.item.name = newProductName;
                productToModify.item.startingBidPrice = newProductStartingPrice;
                notifyObservers();
            }
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

        private int getUserIDFromDB(string userName)
        {
            lock(this) { 
                foreach (var entry in this.itsModel.connectedUsers)
                {
                    if (entry.Value.credentials.userName.Equals(userName))
                    {
                        return entry.Key;
                    }
                }
                return -1;
            }
        }

        private int getHighestUserID()
        {
            lock (this)
            {
                int highestID = 0;

                foreach (var entry in this.itsModel.connectedUsers)
                {
                    if (entry.Key > highestID)
                    {
                        highestID = entry.Key;
                    }
                }

                return highestID;
            }
        }

        public User autentizate(Credentials credentials)
        {
            int userID = getUserIDFromDB(credentials.userName); // thread safe

            if (userID != -1)
            {
                User foundUser;
                lock (this) { 
                    foundUser = this.itsModel.connectedUsers[userID];
                }
                if (foundUser.credentials.Equals(credentials))
                {
                    return foundUser;
                } else
                {
                    return null;
                }
            } else
            {
                // new user, add him with entered password
                userID = getHighestUserID() + 1; // thread safe
                User newUser = new User(userID, credentials);
                lock (this) { 
                    this.itsModel.connectedUsers.Add(userID, newUser);
                    notifyObservers();
                }
                return newUser;
            }
        }

        private bool isValidBid(int productID, Bid bid)
        {
            lock(this) {
                Product product = this.itsModel.productsInventory[productID];
                if (product.productStatus != ProductStatus.ACTIVE ||
                    product.sellingStatus != SellingStatus.UNTAKEN ||
                    bid.value < product.item.startingBidPrice
                    )
                {
                    return false;
                }
                
                Bid currentHighestBid = product.currentHighestBid;
                if (currentHighestBid == null)
                {
                    return true;
                } else
                {
                    return bid.value > currentHighestBid.value && bid.timestamp > currentHighestBid.timestamp;
                }
            }
        }
        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            Bid bid = new Bid(bidder, bidValue, DateTime.Now);
            if (isValidBid(productID, bid)) // thread-safe
            {
                lock (this) { 
                    Product product = this.itsModel.productsInventory[productID];
                    product.numberOfBids++;
                    product.currentHighestBid = bid;
                    notifyObservers(); ;                  
                }
                return true;
            } else
            {
                return false;
            }
        }

        private string getClientsSessionID(int userID)
        {
            User user = this.itsModel.connectedUsers[userID];
            if (user != null)
            {
                return user.sessionID;
            } else
            {
                return "";
            }
        }
        void notifyAllClientsAboutProductChange(List<Product> updatedProductsInventory)
        {
            // 
        }


       
    }
}
