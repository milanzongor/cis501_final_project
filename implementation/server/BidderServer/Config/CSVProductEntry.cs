using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer.Config
{
    public class CSVProductEntry
    {
        [Name("id")]
        public int productID { get; set; }
        [Name("name")]
        public string productName { get; set; }
        [Name("startPrice")]
        public double startingBidPrice { get; set; }
        [Name("status")]
        public string status { get; set;}
    }
}
