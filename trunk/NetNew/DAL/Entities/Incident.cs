using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class Incident
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

        public Utils.Enumerations.IncidentStatuses IncidentStatus
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.IncidentStatuses>(IncidentStatusVal, Utils.Enumerations.IncidentStatuses.Created);
            }
            set
            {
                IncidentStatusVal = (Int16)value;
            }
        }

        public IList<string> _locationCoordinates = null;

        public IList<string> LocationCoordinates
        {
            get
            {
                if (_locationCoordinates == null)
                {
                    _locationCoordinates = new Utils.ObservableStringList(LocationCoordinatesStr, "LocationCoordinatesStr", this);
                }
                return _locationCoordinates;
            }
        }
    }
}
