using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMSCORE.EntityClasses;
using VMSCORE.Util;
using System.Collections.ObjectModel;

namespace VMSCORE.Operations
{
    /// <summary>
    /// All of the operations are done in Operations Claseses.
    /// </summary>
    public class CrisisOperations
    {
        public static Crisis CreateCrisis(string name, string explanation,EnumCrisisType ctype, EnumLocationType locationType
            ,ObservableCollection<string> locationCoordinates)
        {
            var c = new Crisis();
            c.Name = ConvertUtil.SafeString(name);
            c.Explanation = ConvertUtil.SafeString(explanation);
            if (locationCoordinates!=null)
            {
                c.LocationCoordinates = locationCoordinates;
            }
            c.DateCreated = DateTime.Now;
            c.Status = EnumCrisisStatus.Active;
            c.LocationType = locationType;


            Container.Instance.Crises.AddObject(c);
            Container.Instance.SaveChanges();

            return c;
        }

        public static void UpdateCrisis(int id, string name, string explanation, EnumCrisisType ctype, EnumLocationType enumLocationType, ObservableCollection<string> coords)
        {
            //Getting the object to be modified
            var c = Container.Instance.Crises.FirstOrDefault(cr => cr.Id == id);
            if (c==null)
            {
                throw new VMSException("there is no crisis with such an id");
            }                        
            //Setting new values
            c.Name = ConvertUtil.SafeString(name);
            c.Explanation = ConvertUtil.SafeString(explanation);
            if (coords != null)
            {
                c.LocationCoordinates = coords;
            }
            c.Status = EnumCrisisStatus.Active;
            c.LocationType = enumLocationType;

            //Reflecting to DB
            Container.Instance.SaveChanges();

        }
    }
}
