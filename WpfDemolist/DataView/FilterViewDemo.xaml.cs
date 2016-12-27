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
    /// FilterViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class FilterViewDemo : BaseWindow
    {
        private ICollection<Product> products;

        public FilterViewDemo()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                products = App.StoreDB.GetProducts();
                this.lstProducts.ItemsSource = products;

                ICollectionView view = CollectionViewSource.GetDefaultView(this.lstProducts.ItemsSource);

                ListCollectionView lcview = CollectionViewSource.GetDefaultView(this.lstProducts.ItemsSource) as ListCollectionView;

                this.lstProductsGroup.ItemsSource = products;

                ListCollectionView group = CollectionViewSource.GetDefaultView(this.lstProductsGroup.ItemsSource) as ListCollectionView;
                group.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));
                //lcview.IsLiveFiltering = true;
                //lcview.LiveFilteringProperties.Add("UnitCost");
            };
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

            #region 在过滤器已经创建完毕之后，通过修改过滤器的属性可以直接进行过滤 如下代码(filterer.MinimumPrice = minimumPrice;)
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                decimal minimumPrice;

                if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice) && (filterer != null))
                {
                    filterer.MinimumPrice = minimumPrice;
                    view.Refresh();
                }
            }
            #endregion

            //this.cmdFilter_Click(null, null);
        }

        private ProductByPriceFilterer filterer;

        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(this.lstProducts.ItemsSource) as ListCollectionView;

                if (view != null)
                {
                    filterer = new ProductByPriceFilterer(minimumPrice);
                    view.Filter = new Predicate<object>(filterer.FilterItem);
                    view.Refresh();
                }
            }
        }

        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;

            //view.SortDescriptions.Clear();
            //view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));
            view.CustomSort = new SortByModelNameLength(); // 自定义排序。 按字母数量
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Descending));
        }
    }
}
