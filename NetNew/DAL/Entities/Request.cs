using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Enumerations;

namespace DAL
{
    public partial class Request
    {
        public IList<string> Validate()
        {
            // this string list will be filled with messages.
            List<string> incorrects = new List<string>();

            string msg;
            if (!Utils.Validation.Check(this.Message, 3, 200, out msg, ValRules._AllowAll))
                incorrects.Add("The message is not correct! " + msg);

            if (!Utils.Validation.Check(this.Name, 3, 30, out msg, ValRules._AllowAll))
                incorrects.Add("The name is not correct! " + msg);
            if (NeedItems.Count==0)
                incorrects.Add("It must be contain at least one need item.");

            return incorrects;
        }

    }
}
