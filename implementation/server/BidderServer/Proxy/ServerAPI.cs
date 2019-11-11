using BidderClient.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer.Proxy
{
    public interface ServerAPI
    {
        bool autentizate(string userName, string password);
        bool bidProduct(int productID, double bidValue, User bidder);
    }
}
