using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class Credentials
    {
        public string userName { get; }
        public string password { get; }

        public Credentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            Credentials other = (Credentials) obj;
            return this.userName.Equals(other.userName) &&
                this.password.Equals(other.password);
        }
    }
}
