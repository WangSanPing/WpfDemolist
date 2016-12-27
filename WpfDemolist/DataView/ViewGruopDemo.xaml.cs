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
    /// ViewGruopDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ViewGruopDemo : BaseWindow
    {
        public ViewGruopDemo()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.lstProducts.ItemsSource = App.StoreDB.GetProducts();
                ListCollectionView group = CollectionViewSource.GetDefaultView(this.lstProducts.ItemsSource) as ListCollectionView;
                group.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));


                this.lstProductsGroup.ItemsSource = App.StoreDB.GetProducts();
                ListCollectionView group1 = CollectionViewSource.GetDefaultView(this.lstProductsGroup.ItemsSource) as ListCollectionView;
                group1.SortDescriptions.Add(new SortDescription("UnitCost", ListSortDirection.Ascending));
                PriceRangeProductGrouper grouper = new PriceRangeProductGrouper();
                grouper.GroupInterval = 50;
                group1.GroupDescriptions.Add(new PropertyGroupDescription("UnitCost", grouper));
            };
        }
    }
}
