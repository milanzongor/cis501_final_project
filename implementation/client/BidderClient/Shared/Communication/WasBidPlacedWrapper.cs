using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class WasBidPlacedWrapper
    {
        public bool wasSuccessful { get; set; }

        public WasBidPlacedWrapper()
        {

        }

        public WasBidPlacedWrapper(bool wasSuccessful)
        {
            this.wasSuccessful = wasSuccessful;
        }
    }
}
