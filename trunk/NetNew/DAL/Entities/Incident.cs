using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Enumerations;

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

        public Utils.Enumerations.Severities Severity
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.Severities>(this.SeverityVal, Utils.Enumerations.Severities.Medium);
            }
            set
            {
                this.SeverityVal = (Int16)value;
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

        public IList<string> Validate()
        {
            // this string list will be filled with messages.
            List<string> incorrects = new List<string>();

            string msg;

            if (this.Crisis == null)
                incorrects.Add("Incident doesn't belong to any crisis.");

            if (this.DateCreated.Year < DateTime.Now.Year - 10 || this.DateCreated.Year > DateTime.Now.Year)
                incorrects.Add("Creation date is incorrect.");

             if (this.IncidentStatus == IncidentStatuses.Complete && this.DateClosed.HasValue==false)
                incorrects.Add("Completion date is not assigned.");

             if (this.LocationCoordinates.Count == 0)
                 incorrects.Add("Incident location is not defined.");

            if (!Utils.Validation.Check(this.Explanation, 3, 500, out msg, ValRules._AllowAll))
                incorrects.Add("Explanation is not correct! " + msg);

             

            return incorrects;
        }
    }
}
