using System;
using System.Collections.Generic;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class Crisis
    {
        public IList<string> _locationCoordinates;

        public CrisisStatuses Status
        {
            get { return Reflection.SafeConvertToEnum(StatusVal, CrisisStatuses.Active); }
            set
            {
                StatusVal = (short) value;
                if (value == CrisisStatuses.Closed)
                    DateClosed = DateTime.Now;
            }
        }

        [Obsolete("Different crisis location types have not been implemented.")]
        public LocationTypes LocationType
        {
            get { return Reflection.SafeConvertToEnum(LocationTypeVal, LocationTypes.Rectangle); }
            set { LocationTypeVal = (Int16) value; }
        }

        public CrisisTypes CrisisType
        {
            get { return Reflection.SafeConvertToEnum(CrisisTypeVal, CrisisTypes.Earthquake); }
            set { CrisisTypeVal = (Int16) value; }
        }

        /// <summary>
        /// Contains Latitude, Longitude and Radius values for the location.
        /// </summary>
        public IList<string> LocationCoordinates
        {
            get
            {
                if (_locationCoordinates != null) return _locationCoordinates;
                _locationCoordinates = new ObservableStringList(LocationCoordinatesStr, "LocationCoordinatesStr", this);
                return _locationCoordinates;
            }
        }

        /// <summary>
        /// Checks important values and returns a string collection containing error messages.
        /// </summary>
        /// <returns>Error messages</returns>
        public IList<string> Validate()
        {
            // this string list will be filled with messages.
            var incorrects = new List<string>();

            string msg;
            if (!Validation.Check(Name, 3, 50, out msg, ValRules._StartsWith_abc, ValRules._Space, ValRules._abc,
                                  ValRules._123))
                incorrects.Add("Crisis name is not correct! " + msg);

            if (DateCreated.Year < DateTime.Now.Year - 10 || DateCreated.Year > DateTime.Now.Year)
                incorrects.Add("Creation date is incorrect.");

            if (string.IsNullOrEmpty(Explanation))
            {
                incorrects.Add("Explanation can not be empty.");
            }

            if (LocationCoordinates.Count == 0)
            {
                incorrects.Add("Location has not been defined.");
            }

            return incorrects;
        }
    }
}