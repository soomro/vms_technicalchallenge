using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Exceptions;

namespace BLL.BWorkflows
{
    public static class IncidentOperations
    {
        public static bool CloseIncident(int id)
        {
            var inc = DAL.Container.Instance.Incidents.SingleOrDefault(i => i.Id==id);
            if (inc==null)
            {
                throw new VMSException("Incident could not be found!");
            }

            inc.IncidentStatus = Utils.Enumerations.IncidentStatuses.Complete;
            DAL.Container.Instance.SaveChanges();
            Utils.Log.BLLogger.Info("Incident is closed:"+inc.ID); 
            return true;
        }
    }
}
