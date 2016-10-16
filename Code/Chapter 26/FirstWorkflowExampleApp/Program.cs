using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading;

namespace FirstWorkflowExampleApp
{

    class Program
    {
        #region Using WorkflowInvoker
        // Rename to Main and comment Main() below to use WorkflowInvoker.
        static void OLD_Main(string[] args)
        {
            Console.WriteLine("***** Welcome to this amazing WF application *****");

            // Get data from user, to pass to workflow. 
            Console.Write("Please enter the data to pass the workflow: ");
            string wfData = Console.ReadLine();

            // Package up the data as a dictionary. 
            Dictionary<string, object> wfArgs = new Dictionary<string, object>();
            wfArgs.Add("MessageToShow", wfData);

            // Pass to the workflow. 
            Activity workflow1 = new Workflow1();
            WorkflowInvoker.Invoke(workflow1, wfArgs);

            Console.WriteLine("Thanks for playing");
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to this amazing WF application *****");

            // Get data from user, to pass to workflow. 
            Console.Write("Please enter the data to pass the workflow: ");
            string wfData = Console.ReadLine();

            // Package up the data as a dictionary. 
            Dictionary<string, object> wfArgs = new Dictionary<string, object>();
            wfArgs.Add("MessageToShow", wfData);

            // Used to inform primary thread to wait!
            AutoResetEvent waitHandle = new AutoResetEvent(false);

            // Pass to the workflow. 
            WorkflowApplication app = new WorkflowApplication(new Workflow1(), wfArgs);

            // Hook up an event with this app. 
            // When I’m done, notifiy other thread I’m done,
            // and print a message.
            app.Completed = (completedArgs) =>
            {
                waitHandle.Set();
                Console.WriteLine("The workflow is done!");
            };

            // Start the workflow! 
            app.Run();

            // Wait until I am notified the workflow is done.
            waitHandle.WaitOne();

            Console.WriteLine("Thanks for playing");
        }

    }
}
