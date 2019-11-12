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
    public delegate void AddProductHandler(Product product);
    public delegate void RemoveProductHandler(int productID);
    public delegate void ModifyProductHandler(Product product);
    public delegate void StartProductAuctionHandler(int productID);
    public delegate void StopProductAuctionHandler(int productID);
    public delegate void ProductsFormClosedHandler();
}
