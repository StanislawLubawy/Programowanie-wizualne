using System;
using System.Windows.Forms;

namespace Gra_w_Hayraxy
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
