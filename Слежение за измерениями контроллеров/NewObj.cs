using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Слежение_за_измерениями_контроллеров
{
    public partial class NewObj : Form
    {
        public NewObj()
        {
            InitializeComponent();
            this.Text = "Добавление нового объекта";
            this.buttonSHLR.Enabled = false;
            this.buttonZN.Enabled = false;
        }

        void UpdateSHR_LR(string ID)
        {
            Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
            string[] res = new string[20];
            int count = 0;
            string SQL = "SELECT * FROM SHR_LR WHERE TC_id = " + ID;
            Dbase.GetDB(SQL, ref res, ref count);
            this.listViewSHR_LR.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                ListViewItem itm = new ListViewItem(new string[] { res[i].Split((char)1)[1], res[i].Split((char)1)[2] });
                this.listViewSHR_LR.Items.Add(itm);
            }
        }


        void UpdateZN(string ID)
        {
            Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
            string[] res = new string[10];
            int count = 0;
            string SQL = "SELECT * FROM ZN WHERE TC_id = " + ID;
            Dbase.GetDB(SQL, ref res, ref count);
            this.listViewZN.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                ListViewItem itm = new ListViewItem(new string[] { res[i].Split((char)1)[1], res[i].Split((char)1)[2] });
                this.listViewZN.Items.Add(itm);
            }
        }
        public NewObj(string Object,string ID)
        {
            InitializeComponent();
            this.Text = Object;
            Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
            string[] res = new string[1];
            int count = 0;
            string SQL = "SELECT * FROM Objects WHERE id = "+ ID;
            Dbase.GetDB(SQL, ref res, ref count);
            this.ObjectName.Text = res[0].Split((char)1)[1];
            this.ObjectTag.Text = res[0].Split((char)1)[2];
            this.ObjectCurrent.Text = res[0].Split((char)1)[3];
            this.ObjectPower.Text = res[0].Split((char)1)[5];
            this.ObjectQ.Text = res[0].Split((char)1)[4];
            this.Inversion.Checked = (res[0].Split((char)1)[6] == "1") ? true : false;
            this.Tag = ID;

            UpdateSHR_LR(ID);
            UpdateZN(ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputZNLR frm = new InputZNLR();
            frm.Text = "Добавление нового ШР/ЛР";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string SQL = "INSERT INTO SHR_LR(OPC_name,  OPC_Tag, inversion, TC_id) VALUES('" + frm.OPC_Name_Text.Text + "', '" + frm.OPC_Tag.Text + "'," +
                    (frm.checkBoxInversion.Checked? 1:0).ToString() + ", " + this.Tag.ToString() + ");";
                MessageBox.Show(SQL);
                Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
                if (!Dbase.AddToDB(SQL))
                    MessageBox.Show("Error LR");
                else
                    UpdateSHR_LR(this.Tag.ToString());

            }
        }

        private void buttonZN_Click(object sender, EventArgs e)
        {
            InputZNLR frm = new InputZNLR();
            frm.Text = "Добавление нового ЗН";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string SQL = "INSERT INTO ZN(OPC_name,  OPC_Tag, inversion, TC_id) VALUES('" + frm.OPC_Name_Text.Text + "', '" + frm.OPC_Tag.Text + "'," +
                    (frm.checkBoxInversion.Checked ? 1 : 0).ToString() + ", " + this.Tag.ToString() + ");";
                Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
                Dbase.AddToDB(SQL);
                UpdateZN(this.Tag.ToString());

            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                InputZNLR frm = new InputZNLR();
                frm.Text = "Добавление нового ШР/ЛР";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string SQL = "INSERT INTO SHR_LR(OPC_name,  OPC_Tag, inversion, TC_id) VALUES('" + frm.OPC_Name_Text.Text + "', '" + frm.OPC_Tag.Text + "'," +
                        (frm.checkBoxInversion.Checked ? 1 : 0).ToString() + ", " + this.Tag.ToString() + ");";
                    MessageBox.Show(SQL);
                    Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
                    if (!Dbase.AddToDB(SQL))
                        MessageBox.Show("Error LR");
                    else
                        UpdateSHR_LR(this.Tag.ToString());

                }
            }


        }
    }
}
