using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpcDaLib;
using System.Threading;

namespace Слежение_за_измерениями_контроллеров
{
    struct SHR_LR_ZN
    {
        public int CurrentValue;
        public int Inversion;
        public SHR_LR_ZN(int Val, int Inv)
        {
            CurrentValue = Val;
            Inversion = Inv;
        }
    }
    struct OPC
    {
        //public string ObjectName;   //Наименование
        //public OPCItem Object;      //Выключатель
        public bool Object_inversion;
        public double Current;     //Ток
        public double Power;       //Активная мощность
        public double QPower;      //Реактивная мощность
        public List<SHR_LR_ZN> SHR;   //Список ШР
        public List<SHR_LR_ZN> ZN;    //Список ЗН
        public OPCGroup Group;      //Группа, в которой находится опрос
    }
    
    public partial class MainForm : Form
    {
        OPCServer opcServer;
        Thread[] opc;
        bool RELOAD = false;
        bool offline = true;
        
        //Загружаем настройки
        void LoadPrefs()
        {
            Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
            string[] res = new string[1];
            int count = 0;
            if (!Dbase.GetDB("SELECT COUNT(*) FROM Objects WHERE Active = 1;", ref res, ref count))
                MessageBox.Show("Error!");
            
            res = new string[int.Parse(res[0].Split((char)1)[0])];
            string SQL = "SELECT [id], ObjectName, OPC_Name, CurrentOPC, QOPC, PowerOPC, Inversion FROM [Objects] WHERE Active = 1;";
            if (!Dbase.GetDB(SQL, ref res, ref count))
            MessageBox.Show("Error2");

            Program.AllObjects = new OPC[res.Length];

            for (int i=0;i<res.Length;i++)
            {
                OPCItem Object = new OPCItem();
                OPCItem Current = new OPCItem();
                OPCItem QPower = new OPCItem();
                OPCItem Power = new OPCItem();

                Object.ItemID = res[i].Split((char)1)[2];
                Current.ItemID = res[i].Split((char)1)[3];
                QPower.ItemID = res[i].Split((char)1)[4];
                Power.ItemID = res[i].Split((char)1)[5];

                Object.Enabled = true;
                Current.Enabled = true;
                QPower.Enabled = true;
                Power.Enabled = true;
                
                Object.ItemName = res[i].Split((char)1)[1];
                Current.ItemName = "Ток " + Object.ItemName;
                QPower.ItemName = "Реактивная мощность " + Object.ItemName;
                Power.ItemName = "Активная мощность " + Object.ItemName;

                Program.AllObjects[i].Group = new OPCGroup();
                Program.AllObjects[i].Group.Enabled = true;
                Program.AllObjects[i].Group.GroupName = Object.ItemName;
                Program.AllObjects[i].Group.DataSource = OPCDataSource.DSCache;
                Program.AllObjects[i].Group.IOType = OPCIOType.IOAsync;
                Program.AllObjects[i].Group.UpdateRate = 60000;
                Program.AllObjects[i].Group.opcItems.Add(Object);
                Program.AllObjects[i].Group.opcItems.Add(Current);
                Program.AllObjects[i].Group.opcItems.Add(QPower);
                Program.AllObjects[i].Group.opcItems.Add(Power);
                Program.AllObjects[i].Object_inversion = (res[i].Split((char)1)[6] == "1") ? true : false;

                SQL = "SELECT id, OPC_name, OPC_Tag, inversion FROM SHR_LR WHERE TC_id = " + res[i].Split((char)1)[0] + ";";
                string[] shr_lr = new string[5];
                int shlr = -1;
                int sm = Program.AllObjects[i].Group.opcItems.Count;
                Program.AllObjects[i].SHR = new List<SHR_LR_ZN>();
                if (Dbase.GetDB(SQL, ref shr_lr, ref shlr))
                {
                    for (int k = 0; k < shlr; k++)
                    {
                        Program.AllObjects[i].Group.opcItems.Add(new OPCItem());
                        Program.AllObjects[i].Group.opcItems[k + sm].Enabled = true;
                        Program.AllObjects[i].Group.opcItems[k + sm].ItemID = shr_lr[k].Split((char)1)[2];
                        Program.AllObjects[i].Group.opcItems[k + sm].ItemName = shr_lr[k].Split((char)1)[1];
                        Program.AllObjects[i].SHR.Add(new SHR_LR_ZN(0, int.Parse(shr_lr[k].Split((char)1)[3])));
                    }
                }
                else
                    MessageBox.Show("Error shr_lr\n" + SQL + "\n" + shlr.ToString());

                SQL = "SELECT id, OPC_name, OPC_Tag, inversion FROM ZN WHERE TC_id = " + res[i].Split((char)1)[0] + ";";
                shr_lr = new string[5];
                shlr = -1;
                sm = Program.AllObjects[i].Group.opcItems.Count;
                Program.AllObjects[i].ZN = new List<SHR_LR_ZN>();

                if (Dbase.GetDB(SQL, ref shr_lr, ref shlr))
                {
                    for (int k = 0; k < shlr; k++)
                    {
                        Program.AllObjects[i].Group.opcItems.Add(new OPCItem());
                        Program.AllObjects[i].Group.opcItems[k + sm].Enabled = true;
                        Program.AllObjects[i].Group.opcItems[k + sm].ItemID = shr_lr[k].Split((char)1)[2];
                        Program.AllObjects[i].Group.opcItems[k + sm].ItemName = shr_lr[k].Split((char)1)[1];
                        Program.AllObjects[i].ZN.Add(new SHR_LR_ZN(0, int.Parse(shr_lr[k].Split((char)1)[3])));
                    }
                }
                else
                    MessageBox.Show("Error shr_lr\n" + SQL + "\n" + shlr.ToString());


                opcServer.OPCGroups.Add(Program.AllObjects[i].Group);
            }
            
        }
        void OPCInit()
        {
            opcServer.Connect();
            opcServer.SetClientName("EvgenyK_OPC_client");
            opcServer.RegGroupsInServer();
            for (int k = 0; k < Program.AllObjects.Length; k++)
                Program.AllObjects[k].Group.RegItemsInServer();
            opc = new Thread[Program.AllObjects.Length];
            //Создаем, инициализируем и запускаем потоки
            for (int i = 0; i < Program.AllObjects.Length; i++)
            {
                opc[i] = new Thread(OPCReadThread);
                opc[i].Name = i.ToString();  //В имени потока номер адреса в массиве ip
                opc[i].IsBackground = true;
                opc[i].SetApartmentState(ApartmentState.STA);
                opc[i].Start();
            }
        }

        void OPCReadThread()
        {
            Logger log = Logger.GetInstance();
            int idx = int.Parse(Thread.CurrentThread.Name); //Порядковый номер потока, он же индекс во всех массивах данных, соответствующий адресу    
            while ((true) && (!RELOAD))
            {
                int Switch = -1;
                //double Current = double.NaN;
                //double Power = double.NaN;
                //double QPower = double.NaN;

                Program.AllObjects[idx].Current = double.NaN;
                Program.AllObjects[idx].QPower = double.NaN;
                Program.AllObjects[idx].Power = double.NaN;

                int ReadResult;
                //lock (Program.OPCLock)
                    ReadResult = Program.AllObjects[idx].Group.SyncRead();

                if (ReadResult == 0)
                {
                    log.AppendLog("Поток " + idx + " " + Program.AllObjects[idx].Group.opcItems[0].ItemName + " OPC status: " + ReadResult.ToString());
                    this.MainView.Items[idx].SubItems[2].Text = "";
                    if (Program.AllObjects[idx].Group.opcItems[0].DataValue != null)
                    {
                        Switch = (Program.AllObjects[idx].Group.opcItems[0].DataValue.ToString() == "True") ? 1 : 0;
                        if (Program.AllObjects[idx].Object_inversion)
                            if (Switch == 1)
                                Switch = 0;
                            else
                                Switch = 1;
                    }

                    if (Program.AllObjects[idx].Group.opcItems[1].DataValue != null)
                    {
                        //Current = double.Parse(Program.AllObjects[idx].Group.opcItems[1].DataValue.ToString());
                        Program.AllObjects[idx].Current = double.Parse(Program.AllObjects[idx].Group.opcItems[1].DataValue.ToString());
                    }

                    if (Program.AllObjects[idx].Group.opcItems[2].DataValue != null)
                    {
                        //QPower = double.Parse(Program.AllObjects[idx].Group.opcItems[2].DataValue.ToString());
                        Program.AllObjects[idx].QPower = double.Parse(Program.AllObjects[idx].Group.opcItems[2].DataValue.ToString());
                    }

                    if (Program.AllObjects[idx].Group.opcItems[3].DataValue != null)
                    {
                        //Power = double.Parse(Program.AllObjects[idx].Group.opcItems[3].DataValue.ToString());
                        Program.AllObjects[idx].Power = double.Parse(Program.AllObjects[idx].Group.opcItems[3].DataValue.ToString());
                    }

                    int SHRResult = 1;
                    for (int q = 0; q < Program.AllObjects[idx].SHR.Count; q++)
                    {
                        if (Program.AllObjects[idx].Group.opcItems[4 + q].DataValue != null)
                        {
                            int Value = (Program.AllObjects[idx].Group.opcItems[4 + q].DataValue.ToString() == "True") ? 1 : 0;
                            int inv = Program.AllObjects[idx].SHR[q].Inversion;
                            if (inv == 1)
                                if (Value == 1)
                                    Value = 0;
                                else
                                    Value = 1;
                            Program.AllObjects[idx].SHR[q] = new SHR_LR_ZN(Value, inv);
                        }
                        else
                        {
                            int inv = Program.AllObjects[idx].SHR[q].Inversion;
                            Program.AllObjects[idx].SHR[q] = new SHR_LR_ZN(-1, inv);//
                        }
                        SHRResult *= Program.AllObjects[idx].SHR[q].CurrentValue;
                    }
                    /*
                     * Если SHRResult = 0 - какой-то из разъединителей выключен
                     * 1 - все включено
                     * -1 - какая-то неопределенность
                     * */
                    int ZNResult = 1;
                    for (int q = 0; q < Program.AllObjects[idx].ZN.Count; q++)
                    {
                        if (Program.AllObjects[idx].Group.opcItems[4 + q + Program.AllObjects[idx].SHR.Count].DataValue != null)
                        {
                            int Value = (Program.AllObjects[idx].Group.opcItems[4 + q + Program.AllObjects[idx].SHR.Count].DataValue.ToString() == "True") ? 1 : 0;
                            Program.AllObjects[idx].ZN[q] = new SHR_LR_ZN(Value, 1);// 
                        }
                        else
                            Program.AllObjects[idx].ZN[q] = new SHR_LR_ZN(-1, 1);//
                        ZNResult *= Program.AllObjects[idx].ZN[q].CurrentValue;
                    }

                    /*
                    if (ZNResult == 1)
                        ZNResult = 0;
                    else
                        ZNResult = 1;
*/

                    if (Program.AllObjects[idx].ZN.Count == 0 || Program.AllObjects[idx].SHR.Count == 0)
                    {
                        SHRResult = 1;
                        ZNResult = 0;
                    }

                    int Reliability = -1;
                    //Cама проверка достоверности
                    int Meters = -1;
                    //int Values = -1;
                    int AllZero = -1;

                    //Если есть ток, мощность и реактивная мощность - измерения нормально прочитаны
                    if ((Program.AllObjects[idx].Current != double.NaN) && (Program.AllObjects[idx].Power != double.NaN) && (Program.AllObjects[idx].QPower != double.NaN))
                        Meters = 1;

                    if (Program.AllObjects[idx].Current.ToString().Trim() == "0" && Program.AllObjects[idx].Power.ToString().Trim() == "0" && Program.AllObjects[idx].QPower.ToString().Trim() == "0")
                        AllZero = 1;

                    //
                    if ((Program.AllObjects[idx].Current < 0.1) && (Program.AllObjects[idx].Power == 0) && (Program.AllObjects[idx].QPower == 0))
                        AllZero = 1;
                    //



                    
                    //И при этом выключатель включен, измерения в тэге нормально прочитаны, шр-лр включены, зн - выключены 
                    if (Switch == 1 && Meters == 1 && SHRResult == 1 && ZNResult == 0)
                    //Значит все правильно отображается
                    {
                        Reliability = 1;
                        goto Exit;
                    }

                    //И при этом выключатель включен, измерения в тэге нормально прочитаны и по 0, шр-лр включены, зн - выключены 
                    if (Switch == 1 && Meters == 1 && AllZero == 1 && SHRResult == 1 && ZNResult == 0)
                    //Значит все правильно отображается
                    {
                        Reliability = 1;
                        goto Exit;
                    }



                    //И при этом выключатель выключен, измерения в тэге нормально прочитаны и по 0, шр-лр включены, зн - выключены 
                    if (Switch == 0 && Meters == 1 && AllZero == 1 && SHRResult == 1 && ZNResult == 0)
                    //Значит все правильно отображается
                    {
                        Reliability = 1;
                        goto Exit;
                    }

                    //И при этом выключатель выключен, измерения в тэге нормально прочитаны и по 0, шр-лр выключены, зн - выключены 
                    if (Switch == 0 && Meters == 1 && AllZero == 1 && SHRResult == 0 && ZNResult == 0)
                    //Значит все правильно отображается
                    {
                        Reliability = 1;
                        goto Exit;
                    }
                    /*/
                     * 
                    //И при этом выключатель включен, измерения в тэге не прочитаны
                    if (Switch == 1 && Meters == 0)
                    //неопределенность
                    {
                        Reliability = -2;
                        goto Exit;
                    }

                    //И при этом выключатель выключен, измерения в тэге нормально прочитаны
                    if (Switch == 0 && Meters == 1)
                    //недостоверность
                    {
                       // Reliability = 0;
                        goto Exit;
                    }
                    */
                    Exit:
                    this.MainView.Items[idx].SubItems[2].Text = DateTime.Now.ToString();
                    if ((Reliability == 1))
                    {
                        if (Program.MainWindowState != 0)
                        {
                            this.MainView.Items[idx].SubItems[1].Text = "Достоверно" + " " + SHRResult.ToString() + " " + ZNResult.ToString();
                            this.MainView.Items[idx].BackColor = Color.White;
                            this.MainView.Items[idx].ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        if (Program.MainWindowState != 0)
                        {
                            this.MainView.Items[idx].SubItems[1].Text = "Недостоверен" + " " + SHRResult.ToString() + " " + ZNResult.ToString();
                            this.MainView.Items[idx].BackColor = Color.Red;
                            this.MainView.Items[idx].ForeColor = Color.White;
                        }
                    }
                    Thread.Sleep((int)Program.AllObjects[idx].Group.UpdateRate);
                }
                else
                {
                    log.AppendLog("Поток " + idx + " " + Program.AllObjects[idx].Group.opcItems[0].ItemName + " OPC status: " + ReadResult.ToString());
                    Thread.Sleep((int)Program.AllObjects[idx].Group.UpdateRate);
                }
            }
        }

        void UpdateList()
        {
            if (Program.MainWindowState == 0)
                return;
            Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
            string[] res = new string[1];
            int count = 0;
            if (!Dbase.GetDB("SELECT COUNT(*) FROM Objects WHERE Active = 1", ref res, ref count))
                return;
            res = new string[int.Parse(res[0].Split((char)1)[0])];
            string SQL = "SELECT [id], ObjectName, OPC_Name, CurrentOPC, QOPC, PowerOPC, Inversion FROM [Objects] WHERE Active = 1;";
            Dbase.GetDB(SQL, ref res, ref count);

            this.MainView.Items.Clear();
            for (int i = 0; i< res.Length;i++)
            {
                ListViewItem itm = new ListViewItem(new string[] { res[i].Split((char)1)[1],(res[i].Split((char)1)[7] == "0")? "Достоверен":"Недостоверен", "Неизвестно", res[i].Split((char)1)[0] });
                this.MainView.Items.Add(itm);
            }
        }
        public MainForm()
        {
            InitializeComponent();
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            ListViewHelper.EnableDoubleBuffer(MainView);
            UpdateList();
            //Подключаемся к ОРС
            opcServer = new OPCServer();
            var OPCName = "MIR.OPCServerOm3";
            opcServer.Guid = OpcDaClient.GetServerGuid(OPCName);
            if (!offline)
                if (OpcDaClient.GetServerGuid(OPCName).ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    MessageBox.Show("Не могу найти указанный сервер");
                    this.Close();
                    Application.ExitThread();
                    Application.Exit();
                }
            LoadPrefs();
            if (!offline)
                OPCInit();


        }
        private void добавитьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObj frm = new NewObj();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
                string SQL = "INSERT INTO Objects(ObjectName, OPC_Name, CurrentOPC, QOPC, PowerOPC, Inversion, Active) VALUES('" + frm.ObjectName.Text + "','" + frm.ObjectTag.Text + "', '" + frm.ObjectCurrent.Text + 
                    "', '" + frm.ObjectQ.Text + "', '" + frm.ObjectPower.Text + "', " + ((frm.Inversion.Checked == true)? "1":"0") + ", 1)";
                //MessageBox.Show(SQL);
                if (!Dbase.AddToDB(SQL))
                    MessageBox.Show("Ошибка добавления объекта");
                else
                    UpdateList();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Waiting w = new Waiting();
            if (offline)
                goto Exit;
            w.Caption.Text = "Останавливаю потоки опроса...";
            RELOAD = true;
            int PCount = opc.Length;
            new Thread(()=> { w.ShowDialog();}).Start();
                while (true)
            {
                int cnt = 0;
                for (int i = 0; i < PCount; i++)
                    if (opc[i].ThreadState == ThreadState.Running)
                        cnt++;
                if (cnt == 0)
                    break;
            }
            Exit:
            opcServer.RemoveGroupsFromServer();
            opcServer.Disconnect();
            w.Close();
        }
        int FindIndex(string Nm)
        {
            for (int i = 0; i < Program.AllObjects.Length; i++)
                if (Program.AllObjects[i].Group.GroupName == Nm)
                    return i;
            return -1;
        }
        private void liveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveData LD = null;
            if (this.MainView.SelectedItems[0].Text != "")
                LD = new LiveData(this.MainView.SelectedItems[0].Text);
            LD.Show();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MainView.SelectedItems[0].Text != "")
            {
                NewObj Editor = new NewObj(this.MainView.SelectedItems[0].Text, this.MainView.SelectedItems[0].SubItems[3].Text);
                if (Editor.ShowDialog() == DialogResult.OK)
                {
                    Db Dbase = new Db("OPCLogger", "192.168.100.16", "sa", "dvddecrypter");
                    string SQL = @"UPDATE Objects SET ObjectName = '" + Editor.ObjectName.Text + "',  OPC_Name = '" + Editor.ObjectTag.Text + "', CurrentOPC = '" + Editor.ObjectCurrent.Text + "', QOPC = '" +
                        Editor.ObjectQ.Text + "', PowerOPC = '" + Editor.ObjectPower.Text + "', Inversion = " + ((Editor.Inversion.Checked == true) ? "1" : "0").ToString() +
                        ", Active = 1 WHERE ObjectName = '" + this.MainView.SelectedItems[0].Text + "'";
                    //MessageBox.Show(SQL);
                    if (!Dbase.AddToDB(SQL))
                        MessageBox.Show("Ошибка изменения объекта");
                }
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                Program.MainWindowState = 0;
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal || this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                Program.MainWindowState = 1;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}