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
        }

        /// <summary>
        /// 控件模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            BaseWindow page = new BaseWindow();

            // 简单工厂
            switch (btn.Content.ToString())
            {
                case GlobalStaticStr.DemoControlTemplate:
                    page = new DemoControlTemplate();
                    break;
                case GlobalStaticStr.VisualTreeDisplay:
                    page = new VisualTreeDisplay();
                    page.showVisualTree(this);
                    break;
            }

            page.Show();
        }
    }
}
