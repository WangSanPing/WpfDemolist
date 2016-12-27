using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using StoreDatabase;
using System;

namespace WpfDemolist.DataView
{
    public class SortByModelNameLength : IComparer
    {
        public int Compare(object x, object y)
        {
            Product itemX = (Product)x;
            Product itemY = (Product)y;

            return itemX.ModelName.Length.CompareTo(itemY.ModelName.Length);
        }
    }
}
