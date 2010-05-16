using System;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class NeedItem
    {
        public MetricTypes MetricType
        {
            get { return Reflection.SafeConvertToEnum(MetricTypeVal, MetricTypes.Item); }
            set { MetricTypeVal = (Int16) value; }
        }
    }
}