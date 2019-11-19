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

        public override bool Equals(object obj)
        {
            User other = (User) obj;
            return this.credentials.userName.Equals(other.credentials.userName);
        }

        public override int GetHashCode()
        {
            var hashCode = -1676068120;
            hashCode = hashCode * -1521134295 + userID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Credentials>.Default.GetHashCode(credentials);
            return hashCode;
        }
    }
}
