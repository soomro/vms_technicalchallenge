using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class IncidentReport
    {
        public Utils.Enumerations.IncidentTypes IncidentType
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.IncidentTypes>(this.IncidentTypeVal, Utils.Enumerations.IncidentTypes.Accident);
            }
            set
            {
                this.IncidentTypeVal = (Int16)value;
            }
        }
    }
}
