using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface 
{
    // The abstract base class of the hierarchy.
    abstract class Shape
    {
        public Shape( string name = "NoName" )
        { PetName = name; }
        public Shape() {}

        public string PetName { get; set; }

        // A single virtual method.
        // Force all child classes to define how to be rendered.
        public abstract void Draw();

    }
}
