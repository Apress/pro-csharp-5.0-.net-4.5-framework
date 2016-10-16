using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserShoppingCart
/// </summary>
public class UserShoppingCart
{
    public string DesiredCar { get; set; }
    public string DesiredCarColor { get; set; }
    public float DownPayment { get; set; }
    public bool IsLeasing { get; set; }
    public DateTime DateOfPickUp { get; set; }

    public override string ToString()
    {
        return string.Format
         ("Car: {0}<br>Color: {1}<br>$ Down: {2}<br>Lease: {3}<br>Pick-up Date: {4}",
           DesiredCar, DesiredCarColor, DownPayment, IsLeasing,
           DateOfPickUp.ToShortDateString());
    }
}
