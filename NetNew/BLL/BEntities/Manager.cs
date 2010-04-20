using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BEntities
{
    //TODO: this class is not useful anymore and should be removed after confirmation of Abdullah
    public class Manager: DAL.Manager
    {
        public IList<string> _expertiseCrisisTypes=null;

        public IList<string> ExpertiseCrisisTypes
        {
            get
            {
                if (_expertiseCrisisTypes==null)
                {
                    _expertiseCrisisTypes = new Utils.ObservableStringList(ExpertiseCrisisTypesStr, "ExpertiseCrisisTypesStr", this);
                }
                return _expertiseCrisisTypes;
            }
        }

        public DAL.Manager GetBase()
        {            
            return base.MemberwiseClone() as DAL.Manager;
        }

        
    }
}
 
