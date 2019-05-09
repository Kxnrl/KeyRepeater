using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KeyRepeater
{
    static class Program
    {
        public static UI mainForm;
        public static HotKeyUI hotKeyUI;
        public static string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Kxnrl", "DNF");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mutex
            var self = new Mutex(true, "com.kxnrl.dnf.keyrepeater", out bool allow);
            if (!allow)
            {
                MessageBox.Show("已有一个实例在运行了...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            try
            {
                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }
            }
            catch { Environment.Exit(-1); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new UI();
            hotKeyUI = new HotKeyUI();

            Application.Run(mainForm);
        }
    }
}
