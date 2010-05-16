using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Utils.Enumerations;

namespace DAL
{
    public partial class Crisis
    {
        public IList<string> Validate()
        {
           // this string list will be filled with messages.
            List<string> incorrects = new List<string>();

            string msg;
            if (!Utils.Validation.Check(Name, 3, 50, out msg, ValRules._StartsWith_abc, ValRules._Space, ValRules._abc,
                                   ValRules._123))
                incorrects.Add("Crisis name is not correct! " + msg);

            if (this.DateCreated.Year < DateTime.Now.Year - 10 || this.DateCreated.Year > DateTime.Now.Year)
                incorrects.Add("Creation date is incorrect.");

            if (string.IsNullOrEmpty(this.Explanation))
            {
                incorrects.Add("Explanation can not be empty.");
            }

            if (this.LocationCoordinates.Count == 0 )
            {
                incorrects.Add("Location has not been defined.");
            }
           
            return incorrects;
        }

        public Utils.Enumerations.CrisisStatuses Status
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.CrisisStatuses>(StatusVal, Utils.Enumerations.CrisisStatuses.Active);
            }
            set
            {
                StatusVal = (Int16)value;
                if (value == Utils.Enumerations.CrisisStatuses.Closed)
                    DateClosed = DateTime.Now;
            }
        }
        public Utils.Enumerations.LocationTypes LocationType
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.LocationTypes>(LocationTypeVal, Utils.Enumerations.LocationTypes.Rectangle);
            }
            set
            {
                LocationTypeVal = (Int16)value;
            }
        }
        public Utils.Enumerations.CrisisTypes CrisisType
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.CrisisTypes>(CrisisTypeVal, Utils.Enumerations.CrisisTypes.Earthquake);
            }
            set
            {
                CrisisTypeVal = (Int16)value;
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
