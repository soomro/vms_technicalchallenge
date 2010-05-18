using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Validation
    {
        /// <summary>
        /// Checks the val for min/max length, and allowed rules.  
        /// </summary>
        /// <param name="val">Value to be checked</param>
        /// <param name="minLength">Min. length</param>
        /// <param name="maxLength">Max. length</param>
        /// <param name="msg">The error messages is returned by this output parameter</param>
        /// <param name="rules">Allowed rules for validation. Enter rules separeted by comma</param>
        /// <returns></returns>
        public static bool Check(string val, int minLength, int maxLength, out string msg, params Utils.Enumerations.ValRules[] rules)
        {
            val = val.Trim();
            if (val.Length < minLength || val.Length > maxLength)
            {
                msg = string.Format("The length should be [{0}-{1}]", minLength, maxLength);
                return false;
            }

            if (rules.Contains(Enumerations.ValRules._AllowAll) )
            {
                msg ="";
                return true;
            }

            if (rules.Contains(Enumerations.ValRules._StartsWith_abc) && !Char.IsLetter(val[0]))
            {
                msg = string.Format("It should start with a letter.");
                return false;
            }

            if( rules.Length>0)
                foreach (char c in val)
                {
                    if (!rules.Contains(Enumerations.ValRules._123) && Char.IsDigit(c))
                    {
                        msg = string.Format("It can not contain numeric letters.");
                        return false;
                    }

                    if (!rules.Contains(Enumerations.ValRules._abc) && Char.IsLetter(c))
                       {
                        msg = string.Format("It can not contain alphabet letters.");
                        return false;
                    }

                    if (!rules.Contains(Enumerations.ValRules._Space) && Char.IsWhiteSpace(c))
                        {
                        msg = string.Format("It can not contain spaces.");
                        return false;
                    }

                    if (!rules.Contains(Enumerations.ValRules._SpeChars) && Char.IsSymbol(c))
                       {
                        msg = string.Format("It can not contain symbols.");
                        return false;
                    }

                    if (!rules.Contains(Enumerations.ValRules._Punc) && Char.IsPunctuation(c))
                       {
                        msg = string.Format("It can not contain punctuation letters.");
                        return false;
                    }

                }

            msg = "";
            return true;
        }
    }
}
