﻿using System;
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

namespace WpfDemolist.CustomControlDemo
{
    /// <summary>
    /// ColorPickerDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPickerDemo : BaseWindow
    {
        public ColorPickerDemo()
        {
            InitializeComponent();
        }

        private void colorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (lblColor != null) lblColor.Text = "The new color is " + e.NewValue.ToString();
        }
    }
}
