using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class UpdateProductsParamWrapper
    {
        public Dictionary<int, Product> productsInventory { get; set; }

        public UpdateProductsParamWrapper()
        {

        }

        public UpdateProductsParamWrapper(Dictionary<int, Product> productsInventory)
        {
            this.productsInventory = productsInventory;
        }

        public bool hasValidValues()
        {
            return productsInventory != null && productsInventory.Count() != 0;
        }
    }
}
