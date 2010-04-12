using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Utils
{
    /// <summary>
    /// The database stores string representation of some attributes. 
    /// This class helps converting arrays and string representation to each other.
    /// </summary>
    public static class Collection
    {
        /// <summary>
        /// Used to seperate array items in string representation.
        /// </summary>
        public const char SeparatorChar = (char)254;

        /// <summary>
        /// Converts a string representation of an array to actual array.
        /// </summary>
        /// <param name="itemsSeparatedByChar">Contains array items separeted by SeparatorChar</param>
        /// <returns>An array containing all the items in the string parameter.</returns>
        public static ObservableCollection<string> ToStrArray(string itemsSeparatedByChar)
        {
            if (itemsSeparatedByChar==null) return new ObservableCollection<string>();

            var items = itemsSeparatedByChar.Split(
                new char[]{SeparatorChar}
                ,StringSplitOptions.RemoveEmptyEntries);
            return new ObservableCollection<string>(items);
        }

        /// <summary>
        /// Converts a string representation of an array to actual array.
        /// </summary>
        /// <param name="itemsSeparatedByChar">Contains array items separeted by SeparatorChar</param>
        /// <returns>An array containing all the items in the string parameter.</returns>
        public static ObservableCollection<int> ToIntArray(string itemsSeparatedByChar)
        {
            var items = itemsSeparatedByChar.Split(
                new char[] { SeparatorChar }
                , StringSplitOptions.RemoveEmptyEntries);

            ObservableCollection<int> array = new ObservableCollection<int>();
            foreach (var item in items)
            {
                int temp= 0;
                if (Int32.TryParse(item, out temp))
                {
                    array.Add(temp);
                }
            }
            return array;
        }

        /// <summary>
        /// Converts a string representation of an array to actual array.
        /// </summary>
        /// <param name="itemsSeparatedByChar">Contains array items separeted by SeparatorChar</param>
        /// <returns>An array containing all the items in the string parameter.</returns>
        public static ObservableCollection<short> ToShortArray(string itemsSeparatedByChar)
        {
            var items = itemsSeparatedByChar.Split(
                new char[] { SeparatorChar }
                , StringSplitOptions.RemoveEmptyEntries);

            ObservableCollection<short> array = new ObservableCollection<short>();
            foreach (var item in items)
            {
                short temp= default(short);
                if (short.TryParse(item, out temp))
                    array.Add(temp);
            }
            return array;
        }

        /// <summary>
        /// Converts the array to a string that can be stored in the database.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>A string that contains all items separeted by a special character.</returns>
        public static string ToString<T>(IList<T> array)
        {
            string str = "" + SeparatorChar;

            foreach (var item in array)
            {
                str += item.ToString() + SeparatorChar;
            }
            return str;
        }

        
    }
}
