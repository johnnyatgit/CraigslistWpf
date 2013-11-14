using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Craigslist.org
{
    /// <summary>
    /// Interaction logic for TempWin.xaml
    /// </summary>
    public partial class TempWin : Window
    {
        public TempWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var Properties = new Dictionary<string, object>();

            Properties.Add("Text", "Hello World!");
            Properties.Add("Title", "Hello World!");
            Properties.Add("Tags", new object[] { "hellow", "world"});

            var dyn = Xaml.El.create(Properties);

            Grid personals = new Xaml.Personals();
            
            this.gridMain.Children.Add(personals);

            Grid.SetRow(personals, 0);
            Grid.SetColumn(personals, 0);

            TextBox min = (TextBox)getEl("Textbox","tbMinAge");
            MessageBox.Show(min.Text);

        }

        private object getEl(String xtype, String xname)
        {
            switch (xtype) 
            { 
                case "Textbox":
                    return FindChild<TextBox>(Application.Current.MainWindow, xname);
                default:
                    return null;
            }
        }

        public static T FindChild<T>(DependencyObject depObj, string childName)
           where T : DependencyObject
                {
                    // Confirm obj is valid. 
                    if (depObj == null) return null;

                    // success case
                    if (depObj is T && ((FrameworkElement)depObj).Name == childName)
                        return depObj as T;

                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                        //DFS
                        T obj = FindChild<T>(child, childName);

                        if (obj != null)
                            return obj;
                    }

                    return null;
                }

    }
}
