using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

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
            DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel)
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
                return GetValue(FrontContentProperty);
            }
            set
            {
                SetValue(FrontContentProperty, value);
            }
        }

        public object BackContent
        {
            get
            {
                return GetValue(BackContentProperty);
            }
            set
            {
                SetValue(BackContentProperty, value);
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

        public CornerRadius CornerRadius
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
            if (!IsFlipped)
            {
                VisualStateManager.GoToState(this, "Normal", state);
            }
            else
            {
                VisualStateManager.GoToState(this, "Flipped", state);
            }
        }

        private static void FrontContentCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ToggleButton flipButton = base.GetTemplateChild("FlipButton") as ToggleButton;
            if (flipButton != null) flipButton.Click += FlipButton_Click;

            ToggleButton flipButtonAlternate = base.GetTemplateChild("FlipButtonAlternate") as ToggleButton;
            if (flipButtonAlternate != null) flipButtonAlternate.Click += FlipButton_Click;

            this.ChangeVisualState(false);
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsFlipped = !this.IsFlipped;
            this.ChangeVisualState(true);
        }
    }
}
