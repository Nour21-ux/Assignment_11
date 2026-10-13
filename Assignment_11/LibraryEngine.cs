using System;
using System.Collections.Generic;
using System.Text;
using static Assignment_11.LibraryEngine;

namespace Assignment_11
{
    public delegate string bookfunctiondeleget(Book B);
    public class LibraryEngine
    {
       
        public static void ProcessBooks1(List<Book> bList, bookfunctiondeleget fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
