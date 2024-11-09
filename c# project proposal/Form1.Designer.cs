namespace c__project_proposal
{
    partial class Form1
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
            this.listviewcalendar = new System.Windows.Forms.ListView();
            this.profilepicture = new System.Windows.Forms.PictureBox();
            this.Sun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FRI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewdaymonthandweek = new System.Windows.Forms.ListView();
            this.newschedule = new System.Windows.Forms.Button();
            this.viewsched = new System.Windows.Forms.Button();
            this.calendarclick = new System.Windows.Forms.Button();
            this.editschedclick = new System.Windows.Forms.Button();
            this.deleteschedclick = new System.Windows.Forms.Button();
            this.messageclick = new System.Windows.Forms.Button();
            this.settingsclick = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useremail = new System.Windows.Forms.Label();
            this.locationview1 = new System.Windows.Forms.ListView();
            this.locationview2 = new System.Windows.Forms.ListView();
            this.locationview3 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.profilepicture)).BeginInit();
            this.SuspendLayout();
            // 
            // listviewcalendar
            // 
            this.listviewcalendar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sun,
            this.Mon,
            this.Tue,
            this.Wed,
            this.Thu,
            this.FRI,
            this.Sat});
            this.listviewcalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listviewcalendar.FullRowSelect = true;
            this.listviewcalendar.GridLines = true;
            this.listviewcalendar.HideSelection = false;
            this.listviewcalendar.Location = new System.Drawing.Point(303, 136);
            this.listviewcalendar.Name = "listviewcalendar";
            this.listviewcalendar.Size = new System.Drawing.Size(442, 343);
            this.listviewcalendar.TabIndex = 0;
            this.listviewcalendar.UseCompatibleStateImageBehavior = false;
            this.listviewcalendar.View = System.Windows.Forms.View.Details;
            // 
            // profilepicture
            // 
            this.profilepicture.Location = new System.Drawing.Point(77, 34);
            this.profilepicture.Name = "profilepicture";
            this.profilepicture.Size = new System.Drawing.Size(100, 106);
            this.profilepicture.TabIndex = 1;
            this.profilepicture.TabStop = false;
            // 
            // Sun
            // 
            this.Sun.Text = "SUN";
            this.Sun.Width = 69;
            // 
            // Mon
            // 
            this.Mon.Text = "MON";
            this.Mon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tue
            // 
            this.Tue.Text = "TUE";
            this.Tue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Wed
            // 
            this.Wed.Text = "WED";
            this.Wed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Thu
            // 
            this.Thu.Text = "THU";
            this.Thu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FRI
            // 
            this.FRI.Text = "FRI";
            this.FRI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Sat
            // 
            this.Sat.Text = "SAT";
            this.Sat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listViewdaymonthandweek
            // 
            this.listViewdaymonthandweek.HideSelection = false;
            this.listViewdaymonthandweek.Location = new System.Drawing.Point(372, 70);
            this.listViewdaymonthandweek.Name = "listViewdaymonthandweek";
            this.listViewdaymonthandweek.Size = new System.Drawing.Size(442, 35);
            this.listViewdaymonthandweek.TabIndex = 2;
            this.listViewdaymonthandweek.UseCompatibleStateImageBehavior = false;
            // 
            // newschedule
            // 
            this.newschedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newschedule.Location = new System.Drawing.Point(774, 147);
            this.newschedule.Name = "newschedule";
            this.newschedule.Size = new System.Drawing.Size(144, 26);
            this.newschedule.TabIndex = 3;
            this.newschedule.Text = "CREATE NEW SCHED";
            this.newschedule.UseVisualStyleBackColor = true;
            // 
            // viewsched
            // 
            this.viewsched.Location = new System.Drawing.Point(27, 181);
            this.viewsched.Name = "viewsched";
            this.viewsched.Size = new System.Drawing.Size(83, 68);
            this.viewsched.TabIndex = 4;
            this.viewsched.Text = "VIEW SCHED";
            this.viewsched.UseVisualStyleBackColor = true;
            // 
            // calendarclick
            // 
            this.calendarclick.Location = new System.Drawing.Point(143, 181);
            this.calendarclick.Name = "calendarclick";
            this.calendarclick.Size = new System.Drawing.Size(83, 68);
            this.calendarclick.TabIndex = 5;
            this.calendarclick.Text = "CALENDAR";
            this.calendarclick.UseVisualStyleBackColor = true;
            // 
            // editschedclick
            // 
            this.editschedclick.Location = new System.Drawing.Point(27, 267);
            this.editschedclick.Name = "editschedclick";
            this.editschedclick.Size = new System.Drawing.Size(83, 68);
            this.editschedclick.TabIndex = 6;
            this.editschedclick.Text = "EDIT SCHED";
            this.editschedclick.UseVisualStyleBackColor = true;
            // 
            // deleteschedclick
            // 
            this.deleteschedclick.Location = new System.Drawing.Point(143, 267);
            this.deleteschedclick.Name = "deleteschedclick";
            this.deleteschedclick.Size = new System.Drawing.Size(83, 68);
            this.deleteschedclick.TabIndex = 7;
            this.deleteschedclick.Text = "DELETE SCHED";
            this.deleteschedclick.UseVisualStyleBackColor = true;
            // 
            // messageclick
            // 
            this.messageclick.Location = new System.Drawing.Point(27, 357);
            this.messageclick.Name = "messageclick";
            this.messageclick.Size = new System.Drawing.Size(83, 68);
            this.messageclick.TabIndex = 8;
            this.messageclick.Text = "MESSAGE";
            this.messageclick.UseVisualStyleBackColor = true;
            // 
            // settingsclick
            // 
            this.settingsclick.Location = new System.Drawing.Point(143, 357);
            this.settingsclick.Name = "settingsclick";
            this.settingsclick.Size = new System.Drawing.Size(83, 68);
            this.settingsclick.TabIndex = 9;
            this.settingsclick.Text = "SETTINGS";
            this.settingsclick.UseVisualStyleBackColor = true;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(106, 147);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(38, 13);
            this.userName.TabIndex = 10;
            this.userName.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "TODAY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "MONTH / WEEK / DAY";
            // 
            // useremail
            // 
            this.useremail.AutoSize = true;
            this.useremail.Location = new System.Drawing.Point(106, 160);
            this.useremail.Name = "useremail";
            this.useremail.Size = new System.Drawing.Size(31, 13);
            this.useremail.TabIndex = 13;
            this.useremail.Text = "email";
            // 
            // locationview1
            // 
            this.locationview1.HideSelection = false;
            this.locationview1.Location = new System.Drawing.Point(774, 181);
            this.locationview1.Name = "locationview1";
            this.locationview1.Size = new System.Drawing.Size(156, 95);
            this.locationview1.TabIndex = 14;
            this.locationview1.UseCompatibleStateImageBehavior = false;
            // 
            // locationview2
            // 
            this.locationview2.HideSelection = false;
            this.locationview2.Location = new System.Drawing.Point(774, 282);
            this.locationview2.Name = "locationview2";
            this.locationview2.Size = new System.Drawing.Size(156, 99);
            this.locationview2.TabIndex = 15;
            this.locationview2.UseCompatibleStateImageBehavior = false;
            // 
            // locationview3
            // 
            this.locationview3.HideSelection = false;
            this.locationview3.Location = new System.Drawing.Point(774, 387);
            this.locationview3.Name = "locationview3";
            this.locationview3.Size = new System.Drawing.Size(156, 99);
            this.locationview3.TabIndex = 16;
            this.locationview3.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 501);
            this.Controls.Add(this.locationview3);
            this.Controls.Add(this.locationview2);
            this.Controls.Add(this.locationview1);
            this.Controls.Add(this.useremail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.settingsclick);
            this.Controls.Add(this.messageclick);
            this.Controls.Add(this.deleteschedclick);
            this.Controls.Add(this.editschedclick);
            this.Controls.Add(this.calendarclick);
            this.Controls.Add(this.viewsched);
            this.Controls.Add(this.newschedule);
            this.Controls.Add(this.listViewdaymonthandweek);
            this.Controls.Add(this.profilepicture);
            this.Controls.Add(this.listviewcalendar);
            this.Name = "Form1";
            this.Text = "email";
            ((System.ComponentModel.ISupportInitialize)(this.profilepicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listviewcalendar;
        private System.Windows.Forms.ColumnHeader Sun;
        private System.Windows.Forms.ColumnHeader Mon;
        private System.Windows.Forms.ColumnHeader Tue;
        private System.Windows.Forms.ColumnHeader Wed;
        private System.Windows.Forms.ColumnHeader Thu;
        private System.Windows.Forms.ColumnHeader FRI;
        private System.Windows.Forms.PictureBox profilepicture;
        private System.Windows.Forms.ColumnHeader Sat;
        private System.Windows.Forms.ListView listViewdaymonthandweek;
        private System.Windows.Forms.Button newschedule;
        private System.Windows.Forms.Button viewsched;
        private System.Windows.Forms.Button calendarclick;
        private System.Windows.Forms.Button editschedclick;
        private System.Windows.Forms.Button deleteschedclick;
        private System.Windows.Forms.Button messageclick;
        private System.Windows.Forms.Button settingsclick;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label useremail;
        private System.Windows.Forms.ListView locationview1;
        private System.Windows.Forms.ListView locationview2;
        private System.Windows.Forms.ListView locationview3;
    }
}

