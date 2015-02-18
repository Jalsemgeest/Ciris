using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ciris
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Adding a potential Exception to the program.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Checking the bit mode of the OS.
            if (NativeMethods.IsX86InWow64Mode())
            {
                System.Windows.Forms.MessageBox.Show(@"This was compiled for 32 bit processors.");
                return;
            }

            // Checking windows version
            if (Environment.OSVersion.Version < new Version(6, 1))
            {
                System.Windows.Forms.MessageBox.Show(@"This only works on Windows 7 and above.",
                    "Warning",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1);
                return;
            }

            // Changes the working directory to be the one with the executable.
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // Initializes the configuration of the program.
            Configuration.Initialize();

            // Check if Aero is enabled.
            if (Configuration.Current.ShowAeroWarning && !NativeMethods.DwmIsCompositionEnabled())
            {
                var result = System.Windows.Forms.MessageBox.Show("Windows Aero must be anled for this program.");
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
            }

            // Check if there is another instance running.
            if (IsAnotherInstanceAlreadyRunning())
            {
                System.Windows.Forms.MessageBox.Show("The application is already running.",
                    "Warning",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1);
                return;
            }

            NativeMethods.SetProcessDPIAware();

            Application.EnableVisualStyles();
            OverlayManager.Initialize();

            Application.Run();
        }

        // Handling the custom exception for the application.
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString(), "Sorry, crashing...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private static bool IsAnotherInstanceAlreadyRunning()
        {
            Process p = Process.GetCurrentProcess();

            Process[] processWithSameName = Process.GetProcessesByName(p.ProcessName);

            if (processWithSameName.Length == 1)
            {
                return false;
            }

            foreach (Process process in processWithSameName)
            {
                if (process.Id != p.Id && process.MainModule.FileName == p.MainModule.FileName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
