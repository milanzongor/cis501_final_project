using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class Item
    {
        public string name { get; set; }
        public double startingBidPrice { get; }

        public Item(string name, double startingBidPrice)
        {
            this.name = name;
            this.startingBidPrice = startingBidPrice;
        }
    }
}
