using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class ProductActionResultWrapper
    {
        public Product product { get; set; }
        public bool didYouWin { get; set; }

        public ProductActionResultWrapper()
        {
           
        }

        public ProductActionResultWrapper(Product product, bool didYouWin)
        {
            this.product = product;
            this.didYouWin = didYouWin;
        }
    }
}
