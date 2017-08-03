namespace Слежение_за_измерениями_контроллеров
{
    partial class NewObj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ObjectName = new System.Windows.Forms.TextBox();
            this.ObjectTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjectCurrent = new System.Windows.Forms.TextBox();
            this.ObjectQ = new System.Windows.Forms.TextBox();
            this.ObjectPower = new System.Windows.Forms.TextBox();
            this.Inversion = new System.Windows.Forms.CheckBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.listViewSHR_LR = new System.Windows.Forms.ListView();
            this.Shr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SHR_Tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewZN = new System.Windows.Forms.ListView();
            this.Zn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование объекта";
            // 
            // ObjectName
            // 
            this.ObjectName.Location = new System.Drawing.Point(12, 25);
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.Size = new System.Drawing.Size(208, 20);
            this.ObjectName.TabIndex = 1;
            // 
            // ObjectTag
            // 
            this.ObjectTag.Location = new System.Drawing.Point(12, 68);
            this.ObjectTag.Name = "ObjectTag";
            this.ObjectTag.Size = new System.Drawing.Size(208, 20);
            this.ObjectTag.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ОРС-тэг";
            // 
            // ObjectCurrent
            // 
            this.ObjectCurrent.Location = new System.Drawing.Point(253, 25);
            this.ObjectCurrent.Name = "ObjectCurrent";
            this.ObjectCurrent.Size = new System.Drawing.Size(213, 20);
            this.ObjectCurrent.TabIndex = 5;
            // 
            // ObjectQ
            // 
            this.ObjectQ.Location = new System.Drawing.Point(252, 117);
            this.ObjectQ.Name = "ObjectQ";
            this.ObjectQ.Size = new System.Drawing.Size(214, 20);
            this.ObjectQ.TabIndex = 7;
            // 
            // ObjectPower
            // 
            this.ObjectPower.Location = new System.Drawing.Point(253, 68);
            this.ObjectPower.Name = "ObjectPower";
            this.ObjectPower.Size = new System.Drawing.Size(213, 20);
            this.ObjectPower.TabIndex = 9;
            // 
            // Inversion
            // 
            this.Inversion.AutoSize = true;
            this.Inversion.Location = new System.Drawing.Point(12, 97);
            this.Inversion.Name = "Inversion";
            this.Inversion.Size = new System.Drawing.Size(76, 17);
            this.Inversion.TabIndex = 10;
            this.Inversion.Text = "Инверсия";
            this.Inversion.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(148, 391);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 11;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(252, 391);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 12;
            this.Cancelbutton.Text = "Отмена";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // listViewSHR_LR
            // 
            this.listViewSHR_LR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Shr,
            this.SHR_Tag});
            this.listViewSHR_LR.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewSHR_LR.FullRowSelect = true;
            this.listViewSHR_LR.GridLines = true;
            this.listViewSHR_LR.Location = new System.Drawing.Point(8, 143);
            this.listViewSHR_LR.Name = "listViewSHR_LR";
            this.listViewSHR_LR.Size = new System.Drawing.Size(212, 229);
            this.listViewSHR_LR.TabIndex = 14;
            this.listViewSHR_LR.UseCompatibleStateImageBehavior = false;
            this.listViewSHR_LR.View = System.Windows.Forms.View.Details;
            // 
            // Shr
            // 
            this.Shr.Text = "ШР и ЛР";
            this.Shr.Width = 107;
            // 
            // SHR_Tag
            // 
            this.SHR_Tag.Text = "Тэг";
            this.SHR_Tag.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // listViewZN
            // 
            this.listViewZN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Zn,
            this.columnHeaderTag});
            this.listViewZN.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewZN.FullRowSelect = true;
            this.listViewZN.GridLines = true;
            this.listViewZN.Location = new System.Drawing.Point(252, 143);
            this.listViewZN.Name = "listViewZN";
            this.listViewZN.Size = new System.Drawing.Size(214, 229);
            this.listViewZN.TabIndex = 15;
            this.listViewZN.UseCompatibleStateImageBehavior = false;
            this.listViewZN.View = System.Windows.Forms.View.Details;
            // 
            // Zn
            // 
            this.Zn.Text = "ЗН";
            this.Zn.Width = 92;
            // 
            // columnHeaderTag
            // 
            this.columnHeaderTag.Text = "Тэг";
            this.columnHeaderTag.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ток";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Мощность активная";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Мощность реактивная";
            // 
            // NewObj
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(478, 426);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewZN);
            this.Controls.Add(this.listViewSHR_LR);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Inversion);
            this.Controls.Add(this.ObjectPower);
            this.Controls.Add(this.ObjectQ);
            this.Controls.Add(this.ObjectCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ObjectTag);
            this.Controls.Add(this.ObjectName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "NewObj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewObj";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
        public System.Windows.Forms.TextBox ObjectName;
        public System.Windows.Forms.TextBox ObjectTag;
        public System.Windows.Forms.TextBox ObjectCurrent;
        public System.Windows.Forms.TextBox ObjectQ;
        public System.Windows.Forms.TextBox ObjectPower;
        public System.Windows.Forms.CheckBox Inversion;
        private System.Windows.Forms.ListView listViewSHR_LR;
        private System.Windows.Forms.ListView listViewZN;
        private System.Windows.Forms.ColumnHeader Shr;
        private System.Windows.Forms.ColumnHeader Zn;
        private System.Windows.Forms.ColumnHeader SHR_Tag;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}