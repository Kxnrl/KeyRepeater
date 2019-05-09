using System;
using System.Runtime.InteropServices;
using System.Text;

namespace KeyRepeater.Utils
{
    class Win32Api
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        public static string GetIniSectionValue(string file, string section, string key)
        {
            var stringBuilder = new StringBuilder(1024);
            GetPrivateProfileString(section, key, null, stringBuilder, 1024, file);
            return stringBuilder?.ToString();
        }

        public static bool SetIniSectionValue(string file, string section, string key, string value)
        {
            return WritePrivateProfileString(section, key, value, file);
        }
    }
}
