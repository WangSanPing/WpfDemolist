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
            int tag = Convert.ToInt32(btn.Tag);
            BaseWindow page = new BaseWindow();

            // 简单工厂
            switch (tag)
            {
                case (int)GlobalStaticStr.FunctionList.DemoControlTemplate:
                    page = new DemoControlTemplate();
                    break;
                case (int)GlobalStaticStr.FunctionList.VisualTreeDisplay:
                    page = new VisualTreeDisplay();
                    page.showVisualTree(this);
                    break;
                case (int)GlobalStaticStr.FunctionList.ControlsOfControlTemplate:
                    page = new ControlsOfControlTemplate();
                    break;
            }

            page.Show();
        }
    }
}
