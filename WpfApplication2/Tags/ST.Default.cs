using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craigslist.org.Tags
{
    public partial class ST
    {
        public class Default
        {
            public string Build(object[] args)
            {
                Boolean pic = (Boolean)args[0];
                Boolean tit = (Boolean)args[1];

                return this.Haspic(pic) + this.Title(tit);
            }

            public string Haspic(Boolean cb)
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
