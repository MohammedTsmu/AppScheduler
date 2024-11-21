using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace AppScheduler.src
{
    public static class SettingsManager
    {
        private static readonly string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schedules.json");

        public static void SaveSchedule(string appPath, string time, bool repeatDaily)
        {
            var schedules = LoadSchedules();

            schedules.Add(new Schedule
            {
                AppPath = appPath,
                Time = time,
                RepeatDaily = repeatDaily
            });

            File.WriteAllText(settingsFile, JsonConvert.SerializeObject(schedules, Newtonsoft.Json.Formatting.Indented));
        }

        public static List<Schedule> LoadSchedules()
        {
            if (!File.Exists(settingsFile))
                return new List<Schedule>();

            string json = File.ReadAllText(settingsFile);
            return JsonConvert.DeserializeObject<List<Schedule>>(json) ?? new List<Schedule>();
        }
    }

    public class Schedule
    {
        public string AppPath { get; set; }
        public string Time { get; set; }
        public bool RepeatDaily { get; set; }
    }

    public static class AppListHelper
    {
        public static List<string> GetInstalledApplications()
        {
            var installedApps = new List<string>();

            // Fetch traditional apps from the registry
            installedApps.AddRange(GetTraditionalApps());

            // Fetch Microsoft Store apps using PowerShell
            installedApps.AddRange(GetStoreApps());

            // Remove duplicates and sort alphabetically
            return installedApps.Distinct().OrderBy(app => app).ToList();
        }

        private static List<string> GetTraditionalApps()
        {
            var apps = new List<string>();
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            string appName = subKey?.GetValue("DisplayName") as string;
                            if (!string.IsNullOrEmpty(appName) && !IsIrrelevantApp(appName))
                            {
                                apps.Add(appName);
                            }
                        }
                    }
                }
            }

            return apps;
        }

        private static List<string> GetStoreApps()
        {
            var storeApps = new List<string>();
            try
            {
                // Run PowerShell command to fetch DisplayName
                string script = "Get-AppxPackage | Select-Object -ExpandProperty DisplayName";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-Command \"Start-Process powershell -ArgumentList '-NoProfile -Command \"{script}\"' -Verb runAs\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = true, // UseShellExecute must be true for runAs
                    CreateNoWindow = true,
                    Verb = "runAs" // Elevates privileges
                };

                using (Process process = Process.Start(psi))
                {
                    using (var reader = process.StandardOutput)
                    {
                        string output = reader.ReadToEnd();
                        foreach (var line in output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!string.IsNullOrWhiteSpace(line) && !IsIrrelevantApp(line))
                            {
                                storeApps.Add(line.Trim());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching store apps: {ex.Message}");
                Console.WriteLine("Insufficient permissions to retrieve Microsoft Store apps. Please run the application as an administrator.");
            }

            return storeApps;
        }



        private static bool IsIrrelevantApp(string appName)
        {
            string lowerAppName = appName.ToLower();
            return lowerAppName.Contains("runtime") ||
                   lowerAppName.Contains("framework") ||
                   lowerAppName.Contains("sdk") ||
                   lowerAppName.Contains("windows") ||
                   lowerAppName.Contains("system") ||
                   lowerAppName.Length < 3; // Exclude very short names
        }

    }
}
