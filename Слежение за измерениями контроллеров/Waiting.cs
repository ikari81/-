using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Слежение_за_измерениями_контроллеров
{
    public partial class Waiting : Form
    {
        public int ExitFlag;
        public Waiting()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ExitFlag == 1)
            {
                timer1.Stop();
                this.Close();
            }
            if (this.progressBar1.Value < this.progressBar1.Maximum)
            {
                {
                    this.progressBar1.Value += 1;
                    this.progressBar1.Refresh();
                    this.progressBar1.Value -= 1;
                    this.progressBar1.Refresh();
                    this.progressBar1.Value += 1;
                    this.progressBar1.Refresh();
                }

            }
            else
            {
                this.progressBar1.Value = 0;
                this.progressBar1.Refresh();
            }
        }

        private void Waiting_Shown(object sender, EventArgs e)
        {
            this.progressBar1.Maximum = 100;
            timer1.Start();
        }
    }
}
