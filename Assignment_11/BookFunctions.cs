using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_11
{
    public class BookFunctions
    {

        public static string GetTitle(Book B)
        {
            return B.Title ?? string.Empty;
        }

        public static string GetAuthors(Book B)
        {
            if (B?.Authors == null) return string.Empty;
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B?.Price.ToString("C") ?? string.Empty;
        }
    }
}
