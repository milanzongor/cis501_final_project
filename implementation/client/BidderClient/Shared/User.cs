using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class User
    {
        public int userID { get; }
        public Credentials credentials { get; }

        public User(int userID, Credentials credentials)
        {
            this.userID = userID;
            this.credentials = credentials;
        }
    }
}
