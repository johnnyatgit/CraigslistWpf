using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craigslist.org.Tags
{
    public partial class ST
    {
        public class Jobs
        {

            public string Build(object[] args)
            {

                Boolean Telecommute = (Boolean)args[0];
                Boolean Contract = (Boolean)args[1];
                Boolean Internship = (Boolean)args[2];
                Boolean Parttime = (Boolean)args[3];
                Boolean Nonprofit = (Boolean)args[4];
                Boolean HasPic = (Boolean)args[5];
                Boolean Title = (Boolean)args[6];

                return this.Telecommute(Telecommute) +
                        this.Contract(Contract) +
                        this.Internship(Internship) +
                        this.Parttime(Parttime) +
                        this.Nonprofit(Nonprofit) +
                        this.HasPic(HasPic) +
                        this.Title(Title);

            }

            public string Telecommute(Boolean cb)
            {
                return cb ? "&addOne=telecommuting" : string.Empty;
            }

            public string Contract(Boolean cb)
            {
                return cb ? "&addTwo=contract" : string.Empty;
            }

            public string Internship(Boolean cb)
            {
                return cb ? "&addThree=internship" : string.Empty;
            }

            public string Parttime(Boolean cb)
            {
                return cb ? "&addFour=part-time" : string.Empty;
            }

            public string Nonprofit(Boolean cb)
            {
                return cb ? "&addFive=non-profit" : string.Empty;
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
