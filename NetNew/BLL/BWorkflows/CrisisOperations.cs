using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DAL;
using Utils;
using Utils.Enumerations;
using Utils.Exceptions;
using Convert = Utils.Convert;

namespace BLL.BWorkflows
{
    public class CrisisOperations
    {
        public static Crisis CreateCrisis(string name, string explanation, CrisisTypes ctype, LocationTypes locationType
                                          , ObservableCollection<string> locationCoordinates)
        {
            var c = new Crisis();
            c.Name = Convert.SafeString(name);
            c.Explanation = Convert.SafeString(explanation);
            if (locationCoordinates != null)
            {
                c.LocationCoordinatesStr = Collection.ToString(locationCoordinates);
            }
            c.DateCreated = DateTime.Now;
            c.StatusVal = (short) CrisisStatuses.Active;
            c.LocationTypeVal = (short) locationType;
            c.CrisisTypeVal = (short) ctype;

            //  validate fields 
            IList<string> valRes = c.Validate();
            if (valRes.Count > 0)
            {
                throw new VMSException(valRes);
            }

            Container.Instance.Crises.AddObject(c);
            Container.Instance.SaveChanges();


            return (c);
        }

        public static Crisis UpdateCrisis(int id, string name, string explanation, CrisisTypes ctype,
                                          LocationTypes locationType, ObservableCollection<string> coords)
        {
            Crisis c = Container.Instance.Crises.FirstOrDefault(cr => cr.Id == id);
            if (c == null)
                throw new VMSException("There is no crisis with such an id");

            //Setting new values
            c.Name = Convert.SafeString(name);
            c.Explanation = Convert.SafeString(explanation);
            c.LocationCoordinates.Clear();

            if (coords != null)
                foreach (string coord in coords)
                    c.LocationCoordinates.Add(coord);

            c.StatusVal = (short) CrisisStatuses.Active;
            c.LocationTypeVal = (short) locationType;
            c.CrisisTypeVal = (short) ctype;


            //  validate fields 
            IList<string> valRes = c.Validate();
            if (valRes.Count > 0)
                throw new VMSException(valRes);

            //Reflecting to DB
            Container.Instance.SaveChanges();

            return (c);
        }


        public static bool CloseCrisis(int id)
        {
            Crisis cr = Container.Instance.Crises.Single(c => c.Id == id);
            if (cr.Status == CrisisStatuses.Closed)
                throw new VMSException("Crisis is already closed");

            if (cr.Incidents.Any(inc => inc.IncidentStatus != IncidentStatuses.Complete))
            {
                throw new VMSException("Crisis has incomplete incidents");
            }

            cr.Status = CrisisStatuses.Closed;
            Container.Instance.SaveChanges();
            return true;
        }
    }
}