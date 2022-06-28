using JDEUtils.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDEUtils.Logic
{
    public class JDEUtil
    {
        private string JdeAisUrl = "http://vs05web:91/jderest/"; 
        private LoginResponse lastResponse = null;  //Token we get from JDE. Store
        public JDEUtil(string url)
        {
            JdeAisUrl = url;
        }

        public bool tokenRequest(LoginRequest loginData)
        {
            try
            {
                string jsonDataToSend = generateJSONfromClass(loginData);
                string reponseJsonData = sendJsonAndReturnJsonRespose(jsonDataToSend, "tokenrequest");
                lastResponse = generateClassFromJSON<LoginResponse>(reponseJsonData);
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private string generateJSONfromClass<T>(T input)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            //DEBUG: Itt kiirathato mi megy ki
            return JsonSerializer.Serialize(input, options);
        }

        private T generateClassFromJSON<T>(string jsonReceived)
        {
            if (jsonReceived != null)
            {
                T? result =JsonSerializer.Deserialize<T>(jsonReceived);
            }

            return default(T);
        }
        
        private string sendJsonAndReturnJsonRespose(string jsonToSend, string serviceUrl)
        {
            string result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(JdeAisUrl + serviceUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonToSend);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}
