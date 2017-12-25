using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Planet_Forge_AGAIN.window;

namespace The_Planet_Forge_AGAIN
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new OpenGLMainWindow().Run(60);
        }
    }
}
