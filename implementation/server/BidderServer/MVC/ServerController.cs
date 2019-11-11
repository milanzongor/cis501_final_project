using BidderClient.Shared;
using BidderServer.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer.MVC
{
    public class ServerController : ServerAPI
    {
        public bool autentizate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            throw new NotImplementedException();
        }
    }
}
