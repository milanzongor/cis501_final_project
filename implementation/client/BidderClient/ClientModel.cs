using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidderClient.Shared;

namespace BidderClient
{
    public class ClientModel
    {
        public Dictionary<int, Product> productsInventory { get; set; }
        public User loggedUser { get; set; }

        public ClientModel()
        {
            this.productsInventory = new Dictionary<int, Product>();
            this.loggedUser = new User(0, null); // !!! NOTE change this
        }
    }
}
