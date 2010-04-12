using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Convert
    {
        /// <summary>
        /// <para>Returns empty string if the parameter is null.</para>
        /// <para>Returns the Trimmed version of rawString</para>
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns></returns>
        public static string SafeString(string rawString)
        {
            if (string.IsNullOrEmpty(rawString))
            {
                return "";
            }
            return rawString.Trim();
        }
    }
}
