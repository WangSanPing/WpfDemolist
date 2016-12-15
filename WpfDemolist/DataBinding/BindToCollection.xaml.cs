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
using System.Collections.ObjectModel;

using StoreDatabase;

namespace WpfDemolist.DataBinding
{
    /// <summary>
    /// BindToCollection.xaml 的交互逻辑
    /// </summary>
    public partial class BindToCollection : BaseWindow
    {
        private ICollection<Product> products = new ObservableCollection<Product>();

        public BindToCollection()
        {
            InitializeComponent();

        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                products = App.StoreDB.GetProducts();
                this.lstProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdAddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.products.Add(this.lstProducts.SelectedItem as Product);
            this.lstProducts.ItemsSource = this.products;
        }

        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
