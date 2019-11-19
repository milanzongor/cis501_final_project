using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    class BidProductParamsWrapper
    {
        public int productID { get; set; }
        public double bidValue { get; set; }
        public User bidder { get; set; }
    }
}
