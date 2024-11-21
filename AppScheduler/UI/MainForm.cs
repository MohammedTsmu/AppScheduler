using AppScheduler.src;
using AppScheduler.Startup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace AppScheduler.UI
{
    public partial class MainForm : Form
    {
        private List<string> scheduledApps = new List<string>();
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await AppScheduler.src.AppScheduler.StartScheduleMonitoringAsync();
        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Select an Application";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedApp = openFileDialog.FileName;
                    scheduledApps.Add(selectedApp);
                    lstApps.Items.Add(selectedApp);
                }
            }
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            string scheduleTime = dtpScheduleTime.Value.ToString("HH:mm");
            bool repeatDaily = chkRepeatDaily.Checked;

            // Example: Save to a file or use a settings manager class
            foreach (var app in scheduledApps)
            {
                SettingsManager.SaveSchedule(app, scheduleTime, repeatDaily);
            }

            MessageBox.Show("Schedule saved successfully!");
        }

        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //}
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Prevent the form from closing
            this.Hide();
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(1000, "App Scheduler", "The app is running in the background.", ToolTipIcon.Info);
        }

        //private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        //{

        //}
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartupManager.EnableAutoStart();

            // Populate the installed apps combo box
            var installedApps = AppListHelper.GetInstalledApplications();
            cmbInstalledApps.Items.AddRange(installedApps.ToArray());
        }

        private void btnSelectApp_Click(object sender, EventArgs e)
        {
            string selectedApp = cmbInstalledApps.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedApp))
            {
                string appPath = ExtractInstallPath(selectedApp);
                if (!string.IsNullOrEmpty(appPath))
                {
                    scheduledApps.Add(appPath);
                    lstApps.Items.Add(selectedApp); // Display app name in the list
                }
            }
            else
            {
                MessageBox.Show("Please select an application from the list.");
            }
        }

        // Extract install path from the dropdown entry
        private string ExtractInstallPath(string appEntry)
        {
            int startIndex = appEntry.IndexOf("(");
            int endIndex = appEntry.LastIndexOf(")");

            if (startIndex != -1 && endIndex != -1)
            {
                return appEntry.Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            return appEntry; // Fallback in case no path is present
        }

        //add tooltips to show the installation path for each application.
        private void cmbInstalledApps_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Set a tooltip for each app in the dropdown
            if (e.Index >= 0)
            {
                string itemText = cmbInstalledApps.Items[e.Index].ToString();
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(cmbInstalledApps, itemText);
            }
        }

    }
}
