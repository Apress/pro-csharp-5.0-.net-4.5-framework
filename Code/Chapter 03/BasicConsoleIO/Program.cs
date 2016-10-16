using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Basic Console I/O *****");
            GetUserData();

            // John says...
            Console.WriteLine("{0}, Number {0}, Number {0}", 9);

            // Prints: 20, 10, 30
            Console.WriteLine("{1}, {0}, {2}", 10, 20, 30);

            FormatNumericalData();

            Console.ReadLine();
        }

        #region Gather some info about the user.
        static void GetUserData()
        {
            // Get name and age.
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            // Change echo color, just for fun.
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Echo to the console.
            Console.WriteLine("Hello {0}!  You are {1} years old.",
              userName, userAge);
 
            // Restore previous color.
            Console.ForegroundColor = prevColor;
        }
        #endregion

        #region Format flags.
        // Now make use of some format tags.
        static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);

            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
        }
        #endregion
    }
}
