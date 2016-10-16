using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryEDMConsoleApp
{
    #region Extended Car data.
    public partial class Car
    {
        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return string.Format("{0} is a {1} {2} with ID {3}.",
                this.CarNickname ?? "**No Name**",
                this.Color, this.Make, this.CarID);
        }
        partial void OnCarNicknameChanging(global::System.String value)
        {
            Console.WriteLine("\t-> Changing name to: {0}", value);
        }
        partial void OnCarNicknameChanged()
        {
            Console.WriteLine("\t-> Name of car has been changed!");
        }
    }
    #endregion
}
