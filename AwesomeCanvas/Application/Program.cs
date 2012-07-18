using System;
//using System.Collections;
//using System.Linq
//using System.Windows.Forms;
using System.Windows.Forms;
namespace AwesomeCanvas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           System.Windows.Forms.Application.EnableVisualStyles();
           System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
           System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}
    