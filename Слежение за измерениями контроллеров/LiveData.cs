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
    public partial class LiveData : Form
    {
        int ID;
        int FindIndex(string Nm)
        {
            for (int i = 0; i < Program.AllObjects.Length; i++)
                if (Program.AllObjects[i].Group.GroupName == Nm)
                    return i;
            return -1;
        }

        void UpdateList()
        {
            try
            {
                if (Program.AllObjects[ID].Group.opcItems[0].DataValue == null)
                    return;
                this.LiveView.Items.Clear();
                string State = (Program.AllObjects[ID].Group.opcItems[0].DataValue.ToString() == "True") ? "Включен" : "Выключен";
                if (Program.AllObjects[ID].Object_inversion)
                    if (State == "Включен")
                        State = "Выключен";
                    else
                        State = "Включен";
                this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[0].ItemName, State, OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[0].TimeStamp) }));
                this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[1].ItemName, Program.AllObjects[ID].Group.opcItems[1].DataValue.ToString(), OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[1].TimeStamp) }));
                this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[2].ItemName, Program.AllObjects[ID].Group.opcItems[2].DataValue.ToString(), OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[2].TimeStamp) }));
                this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[3].ItemName, Program.AllObjects[ID].Group.opcItems[3].DataValue.ToString(), OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[3].TimeStamp) }));
                //ШР-ы
                for (int i = 0; i < Program.AllObjects[ID].SHR.Count; i++)
                {
                    string txt = (Program.AllObjects[ID].Group.opcItems[i + 4].DataValue == null) ? "" : (Program.AllObjects[ID].Group.opcItems[i + 4].DataValue.ToString() == "True") ? "Включен" : "Выключен";
                    if (Program.AllObjects[ID].SHR[i].Inversion == 1)
                        if (txt == "Включен")
                            txt = "Выключен";
                        else
                            txt = "Включен";
                    this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[i + 4].ItemName, txt, OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[i + 4].TimeStamp) }));
                }
                //ЗН-ы
                for (int i = 0; i < Program.AllObjects[ID].ZN.Count; i++)
                {
                    string txt = (Program.AllObjects[ID].Group.opcItems[i + 4 + Program.AllObjects[ID].SHR.Count].DataValue == null) ? "" : (Program.AllObjects[ID].Group.opcItems[i + 4 + Program.AllObjects[ID].SHR.Count].DataValue.ToString() == "True") ? "Включен" : "Выключен";
                    
                    if (Program.AllObjects[ID].ZN[i].Inversion == 0)
                        if (txt == "Включен")
                            txt = "Выключен";
                        else
                            txt = "Включен";
                            
                    this.LiveView.Items.Add(new ListViewItem(new string[] { Program.AllObjects[ID].Group.opcItems[i + 4 + Program.AllObjects[ID].SHR.Count].ItemName, txt, OpcDaLib.ToStringConverter.GetFTSting(Program.AllObjects[ID].Group.opcItems[i + 4 + Program.AllObjects[ID].SHR.Count].TimeStamp) }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public LiveData()
        {
            InitializeComponent();
        }
        public LiveData(string id)
        {
            InitializeComponent();
            ID = FindIndex(id);
            this.Text = Program.AllObjects[ID].Group.opcItems[0].ItemName;
            UpdateList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
