using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BEntities
{
    public class Manager:DAL.Manager
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
    }
}
