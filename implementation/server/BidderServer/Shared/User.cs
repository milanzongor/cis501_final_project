using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    class User
    {
        public string userID { get; }
        public Credentials credentials { get; }

        public User(string userID, Credentials credentials)
        {
            this.userID = userID;
            this.credentials = credentials;
        }
    }
}
