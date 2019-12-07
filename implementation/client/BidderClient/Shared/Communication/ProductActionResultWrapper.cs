using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class ProductAuctionResultWrapper
    {
        public Product product { get; set; }
        public bool didYouWin { get; set; }

        public ProductAuctionResultWrapper()
        {
           
        }

        public ProductAuctionResultWrapper(Product product, bool didYouWin)
        {
            this.product = product;
            this.didYouWin = didYouWin;
        }
        public bool hasValidValues()
        {
            return product != null && product.item != null;
        }
    }
}
