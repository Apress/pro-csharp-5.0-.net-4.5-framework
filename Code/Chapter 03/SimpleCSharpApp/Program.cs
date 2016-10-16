using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        // Note we are now returning an int, rather than void.
        static int Main(string[] args)
        {
            // Display a message and wait for Enter key to be pressed.
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            #region Process any incoming command line args.
            // Process any incoming args.
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);

            /*
            // Process any incoming args using foreach.
            foreach (string arg in args)
                Console.WriteLine("Arg: {0}", arg);

            // Get arguments using System.Environment.
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);
            */
            #endregion

            // Helper method within the Program class.
            ShowEnvironmentDetails();

            Console.ReadLine();

            // Return an arbitrary error code.
            return -1;
        }

        #region Helper function to illustrate System.Environment.
        static void ShowEnvironmentDetails()
        {
            // Print out the drives on this machine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive);

            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}",
              Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}",
              Environment.Version);
        }
        #endregion
    }
}
