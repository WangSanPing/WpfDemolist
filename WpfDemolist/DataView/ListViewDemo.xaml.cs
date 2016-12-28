using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StoreDatabase;
using System.ComponentModel;

namespace WpfDemolist.DataView
{
    /// <summary>
    /// ListViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewDemo : BaseWindow
    {
        public ListViewDemo()
        {
            InitializeComponent();

            this.Loaded += (s, e) => {
                this.lst.ItemsSource = App.StoreDB.GetProducts();
            };
        }
    }
}
