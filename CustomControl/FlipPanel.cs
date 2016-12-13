using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControl
{
    public class FlipPanel : Control
    {
        #region Field

        public static DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(object), typeof(FlipPanel)
                , null);

        public static DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(object), typeof(FlipPanel)
                , null);

        public static DependencyProperty IsFlippedProperty =
            DependencyProperty.Register("IsFlipped", typeof(object), typeof(FlipPanel)
                , null);

        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlipPanel)
                , null);
        #endregion

        #region 属性

        public object FrontContent
        {
            get
            {
                return base.GetValue(FrontContentProperty);
            }
            set
            {
                base.SetValue(FrontContentProperty, value);
            }
        }

        public object BackContent
        {
            get
            {
                return base.GetValue(BackContentProperty);
            }
            set
            {
                base.SetValue(BackContentProperty, value);
            }
        }

        public bool IsFlipped
        {
            get
            {
                return (bool)base.GetValue(IsFlippedProperty);
            }
            set
            {
                base.SetValue(IsFlippedProperty, value);
                ChangeVisualState(true);
            }
        }

        public object CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
        #endregion

        static FlipPanel()
        {
            // 通知控件在generic.xaml文件中获取默认样式
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel),
                new FrameworkPropertyMetadata(typeof(FlipPanel)));
        }

        private void ChangeVisualState(bool state)
        {

        }

        private static void FrontContentCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
