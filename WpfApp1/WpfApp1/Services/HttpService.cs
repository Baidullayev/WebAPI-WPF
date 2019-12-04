using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WpfApp1.Services
{
    class HttpService
    {
        public string HttpWebRequest(object jsonObject = null, string url = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            if (App.userToken != null && App.username != null)
            {
                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Headers.Set("authorization", "Bearer " + App.userToken);
            }
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    if(jsonObject != null)
                    {
                        streamWriter.Write(jsonObject.ToString());
                    }
                    
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse != null)
                {

                    string statusCode = httpResponse.StatusCode.ToString();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Something went wrong";
        }
    }
}
