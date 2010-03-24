using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMSCORE.EntityClasses;
using VMSCORE.Util;

namespace VMSCORE.Operations
{
    public class CrisisOperations
    {
        public static Crisis CreateCrisis(string name, string explanation,EnumCrisisType ctype, EnumLocationType locationType
            ,IList<string> locationCoordinates)
        {
            var c = new Crisis();
            c.Name = ConvertUtil.SafeString(name);
            c.Explanation = ConvertUtil.SafeString(explanation);
            if (locationCoordinates!=null)
            {
                foreach (var item in locationCoordinates)
                {
                    c.LocationCoordinates.Add(item);
                }
            }
            c.DateCreated = DateTime.Now;
            c.Status = EnumCrisisStatus.Active;
            c.LocationType = locationType;
            
            EntityModelContainer cont = new EntityModelContainer();
            cont.Crises.AddObject(c);
            cont.SaveChanges();

            return c;
        }
    }
}
