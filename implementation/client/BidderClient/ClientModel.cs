using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient
{
    class ClientModel
    {
        public List<Shared.Product> productInventory { get; set; }
        public Shared.User User { get; set; }
    }
}
