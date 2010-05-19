using System;
using System.Collections.Generic;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class Incident
    {
        public IList<string> _locationCoordinates;

        public IncidentTypes IncidentType
        {
            get { return Reflection.SafeConvertToEnum(IncidentTypeVal, IncidentTypes.Accident); }
            set { IncidentTypeVal = (Int16) value; }
        }

        public Severities Severity
        {
            get { return Reflection.SafeConvertToEnum(SeverityVal, Severities.Medium); }
            set { SeverityVal = (Int16) value; }
        }

        public IncidentStatuses IncidentStatus
        {
            get { return Reflection.SafeConvertToEnum(IncidentStatusVal, IncidentStatuses.Created); }
            set { IncidentStatusVal = (Int16) value; }
        }

        public IList<string> LocationCoordinates
        {
            get
            {
                return _locationCoordinates ??
                       (_locationCoordinates =
                        new ObservableStringList(LocationCoordinatesStr, "LocationCoordinatesStr", this));
            }
        }

        public IList<string> Validate()
        {
            // this string list will be filled with messages.
            var incorrects = new List<string>();

            string msg;

            if (Crisis == null)
                incorrects.Add("Incident doesn't belong to any crisis.");

            if (DateCreated.Year < DateTime.Now.Year - 10 || DateCreated.Year > DateTime.Now.Year)
                incorrects.Add("Creation date is incorrect.");

            if (IncidentStatus == IncidentStatuses.Complete && DateClosed.HasValue == false)
                incorrects.Add("Completion date is not assigned.");

            if (LocationCoordinates.Count == 0)
                incorrects.Add("Incident location is not defined.");

            if (!Validation.Check(Explanation, 3, 500, out msg, ValRules._AllowAll,ValRules._StartsWith_abc))
                incorrects.Add("Explanation is not correct! " + msg);

            if (!Validation.Check(ShortDescription, 3, 50, out msg, ValRules._abc,ValRules._123,ValRules._Space,ValRules._Punc))
                incorrects.Add("Short description is not valid! " + msg);

            if (NeedItems == null || NeedItems.Count==0)
            {
                incorrects.Add("There should be at least one need item.");
            }
            else
                foreach (var needItem in this.NeedItems)
                {
                    if (string.IsNullOrEmpty(needItem.ItemType))
                    {
                        incorrects.Add("One of the need items has no item type.");
                        break;
                    }
                    if (needItem.ItemAmount == 0)
                    {
                        incorrects.Add("The item amont of " + needItem.ItemType + " need item can not be 0.");
                    }
                    if (needItem.SuppliedAmount >= needItem.ItemAmount)
                    {
                        incorrects.Add("Supplied amount can not be equal or greater than collected amount.");
                    }
                }


            return incorrects;
        }
    }
}