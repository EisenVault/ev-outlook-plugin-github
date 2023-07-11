using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Modul;
using Newtonsoft.Json;

namespace EisenVaultOutlookPlugin.Data
{
    public class API
    {
        public static int StatusCode { get; set; }
        public static bool IsSuccessStatus { get; set; }

        public static async Task<string> Get(string module, Dictionary<string, string> parameter = null)
        {
            var userInfo = Option.GetUserInfo();
            string url = userInfo.Server + module;
            string username = userInfo.UserName;
            string password = userInfo.Password;
            if (parameter != null)
            {
                url = parameter.Keys.Aggregate(url, (current, key) => current + ("&" + key + "=" + parameter[key]));
            }
            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                           SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12 ;
                    client.Timeout = new TimeSpan(1, 0, 0); // 1 hour
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                    client.DefaultRequestHeaders.Authorization = authValue;
                    HttpResponseMessage response = await client.GetAsync(url);
                    StatusCode = (int)response.StatusCode;
                    IsSuccessStatus = response.IsSuccessStatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString = await responseContent.ReadAsStringAsync();
                        return responseString;
                    }
                    else
                    {
                        LogClass.WriteWbLog("", "", "", "GET", module, string.Format("Response Exception with status code : {0}", response.StatusCode), url);
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteWbLog("", "", "", "GET", module, ex.Message, url);
            }
            return "";
        }

        public static async Task<string> Auth(string url,string username,string password)
        {            
            var content = new StringContent($"{{\"userId\": \"{username}\",\"password\": \"{password}\"}}", Encoding.UTF8, "application/json");
            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                           SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12 ;
                    client.Timeout = new TimeSpan(1, 0, 0);// 1 hour
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    StatusCode = (int)response.StatusCode;
                    IsSuccessStatus = response.IsSuccessStatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString =await responseContent.ReadAsStringAsync();                      
                        return responseString;
                    }
                    else
                    {
                        LogClass.WriteWbLog("", "", "", "POST", url, string.Format("Response Exception with status code : {0}", response.StatusCode), url);
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteWbLog("", "", "", "POST", url, ex.Message, url);
            }

            return "";
        }

        public static async Task<string> Upload(string module, string path)
        {
            var userInfo = Option.GetUserInfo();
            string url = userInfo.Server + module;
            string username = userInfo.UserName;
            string password = userInfo.Password;
            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                           SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12 ;
                    client.Timeout = new TimeSpan(1, 0, 0); // 1 hour
                    var authValue = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                    client.DefaultRequestHeaders.Authorization = authValue;

                    MultipartFormDataContent form = new MultipartFormDataContent();
                    using (FileStream fs = File.OpenRead(path))
                    {
                        var streamContent = new StreamContent(fs);
                        var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(imageContent, "filedata", Path.GetFileName(path));
                    }                    
                    

                    
                    var response =await client.PostAsync(url, form);
                    StatusCode = (int)response.StatusCode;
                    IsSuccessStatus = response.IsSuccessStatusCode;
                    var responseContent = response.Content;
                    string responseString = await responseContent.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {                        
                        
                    }
                    else
                    {
                        LogClass.WriteWbLog("", "", "", "Upload", module,
                            string.Format("Response Exception with status code : {0}"+ "Output :" + responseString, response.StatusCode), url);
                    }
                    return responseString;
                }
            }
            catch (Exception ex)
            {

                LogClass.WriteWbLog("", "", "", "Upload Exception", module, ex.Message, url);
            }
            return "";
        }

        public static async Task<string> Post(string module, List<KeyValuePair<string, string>> parameter = null)
        {
            var userInfo = Option.GetUserInfo();
            string url = userInfo.Server + module;
            string username = userInfo.UserName;
            string password = userInfo.Password;
            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                           SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12 ;
                    client.Timeout = new TimeSpan(1, 0, 0); // 1 hour
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                    client.DefaultRequestHeaders.Authorization = authValue;

                    string json = "{";
                    if (parameter != null)
                    {
                        foreach (KeyValuePair<string, string> pair in parameter)
                        {
                            json += $"\"{pair.Key}\":\"{pair.Value}\",";
                        }
                        json = json.TrimEnd(',');
                        
                    }
                    json += "}";

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    StatusCode = (int)response.StatusCode;
                    IsSuccessStatus = response.IsSuccessStatusCode;

                    var responseContent = response.Content;
                    string responseString = await responseContent.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    else
                    {
                        LogClass.WriteWbLog("", "", "", "Upload", module,
                            string.Format("Response Exception with status code : {0}" + "Output : {1}" ,
                                response.StatusCode, responseString), url);
                    }

                    return responseString;
                    
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteWbLog("", "", "", "Upload", module, ex.Message, url);
            }
            return "";
        }
    }
}
