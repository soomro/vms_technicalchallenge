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
    }
}
