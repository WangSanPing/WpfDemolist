using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemolist
{
    public static class GlobalStaticStr
    {
        public const string DemoControlTemplate = "DemoControlTemplate";
        public const string VisualTreeDisplay = "VisualTreeDisplay";

        public enum FunctionList
        {
            DemoControlTemplate = 0,
            VisualTreeDisplay = 1,
            ControlsOfControlTemplate = 2
        }
    }
}
