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
            
           

            if (!Utils.Validation.Check(NameLastName, 5, 50, ValRules._abc))
                incorrects.Add("Name/Lastname can only be 5 to 50 long letters");

            if (BirthDate.GetType() != System.Type.GetType("System.DateTime"))
                incorrects.Add("Bithday feild is not valid");

            if (!Utils.Validation.Check(Occupation, 5, 50, ValRules._abc))
                incorrects.Add("Occupation can only be 5 to 50 long letters");

            if (this.Address.City == "" || this.Address.Country == "")
                incorrects.Add("Country and city can not be empty");
            
            if (!Utils.Validation.Check(EduAndTrainings, 5, 50, ValRules._abc))
                incorrects.Add("Education and Training feild can only be 5 to 50 long letters");

            if (!Utils.Validation.Check(Username, 4, 16, ValRules._abc))
                incorrects.Add("Username can only be 4 to 16 long letters");
            
            if (!Utils.Validation.Check(this.Password, 3, 16))
                incorrects.Add("Password should be min. 3, max. 16 long");

            if (!Utils.Validation.Check(EmailAddr, 5, 50, ValRules._abc))
                incorrects.Add("Email feild can only be 5 to 50 long letters");

            if ((Weight.GetType() != System.Type.GetType("System.Decimal")))
                incorrects.Add("Enter correct weight");

            if ((Height.GetType() != System.Type.GetType("System.Decimal")))
                incorrects.Add("Enter correct height");

            if (!Utils.Validation.Check(HealthProb, 5, 50, ValRules._abc))
                incorrects.Add("'Health Problems' feild can only be 5 to 50 long letters");

            if (!Utils.Validation.Check(Phone, 7, 15, ValRules._abc))
                incorrects.Add("'phone' feild can only be 7 to 15 long");


            return incorrects;
        }
    }

}
