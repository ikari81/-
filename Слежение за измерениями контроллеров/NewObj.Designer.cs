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
            this.label1 = new System.Windows.Forms.Label();
            this.ObjectName = new System.Windows.Forms.TextBox();
            this.ObjectTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ObjectCurrent = new System.Windows.Forms.TextBox();
            this.ObjectQ = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ObjectPower = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.Inversion = new System.Windows.Forms.CheckBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.buttonSHLR = new System.Windows.Forms.Button();
            this.listViewSHR_LR = new System.Windows.Forms.ListView();
            this.Shr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewZN = new System.Windows.Forms.ListView();
            this.Zn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonZN = new System.Windows.Forms.Button();
            this.SHR_Tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(265, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Ток";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ObjectCurrent
            // 
            this.ObjectCurrent.Location = new System.Drawing.Point(265, 25);
            this.ObjectCurrent.Name = "ObjectCurrent";
            this.ObjectCurrent.Size = new System.Drawing.Size(192, 20);
            this.ObjectCurrent.TabIndex = 5;
            // 
            // ObjectQ
            // 
            this.ObjectQ.Location = new System.Drawing.Point(265, 71);
            this.ObjectQ.Name = "ObjectQ";
            this.ObjectQ.Size = new System.Drawing.Size(192, 20);
            this.ObjectQ.TabIndex = 7;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(265, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(141, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Мощность реактивная";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // ObjectPower
            // 
            this.ObjectPower.Location = new System.Drawing.Point(265, 117);
            this.ObjectPower.Name = "ObjectPower";
            this.ObjectPower.Size = new System.Drawing.Size(192, 20);
            this.ObjectPower.TabIndex = 9;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(265, 97);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(79, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Мощность";
            this.checkBox3.UseVisualStyleBackColor = true;
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
            // buttonSHLR
            // 
            this.buttonSHLR.Location = new System.Drawing.Point(8, 155);
            this.buttonSHLR.Name = "buttonSHLR";
            this.buttonSHLR.Size = new System.Drawing.Size(76, 23);
            this.buttonSHLR.TabIndex = 13;
            this.buttonSHLR.Text = "Добавить";
            this.buttonSHLR.UseVisualStyleBackColor = true;
            this.buttonSHLR.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewSHR_LR
            // 
            this.listViewSHR_LR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Shr,
            this.SHR_Tag});
            this.listViewSHR_LR.FullRowSelect = true;
            this.listViewSHR_LR.GridLines = true;
            this.listViewSHR_LR.Location = new System.Drawing.Point(8, 184);
            this.listViewSHR_LR.Name = "listViewSHR_LR";
            this.listViewSHR_LR.Size = new System.Drawing.Size(212, 177);
            this.listViewSHR_LR.TabIndex = 14;
            this.listViewSHR_LR.UseCompatibleStateImageBehavior = false;
            this.listViewSHR_LR.View = System.Windows.Forms.View.Details;
            // 
            // Shr
            // 
            this.Shr.Text = "ШР и ЛР";
            this.Shr.Width = 107;
            // 
            // listViewZN
            // 
            this.listViewZN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Zn,
            this.columnHeaderTag});
            this.listViewZN.GridLines = true;
            this.listViewZN.Location = new System.Drawing.Point(252, 184);
            this.listViewZN.Name = "listViewZN";
            this.listViewZN.Size = new System.Drawing.Size(214, 177);
            this.listViewZN.TabIndex = 15;
            this.listViewZN.UseCompatibleStateImageBehavior = false;
            this.listViewZN.View = System.Windows.Forms.View.Details;
            // 
            // Zn
            // 
            this.Zn.Text = "ЗН";
            this.Zn.Width = 92;
            // 
            // buttonZN
            // 
            this.buttonZN.Location = new System.Drawing.Point(252, 155);
            this.buttonZN.Name = "buttonZN";
            this.buttonZN.Size = new System.Drawing.Size(76, 23);
            this.buttonZN.TabIndex = 16;
            this.buttonZN.Text = "Добавить";
            this.buttonZN.UseVisualStyleBackColor = true;
            this.buttonZN.Click += new System.EventHandler(this.buttonZN_Click);
            // 
            // SHR_Tag
            // 
            this.SHR_Tag.Text = "Тэг";
            this.SHR_Tag.Width = 100;
            // 
            // columnHeaderTag
            // 
            this.columnHeaderTag.Text = "Тэг";
            this.columnHeaderTag.Width = 100;
            // 
            // NewObj
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(478, 426);
            this.Controls.Add(this.buttonZN);
            this.Controls.Add(this.listViewZN);
            this.Controls.Add(this.listViewSHR_LR);
            this.Controls.Add(this.buttonSHLR);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Inversion);
            this.Controls.Add(this.ObjectPower);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.ObjectQ);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.ObjectCurrent);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ObjectTag);
            this.Controls.Add(this.ObjectName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "NewObj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewObj";
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
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox ObjectCurrent;
        public System.Windows.Forms.TextBox ObjectQ;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.TextBox ObjectPower;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox Inversion;
        private System.Windows.Forms.Button buttonSHLR;
        private System.Windows.Forms.ListView listViewSHR_LR;
        private System.Windows.Forms.ListView listViewZN;
        private System.Windows.Forms.ColumnHeader Shr;
        private System.Windows.Forms.ColumnHeader Zn;
        private System.Windows.Forms.Button buttonZN;
        private System.Windows.Forms.ColumnHeader SHR_Tag;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
    }
}