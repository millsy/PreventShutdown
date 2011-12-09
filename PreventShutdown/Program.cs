using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace PreventShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args.Length <= 3)
            {
                string process = args[0];

                string processArgs = "";
                if (args.Length == 2)
                {
                    processArgs = args[1];
                }

                int timeout = 5000;
                if (args.Length == 3)
                {
                    timeout = int.Parse(args[2]);
                }

                PreventShutdownComponent.PreventShutdownComponent c = new PreventShutdownComponent.PreventShutdownComponent();
                Process p = Process.Start(process, processArgs);

                Thread.Sleep(timeout);

                c.DenyUserAccessToProcess(p.Handle);
            }
            else
            {
                MessageBox.Show("Usage: PreventShutdown.exe [path to executable to launch] [arguments] [timeout in ms]\ne.g. PreventShutdown.exe notepad.exe myfile.exe 1000");
            }
        }
    }
}
