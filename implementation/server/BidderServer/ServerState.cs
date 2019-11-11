using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderServer
{
    public enum ServerState { MONITORING_STATE, NEW_CLIENT_CONNECTED, MANAGING_PRODUCTS, PRODUCT_ADDED_SUCCESSFULLY, DUPLICATE_PRODUCT_NOT_ADDED }
}
