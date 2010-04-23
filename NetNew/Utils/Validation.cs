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
        /// <param name="rules">Allowed rules for validation. Enter rules separeted by comma</param>
        /// <returns></returns>
        public static bool Check(string val, int minLength, int maxLength, params Utils.Enumerations.ValRules[] rules)
        {
            if (val.Length<minLength || val.Length>maxLength)
            {
                return false;
            }

            if (!rules.Contains(Enumerations.ValRules._StartsWith_abc) && !Char.IsLetter(val[0]))
                return false;
            if( rules.Length>0)
                foreach (char c in val)
                {
                    if (!rules.Contains(Enumerations.ValRules._123) && Char.IsDigit(c))
                        return false;

                    if (!rules.Contains(Enumerations.ValRules._abc) && Char.IsLetter(c))
                        return false;

                    if (!rules.Contains(Enumerations.ValRules._Space) && Char.IsWhiteSpace(c))
                        return false;

                    if (!rules.Contains(Enumerations.ValRules._SpeChars) && Char.IsSymbol(c))
                        return false;

                    if (!rules.Contains(Enumerations.ValRules._SpeChars) && Char.IsPunctuation(c))
                        return false;

                }
            

            return true;
        }
    }
}
