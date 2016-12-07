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
        public BaseWindow() { }

        public virtual void showVisualTree(DependencyObject element) { }
    }
}
