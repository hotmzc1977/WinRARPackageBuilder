using System;
using System.Collections.Generic;
using System.Text;

namespace PkgBuilder
{
    
    class clsRAR
    {
        private string sType;
        private string sOutputFile;
        private string[] sInputFiles;
        private string sFolder;
        private string sCurPath;
        //private string sWinRARPath;

        public static string CONFIG_FILE = "PkgBuilder.ini";
        public static string CATEGORY_PATH = "PATH";
        public static string KEY_WINRAR = "WINRAR";
        

        public clsRAR() 
        {
            
        }

        public void setType(string s)
        {
            sType = s;
        }

        public void setOutputFile(string s)
        {
            sOutputFile = s;
        }

        public void setInputFile(string[] s)
        {
            sInputFiles = s;
        }

        public void setFolder(string s)
        {
            sFolder = s;
        }

        public void setCurPath(string s)
        {
            sCurPath = s;
        }

        public void DoCompress()
        {
            string cmd;
            string args;
            cmd = INI.GetIniFileString(sCurPath + clsRAR.CONFIG_FILE, clsRAR.CATEGORY_PATH, clsRAR.KEY_WINRAR, "");
            if  (System.IO.File.Exists(cmd) ==  false)
            {
                if (sType == "RAR")
                {
                    cmd = sCurPath + "Rar.exe";
                    if (System.IO.File.Exists(cmd) == false)
                        return;
                }
                else
                    return;
            }

            args = "a "+ ((sType=="RAR")?"":" -afzip ") +" \"-ap" + sFolder + "\" -ep \"" + sOutputFile + "\" " + getFileString(sInputFiles);
            Console.WriteLine(cmd + " " + args);
            CommandLine.ExecuteIt(cmd,args);
        }

        private string getFileString(string[] sf)
        {
            string sR = "";
            foreach (string s in sf)
            {
                sR = sR+" \"" + s + "\" ";
            }
            return sR;
        }

    }
}
