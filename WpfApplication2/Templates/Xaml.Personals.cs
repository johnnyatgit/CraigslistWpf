using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Craigslist.org
{
    public partial class Xaml
    {
        public class Personals : Grid
        {

            public Personals()
            {

                //set grid properties
                this.Name = "personalsGrid";
                //this.Margin = new System.Windows.Thickness(10, 10, 46, 223);

                //add one row
                this.RowDefinitions.Add(new RowDefinition { Name = "pgrow1"});

                //add one column
                this.ColumnDefinitions.Add(new ColumnDefinition());
                this.ColumnDefinitions.Add(new ColumnDefinition());

                TextBox min = this._tbMinAge();
                TextBox max = this._tbMaxAge();
                Label lmin = this._minLabel();
                Label lmax = this._maxLabel();

                this.Children.Add(lmin);
                this.Children.Add(lmax);
                this.Children.Add(min);
                this.Children.Add(max);

                Grid.SetRow(min, 0);
                Grid.SetColumn(lmin, 0);
                Grid.SetColumn(max, 1);
                Grid.SetColumn(lmax, 1);

            }
            
            private TextBox _tbMinAge()
            {
                return new TextBox { 
                    Name = "tbMinAge",
                    Text = "fShit",
                    Margin = new System.Windows.Thickness(50,8,15,5)
                };
            }

            private TextBox _tbMaxAge()
            {
                return new TextBox
                {
                    Name = "tbMaxAge",
                    Margin = new System.Windows.Thickness(50, 8, 15, 5)
                };
            }

            private Label _minLabel()
            {
                return new Label 
                {
                    Content = "Min:",
                    Margin = new System.Windows.Thickness(5, 5, 5, 5)
                };
            }

            private Label _maxLabel()
            {
                return new Label
                {
                    Content = "Max:",
                    Margin  = new System.Windows.Thickness(5,5,5,5)
                };
            }

        }
    }
}
