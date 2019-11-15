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
        public List<Product> productInventory { get; set; }
        public User loggedUser { get; set; }
        public ClientModel()
        {
            this.productInventory = new List<Product>();
            this.loggedUser = new User(0, null); // NOTE!!!! I am not sure if this is how it should be
        }
    }
}
