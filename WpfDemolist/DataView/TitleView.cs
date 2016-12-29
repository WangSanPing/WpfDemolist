using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDemolist.DataView
{
    public class TileView : ViewBase
    {
        private Brush selectedBackground = Brushes.Transparent;

        public Brush SelectedBackground
        {
            get
            {
                return selectedBackground;
            }

            set
            {
                selectedBackground = value;
            }
        }
        private Brush selectedBorderBrush = Brushes.Black;

        public Brush SelectedBorderBrush
        {
            get
            {
                return selectedBorderBrush;
            }

            set
            {
                selectedBorderBrush = value;
            }
        }
        private DataTemplate itemTemplate;

        public DataTemplate ItemTemplate
        {
            get
            {
                return itemTemplate;
            }

            set
            {
                itemTemplate = value;
            }
        }

        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileView"); }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }

    }
}
