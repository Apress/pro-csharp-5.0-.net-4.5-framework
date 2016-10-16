using System;
using System.Linq;
using System.Activities;
using System.Collections.Generic;
using CheckInventoryWorkflowLib;

namespace WorkflowLibraryClient
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Inventory Look up ****");
            
            // Get user preferences.
            Console.Write("Enter Color: ");
            string color = Console.ReadLine();
            Console.Write("Enter Make: "); 
            string make = Console.ReadLine();

            // Package up data for workflow.
            Dictionary<string, object> wfArgs = new Dictionary<string, object>()
            {
                {"RequestedColor", color},
                {"RequestedMake", make}
            };

            try
            {
                // Send data to workflow!
                IDictionary<string, object> outputArgs =
                    WorkflowInvoker.Invoke(new CheckInventory(), wfArgs);
                Console.WriteLine(outputArgs["FormattedResponse"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
