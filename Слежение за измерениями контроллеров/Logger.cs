using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Слежение_за_измерениями_контроллеров
{
    public class Logger
    {
        private static readonly Logger m_instance = new Logger();
        public string Name { get; private set; }
        private StreamWriter sw;
        private static readonly object s_lock = new object();

        public static Logger GetInstance()
        {
            return m_instance;
        }

        static void DestroyInstance()
        {
            if (m_instance != null) m_instance.Dispose();
        }

        protected Logger()
        {
            Name = System.Guid.NewGuid().ToString();
        }
        void Dispose()
        { }

        public void AppendLog(string message)
        {

            FileInfo fi;
            try
            {
                lock (s_lock)
                {
                    fi = new FileInfo(@AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString().Split(' ')[0] + " - log.txt");
                    sw = fi.AppendText();
                    sw.WriteLine(DateTime.Now.ToString() + " " + message);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
