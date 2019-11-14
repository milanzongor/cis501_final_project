using BidderClient.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer
{
    public delegate void ManageProductsHandler();
    public delegate void ServerObserver(ServerState newState);
    public delegate void AddProductHandler(string productName, double productStartingPrice);
    public delegate void RemoveProductHandler(int productID);
    public delegate void ModifyProductHandler(int productID, string newProductName, double newProductStartingPrice);
    public delegate void StartProductAuctionHandler(int productID);
    public delegate void StopProductAuctionHandler(int productID);
    public delegate void ProductsFormClosedHandler();
    public delegate void DialogOKButtonHandler(string productName, double productStartingPrice);
}
