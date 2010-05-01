using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Utils
{
    public static class Reflection
    {
        public static T SafeConvertToEnum<T>(Int16 val, T def)
        {
            if (Enum.IsDefined(typeof(T), val))
            {
                return (T)Enum.ToObject(typeof(T), val);
            }
            else
            { return def; }
        }

        /// <summary>
        /// Retrieve the description on the enum,
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }
}
