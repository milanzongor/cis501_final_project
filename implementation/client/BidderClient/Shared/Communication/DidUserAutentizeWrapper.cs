using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class DidUserAutentizeWrapper
    {
        public bool wasSuccessful { get; set; }
        public User autentizedUser { get; set; }

        public DidUserAutentizeWrapper()
        {

        }

        public DidUserAutentizeWrapper(bool wasSuccessful, User autentizedUser)
        {
            this.wasSuccessful = wasSuccessful;
            this.autentizedUser = autentizedUser;
        }

        public bool hasValidValues()
        {
            return autentizedUser != null;
        }
    }
}
