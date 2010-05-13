using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL 
{
    public partial class ProgressReport
    {
        public Utils.Enumerations.IncidentStatuses IncidentStatus
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.IncidentStatuses>(StatusVal, Utils.Enumerations.IncidentStatuses.Working);
            }
            set
            {
                StatusVal = (Int16)value;
            }
        }
    }
}
