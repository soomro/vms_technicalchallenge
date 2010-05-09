using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace DAL
{
    public partial class Crisis
    {
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
