using System;
using System.Windows.Forms;

namespace gra_w_Hyraxy
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StartForm());
        }
    }
}
