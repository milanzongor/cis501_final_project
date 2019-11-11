using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class Bid
    {
        public User bidder { get; }
        public double value { get; }
        public DateTime timestamp { get; }

        public Bid(User bidder, double value, DateTime timespamp)
        {
            this.bidder = bidder;
            this.value = value;
            this.timestamp = timestamp;
        }
    }
}
