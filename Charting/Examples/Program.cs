using System;
using System.Windows.Forms;

namespace JIC.Charting.Examples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Chart2D_Example());
            //Application.Run(new AnimatedChart2D_Example());
        }
    }
}
