using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class Product
    {
        public int productID { get; }
        public Item item { get; }
        public ProductStatus productStatus { get; set; }
        public SellingStatus sellingStatus { get; set; }
        public Bid currentHighestBid { get; set; }

        public Product(int productID, Item item, ProductStatus productStatus) 
        {
            this.productID = productID;
            this.item = item;
            this.productStatus = productStatus;
            this.sellingStatus = SellingStatus.UNTAKEN;
            currentHighestBid = null;
        }
    }
}
