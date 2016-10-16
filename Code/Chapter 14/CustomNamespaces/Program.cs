using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyShapes;
using threeD = Chapter14.My3DShapes;

using bfHome = System.Runtime.Serialization.Formatters.Binary;

namespace CustomNamespaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is no output to show here....");
            Console.WriteLine("This project just illustrates how to package");
            Console.WriteLine("up custom types in namespaces.\n");
            /*
            Hexagon h = new Hexagon();
            Circle c = new Circle();
            Square s = new Square();
            */

            /*
            MyShapes.Hexagon h = new MyShapes.Hexagon();
            MyShapes.Circle c = new MyShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();
            */

            threeD.Hexagon h = new threeD.Hexagon();
            threeD.Circle c = new threeD.Circle();
            MyShapes.Square s = new MyShapes.Square();

            bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
        }
    }
}
