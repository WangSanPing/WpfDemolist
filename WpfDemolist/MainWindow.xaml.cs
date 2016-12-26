using System;
using System.Windows;
using System.Windows.Controls;

using WpfDemolist.Common;
using WpfDemolist.ControlTemplateList;
using WpfDemolist.CustomControlDemo;
using WpfDemolist.DataBinding;
using WpfDemolist.StyleDemoList;

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
                case (int)GlobalStaticStr.WpfDemoList.DataFormatDemo:
                    page = new DataFormatDemo();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.StyleSelectorDemo:
                    page = new StyleSelectorDemo();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.DataTemplateDemo:
                    page = new DataTemplateDemo();
                    break;
                case (int)GlobalStaticStr.WpfDemoList.ComboBoxDemo:
                    page = new ComboboxDemo();
                    break;
            }
            page.Show();
        }
    }
}
