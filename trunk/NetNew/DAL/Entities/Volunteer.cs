using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Enumerations;

namespace DAL
{
    public partial class Volunteer
    {
        public Utils.Enumerations.Gender Gender
        {
            get
            {
                return (Utils.Enumerations.Gender)this.GenderVal ;
            }
            set
            {
                this.GenderVal = (short)value;
            }
        }
        
        public IList<string> Validate()
        {
            // TODO: Modify the error messages with better ones.

            // this string list will be filled with messages.
            List<string> incorrects = new List<string>();


            string msg;
            if (!Utils.Validation.Check(NameLastName, 5, 50,out msg, ValRules._abc,ValRules._Space))
                incorrects.Add("Name/Lastname is not valid. "+msg);

           
            if (this.Address==null || this.Address.City == "" || this.Address.Country == "")
                incorrects.Add("Country and city can not be empty");
          

            if (!Utils.Validation.Check(Username, 4, 16,out msg, ValRules._abc,ValRules._123))
                incorrects.Add("Username is not valid. "+msg);
            
            if (!Utils.Validation.Check(this.Password, 3, 16,out msg))
                incorrects.Add("Password should be min. 3, max. 16 long");

            return incorrects;
        }

        public IList<string> _Coordinates;
        public IList<string> Coordinates
        {
            get
            {
                if (_Coordinates == null)
                {
                    _Coordinates = new Utils.ObservableStringList(CoordinatesStr, "CoordinatesStr", this);
                }
                return _Coordinates;
            }
        }
    }

}
