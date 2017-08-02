using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpcDaLib;

namespace Слежение_за_измерениями_контроллеров
{
    
    static class Program
    {
        public static OPC[] AllObjects;
        public static object OPCLock = new object();
        public static int MainWindowState = 1;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
