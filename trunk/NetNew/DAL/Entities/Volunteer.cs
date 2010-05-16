using System.Collections.Generic;
using Utils;
using Utils.Enumerations;

namespace DAL
{
    public partial class Volunteer
    {
        public IList<string> _Coordinates;

        public Gender Gender
        {
            get { return (Gender) GenderVal; }
            set { GenderVal = (short) value; }
        }

        public IList<string> Coordinates
        {
            get
            {
                return _Coordinates ??
                       (_Coordinates = new ObservableStringList(CoordinatesStr, "CoordinatesStr", this));
            }
        }

        public IList<string> Validate()
        {
            // this string list will be filled with messages.
            var incorrects = new List<string>();


            string msg;
            if (!Validation.Check(NameLastName, 5, 50, out msg, ValRules._abc, ValRules._Space))
                incorrects.Add("Name/Lastname is not valid. " + msg);


            if (Address == null || Address.City == "" || Address.Country == "")
                incorrects.Add("Country and city can not be empty");


            if (!Validation.Check(Username, 4, 16, out msg, ValRules._abc, ValRules._123))
                incorrects.Add("Username is not valid. " + msg);

            if (!Validation.Check(Password, 3, 16, out msg))
                incorrects.Add("Password should be min. 3, max. 16 long");

            return incorrects;
        }
    }
}