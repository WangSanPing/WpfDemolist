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


namespace WpfDemolist.DataBinding
{
    /// <summary>
    /// DataFormatDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DataFormatDemo : BaseWindow
    {

        private Product _product;

        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }
        public DataFormatDemo()
        {
            InitializeComponent();

            this.Loaded += (s, e) => {
                this.lstProduct.ItemsSource = App.StoreDB.GetProducts();
            };
        }

    }
}
