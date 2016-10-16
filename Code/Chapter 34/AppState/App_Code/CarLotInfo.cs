using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class CarLotInfo
{
    public CarLotInfo(string s, string c, string m)
    {
        SalesPersonOfTheMonth = s;
        CurrentCarOnSale = c;
        MostPopularColorOnLot = m;
    }
    public string SalesPersonOfTheMonth { get; set; }
    public string CurrentCarOnSale { get; set; }
    public string MostPopularColorOnLot { get; set; }
}
