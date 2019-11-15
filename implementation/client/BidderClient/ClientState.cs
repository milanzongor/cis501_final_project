using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient
{
    public enum ClientState { UNAUTENTIZED, AUTENTIZED_SUCCESSFULLY, AUTENTIZATION_FAILED, ALL_PRODUCTS_OFFERED, PRODUCT_SELECTED, BID_PLACED_OK, BID_REJECTED };
}
