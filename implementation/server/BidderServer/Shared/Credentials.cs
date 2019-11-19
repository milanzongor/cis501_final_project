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

        public override int GetHashCode()
        {
            var hashCode = -514035047;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            return hashCode;
        }
    }
}
