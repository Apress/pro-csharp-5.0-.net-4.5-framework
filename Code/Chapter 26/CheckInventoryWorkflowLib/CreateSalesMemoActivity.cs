using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CheckInventoryWorkflowLib
{
    public sealed class CreateSalesMemoActivity : CodeActivity
    {
        // Two properties for the custom activity
        public InArgument<string> Make { get; set; }
        public InArgument<string> Color { get; set; }

        // If the activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Dump a message to a local text file.
            StringBuilder salesMessage = new StringBuilder();
            salesMessage.AppendLine("***** Attention sales team! *****");
            salesMessage.AppendLine("Please order the following ASAP!");
            salesMessage.AppendFormat("1 {0} {1}\n",
              context.GetValue(Color), context.GetValue(Make));
            salesMessage.AppendLine("*********************************");

            System.IO.File.WriteAllText("SalesMemo.txt", salesMessage.ToString());
        }
    }
}
