using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace PkgBuilder
{
    class INI
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW",SetLastError = true,CharSet = CharSet.Unicode, ExactSpelling = true,CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString(string lpAppName,string lpKeyName,string lpDefault,string lpReturnString,int nSize,string lpFilename);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW",   SetLastError = true,   CharSet = CharSet.Unicode, ExactSpelling = true,   CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFilename);

        public static string GetIniFileString(string iniFile, string category, string key, string defaultValue)
         {
             string returnString = new string(' ', 1024);
             GetPrivateProfileString(category, key, defaultValue, returnString, 1024, iniFile);
             return returnString.Split('\0')[0];
         }

        public static void SetIniFileString(string iniFile, string category, string key, string defaultValue)
        {
            WritePrivateProfileString(category, key, defaultValue, iniFile);
        }

        
        public static List<string> GetCategories(string iniFile)
         {
             string returnString = new string(' ', 65536);
             GetPrivateProfileString(null, null, null, returnString, 65536, iniFile);
             List<string> result = new List<string>(returnString.Split('\0'));
             result.RemoveRange(result.Count - 2, 2);
             return result;
         }


        public static List<string> GetKeys(string iniFile, string category)
         {
             string returnString = new string(' ', 32768);
             GetPrivateProfileString(category, null, null, returnString, 32768, iniFile);
             List<string> result = new List<string>(returnString.Split('\0'));
             result.RemoveRange(result.Count-2,2);
             return result;
         }

        

    }
}
