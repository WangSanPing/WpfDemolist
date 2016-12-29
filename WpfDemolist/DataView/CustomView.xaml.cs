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

namespace WpfDemolist.DataView
{
    /// <summary>
    /// CustomView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomView : BaseWindow
    {
        public CustomView()
        {
            InitializeComponent();
            this.Loaded += (s, e) => {
                this.lst.ItemsSource = App.StoreDB.GetProducts();
            };
        }

        private void cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbb.SelectedItem;
            lst.View = (ViewBase)this.FindResource(selectedItem.Content);
        }
    }
}
