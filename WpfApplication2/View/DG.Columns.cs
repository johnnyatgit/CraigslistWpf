using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace Craigslist.org.View
{
    public partial class DG
    {
        public class Columns
        {
            public Columns(DataGrid dg)
            {
                try
                {
                    dg.Items.Clear();
                    dg.Columns.Clear();
                }
                catch { }


                Object[] columns = new Object[]{
                    new Object[]{ "text", "#", 30, "counter" },
                    //new Object[]{ "checkbox", " ", 30, "check" },
                    new Object[]{ "text", "Title", 150, "title" },
                };

                foreach (object[] col in columns)
                {
                    
                    switch ((String)col[0])
                    { 
                        case "text":
                            dg.Columns.Add(new DataGridTextColumn
                            {
                                Header = (String)col[1],
                                Binding = new Binding((String)col[3]),
                                Width = (int)col[2],
                                IsReadOnly = true
                            });
                            break;
                        case "checkbox":
                            dg.Columns.Add(new DataGridCheckBoxColumn
                            {
                                Header = (String)col[1],
                                Binding = new Binding((String)col[3]),
                                Width = (int)col[2],
                                IsReadOnly = false
                            });
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
