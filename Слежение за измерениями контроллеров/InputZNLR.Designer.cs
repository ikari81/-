namespace Слежение_за_измерениями_контроллеров
{
    partial class InputZNLR
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
            this.OPC_Name_Text = new System.Windows.Forms.TextBox();
            this.OPC_Tag = new System.Windows.Forms.TextBox();
            this.checkBoxInversion = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OPC_Name_Text
            // 
            this.OPC_Name_Text.Location = new System.Drawing.Point(12, 27);
            this.OPC_Name_Text.Name = "OPC_Name_Text";
            this.OPC_Name_Text.Size = new System.Drawing.Size(240, 20);
            this.OPC_Name_Text.TabIndex = 0;
            // 
            // OPC_Tag
            // 
            this.OPC_Tag.Location = new System.Drawing.Point(12, 76);
            this.OPC_Tag.Name = "OPC_Tag";
            this.OPC_Tag.Size = new System.Drawing.Size(240, 20);
            this.OPC_Tag.TabIndex = 1;
            // 
            // checkBoxInversion
            // 
            this.checkBoxInversion.AutoSize = true;
            this.checkBoxInversion.Location = new System.Drawing.Point(12, 102);
            this.checkBoxInversion.Name = "checkBoxInversion";
            this.checkBoxInversion.Size = new System.Drawing.Size(76, 17);
            this.checkBoxInversion.TabIndex = 2;
            this.checkBoxInversion.Text = "Инверсия";
            this.checkBoxInversion.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(44, 137);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(144, 137);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(83, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Наименование";
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(12, 60);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(25, 13);
            this.labelTag.TabIndex = 7;
            this.labelTag.Text = "Тэг";
            // 
            // InputZNLR
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(264, 172);
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxInversion);
            this.Controls.Add(this.OPC_Tag);
            this.Controls.Add(this.OPC_Name_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputZNLR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputZNLR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTag;
        public System.Windows.Forms.TextBox OPC_Name_Text;
        public System.Windows.Forms.TextBox OPC_Tag;
        public System.Windows.Forms.CheckBox checkBoxInversion;
    }
}