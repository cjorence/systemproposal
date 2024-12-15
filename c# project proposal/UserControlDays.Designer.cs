namespace c__project_proposal
{
    partial class UserControlDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDays = new System.Windows.Forms.Label();
            this.lbAppointment = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(10, 12);
            this.lblDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(23, 16);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "00";
            this.lblDays.Click += new System.EventHandler(this.lblDays_Click);
            // 
            // lbAppointment
            // 
            this.lbAppointment.AutoSize = true;
            this.lbAppointment.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbAppointment.Location = new System.Drawing.Point(3, 43);
            this.lbAppointment.Name = "lbAppointment";
            this.lbAppointment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbAppointment.Size = new System.Drawing.Size(13, 13);
            this.lbAppointment.TabIndex = 1;
            this.lbAppointment.Text = "  ";
            this.lbAppointment.Click += new System.EventHandler(this.lbAppointment_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.lbAppointment);
            this.Controls.Add(this.lblDays);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(90, 56);
            this.Load += new System.EventHandler(this.UserControlDays_Load);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lbAppointment;
        private System.Windows.Forms.Timer timer1;
    }
}
