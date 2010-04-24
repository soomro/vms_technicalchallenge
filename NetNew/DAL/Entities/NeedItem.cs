using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class NeedItem
    {
        public Utils.Enumerations.MetricTypes MetricType
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.MetricTypes>(this.MetricTypeVal, Utils.Enumerations.MetricTypes.Item);
            }
            set
            {
                this.MetricTypeVal = (Int16)value;
            }
        }
    }
}
