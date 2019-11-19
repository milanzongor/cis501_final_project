using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared.Communication
{
    public class UpdateProductsParamWrapper
    {
        public List<Product> productsInventory { get; set; }

        public UpdateProductsParamWrapper(List<Product> productsInventory)
        {
            this.productsInventory = productsInventory;
        }

        public bool hasValidValues()
        {
            return productsInventory != null && productsInventory.Count() != 0;
        }
    }
}
