using System;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class ProgressReport
    {
        public IncidentStatuses IncidentStatus
        {
            get { return Reflection.SafeConvertToEnum(StatusVal, IncidentStatuses.Working); }
            set { StatusVal = (Int16) value; }
        }
    }
}