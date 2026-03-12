using Launcher.Utils;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Wauncher.Utils
{
    public class Services
    {
        public static async Task GetLatestRelease(string latestVersion)
        {

            string updaterPath = Path.Combine(AppContext.BaseDirectory, "updater.exe");
            await DownloadManager.DownloadUpdater(updaterPath);

            Process updaterProcess = new Process();
            updaterProcess.StartInfo.FileName = updaterPath;
            updaterProcess.StartInfo.Arguments = $"--version={latestVersion} --ui";
            updaterProcess.Start();

            Environment.Exit(0);
            return;
        }
        public static string GetMd5(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            try
            {
                var byteOld = Encoding.UTF8.GetBytes(str);
                var byteNew = MD5.HashData(byteOld);
                StringBuilder sb = new(32);
                foreach (var b in byteNew)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static string GetExePath()
        {
            return Environment.ProcessPath ?? Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
        }

        public static bool IsWindows() => OperatingSystem.IsWindows();
    }
}
