using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class RequestRespons
    {
        public RequestResponseStatuses Status
        {
            get { return Reflection.SafeConvertToEnum(StatusVal, RequestResponseStatuses.Waiting); }
            set { StatusVal = (Int16)value; }
        }
    }
}
