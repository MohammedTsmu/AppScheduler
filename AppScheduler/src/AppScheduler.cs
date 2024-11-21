using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace AppScheduler.src
{
    public static class AppScheduler
    {
        public static async Task StartScheduleMonitoringAsync()
        {
            while (true)
            {
                var schedules = SettingsManager.LoadSchedules();
                var currentTime = DateTime.Now.ToString("HH:mm");

                foreach (var schedule in schedules.Where(s => s.Time == currentTime))
                {
                    if (schedule.RepeatDaily || schedule.Time == currentTime)
                    {
                        LaunchApp(schedule.AppPath);
                    }
                }

                // Wait for 1 minute before checking again
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        private static void LaunchApp(string appPath)
        {
            try
            {
                Process.Start(appPath);
            }
            catch (Exception ex)
            {
                // Log or handle errors gracefully
                Console.WriteLine($"Failed to launch app: {appPath}. Error: {ex.Message}");
            }
        }
    }
}
