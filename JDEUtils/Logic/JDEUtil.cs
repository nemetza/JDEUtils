using JDEUtils.Types;
using System.IO;
using System.Net;
using System.Text.Json;

namespace JDEUtils.Logic
{
    public class JDEUtil
    {
        private string JdeAisUrl = "";
        private string JdeEnvironment = "";
        private string lastReponseJSON = "";

        private LoginRequest loginRequest;    //Last login's request. Devicename is needed for FormService
        private LoginResponse loginResponse;  //Token we get from JDE. Token needed for FormService

        public JDEUtil()
        {
            JdeAisUrl = "";
            JdeEnvironment = "";
            loginRequest  = null;
            loginResponse = null;
        }

        #region JDE REST API caller functions

        /// <summary>
        ///  JDE login caller function over REST API.
        /// </summary>
        /// <param name="loginRequestData"></param>
        /// <returns></returns>
        public void TokenRequest(string username, string password, string deviceName, string jdeAisUrl, string environment, string role = "*ALL")
        {
            JdeAisUrl = jdeAisUrl;
            JdeEnvironment = environment;
            loginRequest = new LoginRequest(username, password, deviceName, environment, role);

            string jsonDataToSend = generateJSONfromClass(loginRequest);
            string reponseJsonData = sendJsonAndReturnJsonRespose(jsonDataToSend, "tokenrequest");
            loginResponse = generateClassFromJSON<LoginResponse>(reponseJsonData);
        }

        /// <summary>
        ///  JDE Form caller function over REST API. Response is unique so only JSON string is returned
        /// </summary>
        /// <param name="formServiceData"></param>
        /// <returns>JSON string. Caller must use generateClassFromJSON to read its value</returns>
        public T FormService<T>(FormserviceRequest formServiceData)
        {
            formServiceData.token = loginResponse.userInfo.token;
            formServiceData.deviceName = loginRequest.deviceName;
            formServiceData.environment = JdeEnvironment;
            //formServiceData.jasserver = JdeAisUrl;  //Kell ez? Ez a 81-es port-ra mutat, de mi nem hasznalunk AIS-t csak REST-et, nem?  TODO

            string jsonDataToSend = generateJSONfromClass(formServiceData);
            lastReponseJSON = sendJsonAndReturnJsonRespose(jsonDataToSend, "formservice");
            return generateClassFromJSON<T>(lastReponseJSON);
        }

        /// <summary>
        /// Return the last JSON response. May be it is needed somewhere outside too.
        /// </summary>
        /// <returns></returns>
        public string GetLastJsonResponse()
        {
            return lastReponseJSON;
        }
        #endregion

        #region Functions for communicating

        private string generateJSONfromClass<T>(T input)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            //DEBUG: Itt kiirathato mi megy ki
            return JsonSerializer.Serialize(input, options);
        }

        public T generateClassFromJSON<T>(string jsonReceived)
        {
            if (jsonReceived != null)
            {
                return (T)JsonSerializer.Deserialize<T>(jsonReceived, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString |System.Text.Json.Serialization.JsonNumberHandling.WriteAsString });
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

        #endregion
    }
}
