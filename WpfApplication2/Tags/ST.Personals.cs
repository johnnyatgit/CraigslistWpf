using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craigslist.org.Tags
{
    public partial class ST
    {
        public class Personals
        {

            public string Build(object[] args)
            {
                int Min = (int)args[0];
                int Max = (int)args[1];
                Boolean HasPic = (Boolean)args[2];
                Boolean Title = (Boolean)args[3];

                return this.Min(Min) + this.Max(Max) + this.HasPic(HasPic) + this.Title(Title);
            }

            public string Min(int tb)
            {
                return tb > 0 ? "&minAsk=" + tb : string.Empty;
            }

            public string Max(int tb)
            {
                return tb > 0 ? "&maxAsk=" + tb : string.Empty;
            }

            public string HasPic(Boolean cb)
            {
                return cb ? "&hasPic=1" : String.Empty;
            }

            public string Title(Boolean cb)
            {
                return cb ? "&srchType=T" : String.Empty;
            }

        }
    }
}
