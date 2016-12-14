using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StoreDatabase;

namespace WpfDemolist
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static StoreDb storeDB = new StoreDb();

        public static StoreDb StoreDB
        {
            get
            {
                return storeDB;
            }
        }
    }
}
