using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace EnumerateMachineDataWF
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, object> wfArgs = new Dictionary<string, object>();
                wfArgs.Add("UserName", "Mel");
                Activity workflow1 = new Workflow1();
                WorkflowInvoker.Invoke(workflow1, wfArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data["Reason"]);
            }
        }

    }
}
