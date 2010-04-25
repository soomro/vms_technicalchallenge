using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Utils.Exceptions;

namespace BLL.BWorkflows
{
    public class CrisisOperations
    {
        public static DAL.Crisis CreateCrisis(string name, string explanation, Utils.Enumerations.CrisisTypes ctype, Utils.Enumerations.LocationTypes locationType
           , ObservableCollection<string> locationCoordinates)
        {
            var c = new DAL.Crisis();
            c.Name = Utils.Convert.SafeString(name);
            c.Explanation = Utils.Convert.SafeString(explanation);
            if (locationCoordinates != null)
            {
                c.LocationCoordinatesStr=Utils.Collection.ToString<string>(locationCoordinates);
            }
            c.DateCreated = DateTime.Now;
            c.StatusVal = (short)Utils.Enumerations.CrisisStatuses.Active;
            c.LocationTypeVal = (short)locationType;
            c.CrisisTypeVal = (short)ctype;
            DAL.Container.Instance.Crises.AddObject(c);
            DAL.Container.Instance.SaveChanges();

            return (c);
        }


        public static DAL.Crisis UpdateCrisis(int id, string name, string explanation, Utils.Enumerations.CrisisTypes ctype, Utils.Enumerations.LocationTypes locationType, ObservableCollection<string> coords)
        {
            var c = DAL.Container.Instance.Crises.FirstOrDefault(cr => cr.Id == id);
            if (c == null)
            {
                throw new VMSException("there is no crisis with such an id");
            }
            //Setting new values
            c.Name = Utils.Convert.SafeString(name);
            c.Explanation = Utils.Convert.SafeString(explanation);
            c.LocationCoordinates.Clear();
            if (coords != null)
            {                
                foreach (var coord in coords)
                {
                    c.LocationCoordinates.Add(coord);
                }
            }
            c.StatusVal = (short)Utils.Enumerations.CrisisStatuses.Active;
            c.LocationTypeVal = (short)locationType;
            c.CrisisTypeVal = (short)ctype;
            //Reflecting to DB
            DAL.Container.Instance.SaveChanges();
          
            return (c);
        }

        public static bool CloseCrisis(int id)
        {

            var cr = DAL.Container.Instance.Crises.Single(c => c.Id == id);
            if (cr.Status == Utils.Enumerations.CrisisStatuses.Closed)
                throw new VMSException("Crisis is already closed");

            foreach (var inc in cr.Incidents)
            {
                if (inc.IncidentStatus!=Utils.Enumerations.IncidentStatuses.Complete)
                {
                    throw new VMSException("Crisis has incomplete incidents");
                }
            }

            cr.Status = Utils.Enumerations.CrisisStatuses.Closed;
            DAL.Container.Instance.SaveChanges();
            return true;
        }
    }
}
