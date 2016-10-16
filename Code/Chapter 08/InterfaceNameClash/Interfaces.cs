using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    // Draw image to a Form.
    public interface IDrawToForm
    {
        void Draw();
    }

    // Draw to buffer in memory.
    public interface IDrawToMemory
    {
        void Draw();
    }

    // Render to the printer.
    public interface IDrawToPrinter
    {
        void Draw();
    }
}
