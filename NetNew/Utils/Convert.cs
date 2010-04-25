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

        /// <summary>
        /// <para>Converts the given string to double. </para>
        /// <para>Doesnt throw exception if the parameter is not a double. Instead returns defaultVal.</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(string value,double defaultVal)
        {
            double tmp = 0;
            if (!double.TryParse(SafeString(value), out tmp))
                tmp = defaultVal;

            return tmp;

        }

        /// <summary>
        /// <para>Converts the given string to int. </para>
        /// <para>Does not throw exception if the parameter is not a int. Instead returns defaultVal.</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt(string value, int defaultVal)
        {
            int tmp = 0;
            if (!Int32.TryParse(SafeString(value), out tmp))
                tmp = defaultVal;

            return tmp;

        }

    }
}
