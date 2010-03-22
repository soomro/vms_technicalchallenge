using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMSCORE.Util
{
    public static class ReflectionUtil
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
    }
}
