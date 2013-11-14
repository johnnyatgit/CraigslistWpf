using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craigslist.org.Tags
{
    public partial class ST
    {
        public class Gigs
        {

            public string Build(object[] args)
            {

                bool Pay = (bool)args[0];
                bool Nopay = (bool)args[1];
                bool HasPic = (bool)args[2];
                bool Title = (bool)args[3];

                return this.Pay(Pay) +
                        this.Nopay(Nopay) +
                        this.HasPic(HasPic) +
                        this.Title(Title);

            }

            public string Pay(bool pay)
            {
                return pay ? "&addThree=forpay" : String.Empty;
            }

            public string Nopay(bool nopay)
            {
                return nopay ? "&addThree=forpay" : String.Empty;
            }

            public string HasPic(bool cb)
            {
                return cb ? "&hasPic=1" : string.Empty;
            }

            public string Title(bool cb)
            {
                return cb ? "&srchType=T" : string.Empty;
            }

        }
    }
}
