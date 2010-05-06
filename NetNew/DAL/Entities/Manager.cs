using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Enumerations;

namespace DAL
{
    public partial class Manager
    {
        private IList<string> _expertiseCrisisTypes=null;

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
            // TODO: Modify the error messages with better ones.

            // this string list will be filled with messages.
            List<string> incorrects = new List<string>();
           
            
            /*
             * Explanation of Utils.Validation.Check method:
             * This method is used to check for many rules at one time.
             * First three parameter are mandatory. They are string to be checked, minlength and max length.
             * Remaining parameters are optional. For example, if value can only be consist of letters
             * use like this: Utils.Validation.Check(NameLastName, 5, 50, ValRules._abc)
             * Or value can only be consist of letters, numbers and spaces then use this:
             * Utils.Validation.Check(NameLastName, 5, 50, ValRules._abc,ValRules._123,ValRules._Space)
             * 
             */
            if (!Utils.Validation.Check(NameLastName, 5, 50, ValRules._abc,ValRules._Space))
                incorrects.Add("Name/Lastname can only be 5 to 50 long letters");

            if (this.Address.City == "" || this.Address.Country == "")
                incorrects.Add("Country and city can not be empty");

            if (!Utils.Validation.Check(UserName, 4, 16, ValRules._abc))
                incorrects.Add("User name can only be 4 to 16 long letters");

            //password can be anything
            //if (!Utils.Validation.Check(this.Password,3,16))
            //    incorrects.Add("Password should be min. 3, max. 16 long");

            if (this.ExpertiseCrisisTypes.Count==0)
                incorrects.Add("At least one crisis expertise area is required");

            return incorrects;
        }
    }
}
