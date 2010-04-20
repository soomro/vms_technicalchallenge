using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class Manager
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

        /// <summary>
        /// Checks all the compulsory fields, returns a string collection containing all the incorrect fields.
        /// </summary>
        /// <returns></returns>
        public IList<string> Validate()
        {
            List<string> incorrects = new List<string>();

            if (!Utils.Validation.Check(NameLastName, 5, 50,"a-z"," ","1-9"))
                incorrects.Add("Name/Lastname can be only letters");

            if (this.Address.City == "")
                incorrects.Add("City can not be empty");

            

            // testing
            incorrects.Add("this test message. name is incorrect");
            incorrects.Add("this test message. age is incorrect");

            return incorrects;
        }
    }
}
