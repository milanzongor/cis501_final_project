using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class BidProductParamsWrapper
    {
        public int productID { get; set; }
        public double bidValue { get; set; }
        public User bidder { get; set; }

        public BidProductParamsWrapper(int productID, double bidValue, User bidder)
        {
            this.productID = productID;
            this.bidValue = bidValue;
            this.bidder = bidder;
        }

        public bool hasValidValues()
        {
            return productID != 0 && bidValue != 0 && bidder != null && bidder.userID != 0;
        }
    }
}
