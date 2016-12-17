using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StoreDatabase;
using System.Reflection;

namespace WpfDemolist.StyleSelectorClass
{
    public class ProductByCategoryStyleSelector2 : StyleSelector
    {
        public Style DefaultStyle
        {
            get;
            set;
        }

        public Style HighlightStyle
        {
            get;
            set;
        }

        public string PropertyToEvaluate
        {
            get;
            set;
        }

        public string PropertyValueToHighlight
        {
            get;
            set;
        }

        public override Style SelectStyle(object item,
          DependencyObject container)
        {
            Product product = (Product)item;

            // Use reflection to get the property to check.
            Type type = product.GetType();
            PropertyInfo property = type.GetProperty(PropertyToEvaluate);

            // Decide if this product should be highlighted
            // based on the property value.
            if (property.GetValue(product, null).ToString() == PropertyValueToHighlight)
            {
                return HighlightStyle;
            }
            else
            {
                return DefaultStyle;
            }
        }
    }
}
