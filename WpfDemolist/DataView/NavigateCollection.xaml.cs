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

namespace WpfDemolist.DataView
{
    /// <summary>
    /// NavigateCollection.xaml 的交互逻辑
    /// </summary>
    public partial class NavigateCollection : BaseWindow
    {
        private List<Product> _products;
        private ListCollectionView _lstView;

        private delegate void getdelegate();

        void getde() { }

        void geted() { }
        public List<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = App.StoreDB.GetProducts().ToList();
                }

                return _products;
            }

            set
            {
                _products = value;
            }
        }
        public NavigateCollection()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.cbb.DataContext = this.Products;
                //this.cbb.SelectionChanged += Cbb_SelectionChanged;
                _lstView = CollectionViewSource.GetDefaultView(this.cbb.DataContext) as ListCollectionView;
                _lstView.CurrentChanged += _lstView_CurrentChanged;
            };
        }

        private void Cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._lstView.MoveCurrentTo(this.cbb.SelectedItem);
        }

        private void _lstView_CurrentChanged(object sender, EventArgs e)
        {
            this.lblPosition.Content = (_lstView.CurrentPosition + 1).ToString() + "   of   " +
                this._lstView.Count.ToString();

            this.btnPre.IsEnabled = _lstView.CurrentPosition > 0;
            this.btnNext.IsEnabled = _lstView.CurrentPosition < _lstView.Count - 1;

            this.cbb.SelectedItem = this._lstView.CurrentItem;
        }

        private void btnPre_Click(object sender, RoutedEventArgs e)
        {
            _lstView.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _lstView.MoveCurrentToNext();
        }
    }
}
