using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace WpfDemolist.ControlTemplateList
{
    /// <summary>
    /// ControlsOfControlTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class ControlsOfControlTemplate : BaseWindow
    {
        public ControlsOfControlTemplate()
        {
            InitializeComponent();
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();
            // 拿到程序集
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(controlType) &&
                    !type.IsAbstract &&
                    type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }

            derivedTypes.Sort(new TypeComparer());
            this.list.ItemsSource = derivedTypes;
            this.list.DisplayMemberPath = "Name";
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Type type = (Type)list.SelectedItem;

                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);

                Window win = control as Window;
                if (win != null)
                {
                    win.WindowState = System.Windows.WindowState.Minimized;
                    win.ShowInTaskbar = false;
                    win.Show();
                }
                else
                {
                    control.Visibility = Visibility.Collapsed;
                    this.grid.Children.Add(control);
                }

                ControlTemplate template = control.Template;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true; // 是否缩进
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);
                // Display the template.
                this.text.Text = sb.ToString();

                // Remove the control from the grid.
                if (win != null)
                {
                    win.Close();
                }
                else
                {
                    grid.Children.Remove(control);
                }
            }
            catch (Exception ex)
            {
                this.text.Text = "<< 错误信息: " + ex.Message + ">>";

            }
        }
    }

    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
