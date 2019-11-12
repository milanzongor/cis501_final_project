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
        public int numberOfBids { get; set; }

        public Product(int productID, Item item, ProductStatus productStatus) 
        {
            this.productID = productID;
            this.item = item;
            this.productStatus = productStatus;
            this.sellingStatus = SellingStatus.UNTAKEN;
            currentHighestBid = null;
            numberOfBids = 0;
        }

        public override string ToString()
        {
            string part1 = item.name + ", " + productStatus + ", " + sellingStatus + " : " + numberOfBids + " bids";
            if (currentHighestBid != null)
            {
                string part2 = ", highest " + currentHighestBid.bidder.credentials.userName + " [" + currentHighestBid.value + "]";
                return part1 + part2;
            } else
            {
                return part1;
            }


        }
    }
}
