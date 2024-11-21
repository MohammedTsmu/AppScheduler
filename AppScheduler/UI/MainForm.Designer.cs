namespace AppScheduler.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddApp = new System.Windows.Forms.Button();
            this.lstApps = new System.Windows.Forms.ListBox();
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.chkRepeatDaily = new System.Windows.Forms.CheckBox();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbInstalledApps = new System.Windows.Forms.ComboBox();
            this.btnSelectApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddApp
            // 
            this.btnAddApp.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddApp.Location = new System.Drawing.Point(12, 273);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(229, 51);
            this.btnAddApp.TabIndex = 0;
            this.btnAddApp.Text = "Add Application";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // lstApps
            // 
            this.lstApps.AccessibleDescription = "Function: Displays the list of selected apps.\n";
            this.lstApps.AccessibleName = "List Box";
            this.lstApps.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstApps.FormattingEnabled = true;
            this.lstApps.ItemHeight = 16;
            this.lstApps.Location = new System.Drawing.Point(13, 7);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(229, 52);
            this.lstApps.TabIndex = 1;
            this.toolTip1.SetToolTip(this.lstApps, "Select an app and schedule");
            // 
            // dtpScheduleTime
            // 
            this.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpScheduleTime.Location = new System.Drawing.Point(12, 245);
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            this.dtpScheduleTime.Size = new System.Drawing.Size(200, 22);
            this.dtpScheduleTime.TabIndex = 2;
            // 
            // chkRepeatDaily
            // 
            this.chkRepeatDaily.AccessibleDescription = "Check Box";
            this.chkRepeatDaily.AccessibleName = "Repeat Daily";
            this.chkRepeatDaily.AutoSize = true;
            this.chkRepeatDaily.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepeatDaily.Location = new System.Drawing.Point(12, 219);
            this.chkRepeatDaily.Name = "chkRepeatDaily";
            this.chkRepeatDaily.Size = new System.Drawing.Size(107, 20);
            this.chkRepeatDaily.TabIndex = 3;
            this.chkRepeatDaily.Text = "Repeat Daily";
            this.chkRepeatDaily.UseVisualStyleBackColor = true;
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.AccessibleDescription = "Function: Saves the schedule.\n";
            this.btnSaveSchedule.AccessibleName = "Save schedule.";
            this.btnSaveSchedule.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSchedule.Location = new System.Drawing.Point(12, 330);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(229, 51);
            this.btnSaveSchedule.TabIndex = 0;
            this.btnSaveSchedule.Text = "Save Schedule";
            this.btnSaveSchedule.UseVisualStyleBackColor = true;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "App Scheduler";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select an app and schedule";
            // 
            // cmbInstalledApps
            // 
            this.cmbInstalledApps.FormattingEnabled = true;
            this.cmbInstalledApps.Location = new System.Drawing.Point(248, 7);
            this.cmbInstalledApps.Name = "cmbInstalledApps";
            this.cmbInstalledApps.Size = new System.Drawing.Size(540, 24);
            this.cmbInstalledApps.TabIndex = 5;
            // 
            // btnSelectApp
            // 
            this.btnSelectApp.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectApp.Location = new System.Drawing.Point(12, 387);
            this.btnSelectApp.Name = "btnSelectApp";
            this.btnSelectApp.Size = new System.Drawing.Size(229, 51);
            this.btnSelectApp.TabIndex = 0;
            this.btnSelectApp.Text = "Select Application";
            this.btnSelectApp.UseVisualStyleBackColor = true;
            this.btnSelectApp.Click += new System.EventHandler(this.btnSelectApp_Click);
            // 
            // MainForm
            // 
            this.AccessibleDescription = "Function: Opens a dialog to select an application.\n";
            this.AccessibleName = "Add Application";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbInstalledApps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRepeatDaily);
            this.Controls.Add(this.dtpScheduleTime);
            this.Controls.Add(this.lstApps);
            this.Controls.Add(this.btnSaveSchedule);
            this.Controls.Add(this.btnSelectApp);
            this.Controls.Add(this.btnAddApp);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.ListBox lstApps;
        private System.Windows.Forms.DateTimePicker dtpScheduleTime;
        private System.Windows.Forms.CheckBox chkRepeatDaily;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbInstalledApps;
        private System.Windows.Forms.Button btnSelectApp;
    }
}

