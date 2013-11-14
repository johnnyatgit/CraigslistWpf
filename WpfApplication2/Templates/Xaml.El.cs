using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Collections;
using System.Windows.Controls;

namespace Craigslist.org
{
    public partial class Xaml
    {

        public class El : TempWin
        {

            ExpandoObject ExpObj = new ExpandoObject();

            public static dynamic create(Dictionary<string, object> properties)
            {

                var dynObj = new ExpandoObject() as IDictionary<string, object>;
                //this.dynObj = new ExpandoObject() as IDictionary<string, object>;
            
                foreach (var property in properties)
                {
                    dynObj.Add(property.Key, property.Value);
                }

                return dynObj;

            }

        }

    }
}
