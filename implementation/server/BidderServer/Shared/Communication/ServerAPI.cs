using BidderClient.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public interface ServerAPI
    {
        User autentizate(Credentials credentials);
        bool bidProduct(int productID, double bidValue, User bidder);
    }
}
