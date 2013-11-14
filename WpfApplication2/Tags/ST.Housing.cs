using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craigslist.org.Tags
{
    public partial class ST
    {
        public class Housing
        {
            public string Build(object[] args)
            {
                int Min = (int)args[0];
                int Max = (int)args[1];
                int Bed = (int)args[2];
                Boolean Cats = (Boolean)args[3];
                Boolean Dogs = (Boolean)args[4];
                Boolean HasPic = (Boolean)args[5];
                Boolean Title = (Boolean)args[6];

                return this.Min(Min) +
                       this.Max(Max) +
                       this.Bed(Bed) +
                       this.Cats(Cats) +
                       this.Dogs(Dogs) +
                       this.HasPic(HasPic) +
                       this.Title(Title);
            }

            public string Min(int tb)
            {
                return tb > 0 ? string.Empty : "&minAsk=" + tb;
            }

            public string Max(int tb)
            {
                return tb > 0 ? string.Empty : "&maxAsk=" + tb;
            }

            public string Bed(int tb)
            {
                return tb > 0 ? string.Empty : "&bedrooms=" + tb;
            }

            public string Cats(Boolean cb)
            {
                return cb ? "&addTwo=purrr" : string.Empty;
            }

            public string Dogs(Boolean cb)
            {
                return cb ? "&addThree=wooof" : string.Empty;
            }

            public string HasPic(Boolean cb)
            {
                return cb ? "&hasPic=1" : string.Empty;
            }

            public string Title(Boolean cb)
            {
                return cb ? "&srchType=T" : string.Empty;
            }
        }
    }
}
