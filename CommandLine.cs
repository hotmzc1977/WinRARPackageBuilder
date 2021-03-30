using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PkgBuilder
{
    class CommandLine
    {
        public static void ExecuteIt(string Cmd, string args)
        {
            Process prc = new Process();
            prc.StartInfo.FileName = Cmd;
            prc.StartInfo.Arguments = args;
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.RedirectStandardOutput = true;
            prc.Start();
            prc.WaitForExit();
        }
    }
}
