using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StoreDatabase;

namespace WpfDemolist.Selector
{
    public class ProductByCategoryStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = item as Product;


            if (product.CategoryName == "Travel")
            {
                return (Style)Application.Current.FindResource("DefaultStyle");
            }
            else
            {
                return (Style)Application.Current.FindResource("HighlightStyle");
            }
        }
    }
}
