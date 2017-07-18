using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data;
using EisenVaultOutlookPlugin.Data.Entity;
using EisenVaultOutlookPlugin.Data.Modul;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace EisenVaultOutlookPlugin.Helper
{
    public class Controller
    {
        public string Error { get; set; }
        public async Task<bool> UploadEmail(Outlook.MailItem item,string nodeId,int? count)
        {
            try
            {
                string name = item.Subject;
                //List<char> invalidFileNameChars = Path.GetInvalidFileNameChars().ToList();
                //invalidFileNameChars.AddRange(Path.GetInvalidPathChars());
                //invalidFileNameChars.AddRange(new char[] { '*', '"', '<', '>', '\\', '/', '.','|' });
                //var filename = new string(name.Select(ch => invalidFileNameChars.Contains(ch) ? Convert.ToChar(invalidFileNameChars.IndexOf(ch) + 65) : ch).ToArray());
                //if (filename.Length > 200)
                //    filename = filename.Substring(0, 200);


                //filename = filename.Replace(".", "");
                //while ((filename.EndsWith(" ")))
                //{
                //    filename = filename.Substring(0, filename.Length-1);
                //}

                string filename = ClearFileName(name);


                // Create Folder
                Nodes node = new Nodes();
                string alt = filename + "_" + (count + 1);
                string folderId = await node.CreateFolder(nodeId, filename, alt);
                if (string.IsNullOrEmpty(folderId))
                {
                    Error = node.Error;
                    return false;
                }

                if (node.UseAlternative)
                    filename = alt;


                // Save Email 
                string messagePath = Option.TempFolder + filename + ".msg";
                item.SaveAs(messagePath, Outlook.OlSaveAsType.olMSGUnicode);

                //Save Attachment
                List<string> AttachmentList = new List<string>();
                foreach (Outlook.Attachment attachment in item.Attachments)
                {
                    if (attachment.Type != Outlook.OlAttachmentType.olByValue)
                        continue;

                    var attachMethod = 0;
                    var attachFlags = 0;

                    string PR_ATTACH_METHOD = "http://schemas.microsoft.com/mapi/proptag/0x37050003";

                    try
                    {
                        attachMethod = attachment.PropertyAccessor.GetProperty(PR_ATTACH_METHOD);
                    }
                    catch (Exception ex)
                    {
                        // skip
                    }

                    string PR_ATTACH_FLAGS = "http://schemas.microsoft.com/mapi/proptag/0x37140003";
                    try
                    {
                        attachFlags = attachment.PropertyAccessor.GetProperty(PR_ATTACH_FLAGS);
                    }
                    catch (Exception ex)
                    {
                        // skip
                    }


                    if (item.BodyFormat == Outlook.OlBodyFormat.olFormatHTML)
                    {
                        if (attachFlags == 4)
                            continue;
                    }
                    if (item.BodyFormat == Outlook.OlBodyFormat.olFormatRichText)
                    {
                        if (attachMethod == 6)
                            continue;
                    }
                    if (item.HTMLBody.Contains("cid:" + attachment.FileName))
                        continue;

                    string path = Option.TempFolder + attachment.FileName;
                    if (path.Length > 245)
                        path = path.Substring(0, 240) + ".." + Path.GetExtension(attachment.FileName);
                    attachment.SaveAsFile(path);
                    AttachmentList.Add(path);
                    Marshal.ReleaseComObject(attachment);

                }

                // Upload File 
                UploadFile uFile = new UploadFile();
                bool isUploaded = await uFile.Upload(folderId, messagePath);
                Error = uFile.Error;
                if (isUploaded)
                {
                    foreach (string attchPath in AttachmentList)
                    {
                        isUploaded = await uFile.Upload(folderId, attchPath);
                        Error = uFile.Error;
                    }
                }

                AttachmentList.Add(messagePath);
                DeleteFolders(AttachmentList);


                return isUploaded;
            }
            finally
            {

            }         
        }

        public static string ClearFileName(string name)
        {

            List<char> invalidFileNameChars = Path.GetInvalidFileNameChars().ToList();
            invalidFileNameChars.AddRange(Path.GetInvalidPathChars());
            invalidFileNameChars.AddRange(new char[] { '*', '"', '<', '>', '\\', '/', '.', '|','-', '?' });
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

        public void DeleteFolders(List<string> paths)
        {
            try
            {
                foreach (string path in paths)
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {

                LogClass.WriteException(ex.Message, ex.StackTrace,
                    ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }

    }
}
