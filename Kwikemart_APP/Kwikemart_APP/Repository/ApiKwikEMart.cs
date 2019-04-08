using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Net;
using System.IO;

namespace Kwikemart_APP.Repository
{
    public class ApiKwikEMart
    {

        private IConfiguration _configuration { get; set; }
        public string _urlWS { get; set; }
        private Encoding _u8 { get; set; }
        public enum HttpMethod
        {
            Get,
            Post
        }

        public ApiKwikEMart(IConfiguration configuration)
        {
            _u8 = Encoding.UTF8;
            _configuration = configuration;
            _urlWS = _configuration.GetSection("ApiSettings:KwikEMart:Url").Value;
        }

        public string Get(string endPoint,Dictionary<string, string> urlParametrosWS = null,string contentType = "application/json;charset=utf-8")
        {
            try
            {
                var urlGet = _urlWS;
                urlGet += endPoint;

                //Get Parameters
                if(urlParametrosWS != null && urlParametrosWS.Count > 0)
                {
                    urlGet = SetUrlParams(urlGet, urlParametrosWS);
                }

                //Creating request
                var request = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(urlGet));
                string json = string.Empty;

                request.Method = HttpMethod.Get.ToString();
                request.ContentType = contentType;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                if (response.StatusCode == HttpStatusCode.OK)
                    json = new StreamReader(stream, _u8).ReadToEnd();

                stream.Close();
                response.Close();
                return json.ToString();
            }
            catch(WebException wex)
            {
                using (WebResponse response = wex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        string textException = new StreamReader(data).ReadToEnd();
                        throw new Exception(textException);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string SetUrlParams(string baseUrl, Dictionary<string, string> urlParametrosWS)
        {
            try
            {
                string result = baseUrl;
                if (urlParametrosWS.Count > 0)
                {
                    int i = 0;
                    foreach (var item in urlParametrosWS)
                    {
                        if (i == 0) result += string.Concat("?", item.Key, "=", item.Value);
                        else result += string.Concat("&", item.Key, "=", item.Value);
                        i++;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
