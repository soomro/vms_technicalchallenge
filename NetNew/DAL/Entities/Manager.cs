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
            // this string list will be filled with messages.
            List<string> incorrects = new List<string>();

            if (!Utils.Validation.Check(NameLastName, 5, 50,"a-z"," ","1-9"))
                incorrects.Add("Name/Lastname can only be letters");

            if (this.Address.City == "" || this.Address.Country == "")
                incorrects.Add("Country and city can not be empty");

            if (string.IsNullOrEmpty(this.UserName))
                incorrects.Add("Username can not be empty");

            
            if (string.IsNullOrEmpty(this.Password))
                incorrects.Add("Password can not be empty");

            if (this.ExpertiseCrisisTypes.Count==0)
                incorrects.Add("At least one crisis expertise area is required");

            return incorrects;
        }
    }
}
