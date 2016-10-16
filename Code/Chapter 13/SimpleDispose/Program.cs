using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Dispose *****\n");

            // Use a comma-delimited list to declare multiple objects to dispose.
            using (MyResourceWrapper rw = new MyResourceWrapper(),
                                    rw2 = new MyResourceWrapper())
            {
                // Use rw and rw2 objects.
            }
        }

        // Assume you have imported
        // the System.IO namespace...
        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);

            // Confusing, to say the least!
            // These method calls do the same thing!
            fs.Close();
            fs.Dispose();
        }
    }
}
