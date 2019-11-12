using BidderClient.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer.MVC
{
    public class ServerModel
    {
        public Dictionary<int, Product> productsInventory { get; set; }
        public List<User> connectedUsers { get; }

        public ServerModel()
        {
            this.productsInventory = new Dictionary<int, Product>();
            this.connectedUsers = new List<User>();
        }
    }
}
