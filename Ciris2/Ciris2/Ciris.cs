
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ciris
{

    class Ciris
    {
        [STAThread]

        static void Main(string[] args)
        {


            // Only 32 bit mode is allowed.
            if (NativeMethods.IsX86InWow64Mode())
            {
                System.Windows.Forms.MessageBox.Show(@"Dang...");
                return;
            }

            //check Windows version
            //TODO: check whether the undocumented functions exist under Windows server 2008 (probably not) and R2 (probably yes)
            if (Environment.OSVersion.Version < new Version(6, 1))
            {
                System.Windows.Forms.MessageBox.Show(@"Dang 2...",
                 "Warning",
                 System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Exclamation,
                 System.Windows.Forms.MessageBoxDefaultButton.Button1);
                return;
            }

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            

        }
    }

}
