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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemolist.Common;
using WpfDemolist.ControlTemplateList;
using WpfDemolist.CustomControlDemo;
using WpfDemolist.DataBinding;

namespace WpfDemolist
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// 控件模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int tag = Convert.ToInt32(btn.Tag);
            BaseWindow page = new BaseWindow();

            // 简单工厂
            switch (tag)
            {
                case (int)GlobalStaticStr.WpfDemoList.DemoControlTemplate:
                    page = new DemoControlTemplate();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.VisualTreeDisplay:
                    page = new VisualTreeDisplay();
                    page.showVisualTree(this);
                    break;
                case (int)GlobalStaticStr.WpfDemoList.ControlsOfControlTemplate:
                    page = new ControlsOfControlTemplate();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.CustomListBox:
                    page = new CustomListBox();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.ColorPickerDemo:
                    page = new ColorPickerDemo();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.FlipPanelDemo:
                    page = new FlipPanelDemo();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.ProductDetails:
                    page = new ProductDetails();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.BindToCollection:
                    page = new BindToCollection();
                    break;
            }

            page.Show();
        }
    }
}
