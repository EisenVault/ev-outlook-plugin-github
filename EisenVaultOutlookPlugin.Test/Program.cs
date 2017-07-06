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
    }
}
