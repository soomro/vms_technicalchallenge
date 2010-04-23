using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class Volunteer
    {
        public Utils.Enumerations.Gender Gender
        {
            get
            {
                return (Utils.Enumerations.Gender)this.GenderVal ;
            }
            set
            {
                this.GenderVal = (short)value;
            }
        }
    }
}
