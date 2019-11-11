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

        public bool autentizate(string userName, string password)
        {
            return itsRealSubject.autentizate(userName, password);
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            return itsRealSubject.bidProduct(productID, bidValue, bidder);
        }
    }
}
