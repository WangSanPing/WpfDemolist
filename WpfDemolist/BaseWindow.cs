using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDemolist
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Height = 400;
            Width = 600;
        }

        public virtual void showVisualTree(DependencyObject element) { }
    }
}
