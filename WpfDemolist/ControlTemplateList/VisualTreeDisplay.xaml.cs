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

namespace WpfDemolist.ControlTemplateList
{
    /// <summary>
    /// VisualTreeDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class VisualTreeDisplay : BaseWindow
    {
        public VisualTreeDisplay()
        {
            InitializeComponent();
        }

        public override void showVisualTree(DependencyObject element)
        {
            this.tree.Items.Clear();

            this.processElement(element, null);
        }

        private void processElement(DependencyObject element, TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            if (previousItem == null)
            {
                this.tree.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                processElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }
    }
}
