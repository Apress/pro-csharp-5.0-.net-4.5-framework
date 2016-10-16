using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun wwith Implicit Typing *****");

            DeclareImplicitVars();
            Console.WriteLine();
            LinqQueryOverInts();

            Console.ReadLine();
        }

        #region Explicit vs. Implicit variable declaration
        static void DeclareExplicitVars()
        {
            // Explicitly typed local variables
            // are declared as follows:
            // dataType variableName = initialValue;
            int myInt = 0;
            bool myBool = true;
            string myString = "Time, marches on...";
        }

        static void DeclareImplicitVars()
        {
            // Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }

        static void ImplicitTypingIsStrongTyping()
        {
            // The compiler knows "s" is a System.String.
            var s = "This variable can only hold string data!";
            s = "This is fine...";

            // Can invoke any member of the underlying type.
            string upper = s.ToUpper();

            // Error! Can't assign numerical data to a string!
            // s = 44;
        }
        #endregion

        #region LINQ using implicit typing
        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // LINQ query! 
            var subset = from i in numbers where i < 10 select i;

            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            // Hmm...what type is subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }
        #endregion
    }
}
