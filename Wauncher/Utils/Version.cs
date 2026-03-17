using Launcher.Utils;
using Newtonsoft.Json.Linq;

namespace Wauncher.Utils
{
    public static class Version
    {
        public static string Current = "3.0.0";

        public async static Task<string> GetLatestVersion()
        {
#if !DEBUG // otherwise the error message would pop up every time you do a preview in IDE
            try
            {
                string responseString = await Api.GitHub.GetLatestRelease();
                JObject responseJson = JObject.Parse(responseString);

                if (responseJson["tag_name"] == null)
                    throw new Exception("\"tag_name\" doesn't exist in response.");

                return (string?)responseJson["tag_name"] ?? Current;
            }
            catch (Exception e)
            {
                ConsoleManager.ShowError($"Couldn't get the latest version.\nMessage: {e.Message}\nSkipping the update check.");
            }
#endif

            return Current;
        }
    }
}
