using Microsoft.Win32;

namespace AppScheduler.Startup
{
    public static class StartupManager
    {
        private static readonly string AppName = "AppScheduler";

        public static void EnableAutoStart()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(AppName, exePath);
            }
        }
    }
}
