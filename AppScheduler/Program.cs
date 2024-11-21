using System;
using System.Windows.Forms;
using AppScheduler.UI; // Ensure this namespace matches where MainForm is located

namespace AppScheduler
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // Ensure MainForm is in the correct namespace
        }
    }
}
