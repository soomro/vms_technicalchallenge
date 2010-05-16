using System.Collections.Generic;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class Manager
    {
        private IList<string> _expertiseCrisisTypes;

        public IList<string> ExpertiseCrisisTypes
        {
            get
            {
                return _expertiseCrisisTypes ??
                       (_expertiseCrisisTypes =
                        new ObservableStringList(ExpertiseCrisisTypesStr, "ExpertiseCrisisTypesStr", this));
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
            var incorrects = new List<string>();


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
            string msg;
            if (!Validation.Check(NameLastName, 5, 50, out msg, ValRules._abc, ValRules._Space))
                incorrects.Add("Name / Lastname is not correct. " + msg);

            if (Address.City == "" || Address.Country == "")
                incorrects.Add("Country and city can not be empty");

            if (!Validation.Check(UserName, 4, 16, out msg, ValRules._abc))
                incorrects.Add("User name is not correct. " + msg);

            if (!Validation.Check(Password, 3, 16, out msg))
                incorrects.Add("Password should be min. 3, max. 16 long");

            if (ExpertiseCrisisTypes.Count == 0)
                incorrects.Add("At least one crisis expertise area is required");

            return incorrects;
        }
    }
}