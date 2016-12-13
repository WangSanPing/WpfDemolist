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

namespace CustomControl
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        #region Field

        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;
        private Color? previousColor;

        #endregion Field

        #region 属性

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        #endregion

        #region 构造函数

        static ColorPicker()
        {

            ColorProperty = DependencyProperty.Register("Color",
                typeof(Color),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                new PropertyChangedCallback(OnColorChanged))
                );

            RedProperty = DependencyProperty.Register("Red",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty = DependencyProperty.Register("Green",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            CommandManager.RegisterClassCommandBinding(typeof(ColorPicker), new CommandBinding(ApplicationCommands.Undo,
                UndoCommand_Executed, UndoCommand_CanExecute));
        }

        public ColorPicker()
        {
            InitializeComponent();
            // SetUpCommands();
        }

        #endregion

        #region 注册在XAML中可用的事件

        public static readonly RoutedEvent ColorChangedEvent =
                 EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                 typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            RaiseEvent(args);
        }

        #endregion

        #region 依赖属性的回调事件

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;

            ColorPicker colorPicker = sender as ColorPicker;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;

            colorPicker.previousColor = (Color)e.OldValue;
            colorPicker.OnColorChanged(oldColor, newColor);
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = sender as ColorPicker;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }

            colorPicker.Color = color;
        }

        #endregion

        #region Command

        /// <summary>
        /// 公共commandBingdings绑定
        /// </summary>
        private void SetUpCommands()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed, UndoCommand_CanExecute);

            this.CommandBindings.Add(binding);
        }

        private static void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ColorPicker colorpicker = (ColorPicker)sender;
            e.CanExecute = colorpicker.previousColor.HasValue;
        }

        private static void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorPicker colorpicker = (ColorPicker)sender;
            Color currentColor = colorpicker.Color;
            colorpicker.Color = (Color)colorpicker.previousColor;
        }

        #endregion
    }
}
