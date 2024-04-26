using System;
using System.IO;
using System.Net;

namespace Encryption
{
    class UpdateChecker
    {
        public static void Update()
        {
            string currentVersion = "v1.0.1";
            char firstChar = currentVersion[1];
            char secondChar = currentVersion[3];
            char thirdChar = currentVersion[5];

            int firstInt = int.Parse(firstChar.ToString());
            int secondInt = int.Parse(secondChar.ToString());
            int thirdInt = int.Parse(thirdChar.ToString());

            int firstIntModified = firstInt + 1;
            int secondIntModified = secondInt + 1;
            int thirdIntModified = thirdInt + 1;

            string firstStrModified = firstIntModified.ToString();
            string secondStrModified = secondIntModified.ToString();
            string thirdStrModified = thirdIntModified.ToString();

            string firstPossiblePatch = $"v{firstStrModified}.{secondChar}.{thirdChar}";
            string secondPossiblePatch = $"v{firstChar}.{secondStrModified}.{thirdChar}";
            string thirdPossiblePatch = $"v{firstChar}.{secondChar}.{thirdStrModified}";

            LatestVersion(firstPossiblePatch);
            LatestVersion(secondPossiblePatch);
            LatestVersion(thirdPossiblePatch);
        }

        public static void LatestVersion(string tag)
        {
            try
            {
                // URL-encode the tag
                string encodedTag = Uri.EscapeDataString(tag);

                // Add a forward slash before the tag in the URL
                string url = $"https://api.github.com/repos/Hav1ck/AuthenticationProgram/releases/tags/{encodedTag}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "AuthenticationProgram"; // Replace "Your-App-Name" with an appropriate user-agent string

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("You can download new version at: https://github.com/Hav1ck/AuthenticationProgram");
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Do nothing for now if the tag doesn't exist
                    }
                    else
                    {
                        Console.WriteLine($"Failed to check latest release information. Response code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking for updates: " + ex.Message);
            }
        }
    }
}
