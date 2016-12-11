using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDemolist.Controls
{
    /// <summary>
    /// DataGridSelectColumn.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridSelectColumn : DataGridTemplateColumn
    {
        private DataGrid _ownerDataGrid;
        private CheckBox _headerCheckBox;
        private Dictionary<object, MarkObject> _markObjects;

        public event EventHandler SelectedItemChanged;

        public DataGrid OwerDataGrid
        {
            get
            {
                return _ownerDataGrid;
            }

            set
            {
                _ownerDataGrid = value;
                _ownerDataGrid.LoadingRow += OnLoadingRow;
            }
        }

        public void SelecteAll()
        {
            if (_headerCheckBox != null)
                _headerCheckBox.IsChecked = true;
            SetAllSelectedStates(true);
        }

        public void UnselectAll()
        {
            if (_headerCheckBox != null)
                _headerCheckBox.IsChecked = false;
            SetAllSelectedStates(false);
        }

        public List<T> GetSelectedItems<T>()
        {
            List<T> result = new List<T>();
            if (_ownerDataGrid.ItemsSource != null)
            {
                var enu = _ownerDataGrid.ItemsSource.GetEnumerator();
                while (enu.MoveNext())
                {
                    if (GetMarkObject(enu.Current).IsSelected)
                        result.Add((T)enu.Current);
                }
            }
            ClearItems();
            return result;
        }

        public void SetSelectedItems(IList items)
        {
            if (_ownerDataGrid.ItemsSource == null)
                return;

            var enu = _ownerDataGrid.ItemsSource.GetEnumerator();
            while (enu.MoveNext())
            {
                GetMarkObject(enu.Current).IsSelected = items.Contains(enu.Current);
            }
        }

        public DataGridSelectColumn()
        {
            InitializeComponent();
            IsReadOnly = true;
            _markObjects = new Dictionary<object, MarkObject>();
        }

        private void OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            object dataContext = e.Row.DataContext;
            FrameworkElement element = this.GetCellContent(e.Row);
            element.DataContext = GetMarkObject(dataContext);
        }

        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            _headerCheckBox = sender as CheckBox;
            _headerCheckBox.Loaded -= CheckBox_Loaded;
            _headerCheckBox.Checked += (s2, e2) => SetAllSelectedStates(true);
            _headerCheckBox.Unchecked += (s2, e2) => SetAllSelectedStates(false);
        }

        private void SetAllSelectedStates(bool value)
        {
            if (OwerDataGrid == null || OwerDataGrid.ItemsSource == null)
            {
                return;
            }

            var enu = OwerDataGrid.ItemsSource.GetEnumerator();

            while (enu.MoveNext())
            {
                GetMarkObject(enu.Current).IsSelected = value;
            }

            ClearItems();
        }

        private MarkObject GetMarkObject(Object obj)
        {
            if (_markObjects.ContainsKey(obj) == false)
            {
                MarkObject markObject;
                markObject = new MarkObject();
                _markObjects.Add(obj, markObject);
                markObject.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "IsSelected")
                    {
                        if (SelectedItemChanged != null)
                        {
                            SelectedItemChanged(this, EventArgs.Empty);
                        }
                    }
                };
            }

            return _markObjects[obj];
        }

        private void ClearItems()
        {
            var enu = OwerDataGrid.ItemsSource.GetEnumerator();
            List<object> list = new List<object>();
            while (enu.MoveNext())
            {
                list.Add(enu.Current);
            }
            List<object> removeableObjects = new List<object>();
            foreach (var item in _markObjects)
            {
                if (list.Contains(item.Key))
                {
                    removeableObjects.Add(item.Key);
                }
            }
            for (int i = 0; i < removeableObjects.Count; i++)
            {
                _markObjects.Remove(removeableObjects[i]);
            }
        }
    }
}
