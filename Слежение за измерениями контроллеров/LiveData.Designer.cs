namespace Слежение_за_измерениями_контроллеров
{
    partial class LiveData
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
            this.LiveView = new System.Windows.Forms.ListView();
            this.Names = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Values = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // LiveView
            // 
            this.LiveView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Names,
            this.Values,
            this.Time});
            this.LiveView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiveView.FullRowSelect = true;
            this.LiveView.GridLines = true;
            this.LiveView.Location = new System.Drawing.Point(0, 0);
            this.LiveView.Name = "LiveView";
            this.LiveView.Size = new System.Drawing.Size(507, 210);
            this.LiveView.TabIndex = 0;
            this.LiveView.UseCompatibleStateImageBehavior = false;
            this.LiveView.View = System.Windows.Forms.View.Details;
            // 
            // Names
            // 
            this.Names.Text = "Наименование";
            this.Names.Width = 202;
            // 
            // Values
            // 
            this.Values.Text = "Значение";
            this.Values.Width = 141;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time
            // 
            this.Time.Text = "Время";
            this.Time.Width = 136;
            // 
            // LiveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 210);
            this.Controls.Add(this.LiveView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LiveData";
            this.Text = "LiveData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LiveView;
        private System.Windows.Forms.ColumnHeader Names;
        private System.Windows.Forms.ColumnHeader Values;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader Time;
    }
}