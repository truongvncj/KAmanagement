using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAmanagement.shared
{
    public static class StringExtensions
    {

       
            public static string Right(this string str, int length)
            {
                return str.Substring(str.Length - length, length);






            }

        public static string Truncate(this string source, int length)
        {
            if (source != null)
            {
                if (source.Length > length)
                {
                    return source.Substring(0, length);
                }
                return source;
            }
            else
            {
                return " ";
            }

        }
    }
}
