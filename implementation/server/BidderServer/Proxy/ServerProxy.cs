using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidderClient.Shared;

namespace BidderServer.Proxy
{
    public class ServerProxy : ServerAPI
    {
        private ServerAPI itsRealSubject;

        public ServerProxy(ServerAPI realSubject)
        {
            this.itsRealSubject = realSubject;
        }

        public bool autentizate(Credentials credentials)
        {
            return itsRealSubject.autentizate(credentials);
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            return itsRealSubject.bidProduct(productID, bidValue, bidder);
        }
    }
}
