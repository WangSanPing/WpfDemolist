using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDatabase;

namespace WpfDemolist.DataView
{
    public class ProductByPriceFilterer
    {
        public decimal MinimumPrice
        {
            get; set;
        }

        public ProductByPriceFilterer(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        public bool FilterItem(Object item)
        {
            Product product = item as Product;
            if (product != null)
            {
                if (product.UnitCost > MinimumPrice)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
