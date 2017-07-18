using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data;
using EisenVaultOutlookPlugin.Data.Modul;

namespace EisenVaultOutlookPlugin.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "a.s/d|a<>a     ";
            var x = ClearFileName(filename);
            Console.WriteLine(x);

            //Account acc = new Account();
            //acc.Loign("https://autoinstallexample.eisenvault.net/", "admin", "admin");

            Option.Read();
            //Nodes node = new Nodes();
            //node.Get();
            //node.Get("4f6ae7e0-5c6c-4082-b651-7da7484df109");
            string path = @"G:\System\My Desktop\PTest\Productivity App Overload.msg";
            //API.Upload("/alfresco/api/-default-/public/alfresco/versions/1/nodes/-my-/children", null, path);

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
              //  API.Upload("/alfresco/api/-default-/public/alfresco/versions/1/nodes/-my-/children", stream, "Productivity App Overload");
            }
            Nodes node = new Nodes();
            node.CreateFolder("-my-", "NEw Folder");

        }


        public static string ClearFileName(string name)
        {

            List<char> invalidFileNameChars = Path.GetInvalidFileNameChars().ToList();
            invalidFileNameChars.AddRange(Path.GetInvalidPathChars());
            invalidFileNameChars.AddRange(new char[] { '*', '"', '<', '>', '\\', '/', '.', '|' });
            invalidFileNameChars = invalidFileNameChars.Distinct().ToList();
            var filename = invalidFileNameChars.Aggregate(name, (current, c) => current.Replace(c.ToString(), ""));
                        
            if (filename.Length > 200)
                filename = filename.Substring(0, 200);


            filename = filename.Replace(".", "");
            while ((filename.EndsWith(" ")))
            {
                filename = filename.Substring(0, filename.Length - 1);
            }

            return filename;
        }
    }
}
