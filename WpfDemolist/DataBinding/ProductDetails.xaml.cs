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
    /// ProductDetails.xaml 的交互逻辑
    /// </summary>
    public partial class ProductDetails : BaseWindow
    {
        public ProductDetails()
        {
            InitializeComponent();

            
        }

        private void cmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("请输入ID");
                return;
            }

            int ID;
            if (Int32.TryParse(txtID.Text, out ID))
            {
                try
                {
                    gridProductDetails.DataContext = App.StoreDB.GetProduct(ID);
                }
                catch 
                {
                    MessageBox.Show("请输入数字");
                }
            }
            
        }
    }
}
