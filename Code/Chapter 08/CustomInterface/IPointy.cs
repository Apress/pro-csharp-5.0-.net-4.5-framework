using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // This interface defines the behavior of "having points."
    /*
    public interface IPointy
    {
        // Implicitly public and abstract.
        byte GetNumberOfPoints();
    }
    */

    // The pointy behavior as a read-only property.
    public interface IPointy
    {
        // A read-write property in an interface would look like:
        // retType PropName { get; set; }
        // while a write-only property in an interface would be:
        // retType PropName { set; }

        byte Points { get; }
    }

}
