using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDEUtils.Types
{
    /// <summary>
    /// JDE forService class. No need to feed all, just leave as default what is not needed
    /// </summary>
    public class FormserviceRequest
    {
        public string environment { get; set; }
        public string role { get; set; }
        public string jasserver { get; set; }
        public string token { get; set; }
        public string deviceName { get; set; }
        public bool ssoEnabled { get; set; }
        public object ssoUniqueId { get; set; }
        public object psToken { get; set; }
        public object username { get; set; }
        public object password { get; set; }
        public object jasProcessingInstruction { get; set; }
        public bool aliasNaming { get; set; }
        public bool showActionControls { get; set; }
        public string outputType { get; set; }
        public bool includeTimings { get; set; }
        public bool allowCache { get; set; }
        public bool forceUpdate { get; set; }
        public int cacheTime { get; set; }
        public bool setDirtyOnly { get; set; }
        public object findOnEntry { get; set; }
        public string maxPageSize { get; set; }
        public object returnControlIDs { get; set; }
        public object variableNames { get; set; }
        public List<FormAction> formActions { get; set; }
        public object query { get; set; }
        public object formServiceDemo { get; set; }
        public bool batchDataRequest { get; set; }
        public object queryObjectName { get; set; }
        public string loadBaseFormOnly { get; set; }
        public string formName { get; set; }
        public object formDSTmpl { get; set; }
        public object formDSData { get; set; }
        public string version { get; set; }
        public List<object> formInputs { get; set; }
        public string formServiceAction { get; set; }
        public object stopOnWarning { get; set; }
        public object ignoreFDAFindOnEntry { get; set; }
        public bool bypassFormServiceEREvent { get; set; }
        public object turboMode { get; set; }
        public bool enableAsyncEvents { get; set; }
        public object aggregation { get; set; }

        public FormserviceRequest(string FormName, string Version, string FormServiceAction)
        {
            environment = "JDV920";
            role = "*ALL";
            jasserver = "";  //Fill from JDEUtil
            token = "";      //Fill after token request
            deviceName = "MobileApp";
            ssoEnabled = false;
            // Unknown Property : ssoUniqueId 
            // Unknown Property : psToken 
            // Unknown Property : username 
            // Unknown Property : password 
            // Unknown Property : jasProcessingInstruction 
            aliasNaming = false;
            showActionControls = false;
            outputType = "";
            includeTimings = false;
            allowCache = false;
            forceUpdate = false;
            cacheTime = 0;
            setDirtyOnly = false;
            // Unknown Property : findOnEntry 
            maxPageSize = "100";
            // Unknown Property : returnControlIDs 
            // Unknown Property : variableNames 
            formActions = new List<FormAction>();
            // Unknown Property : query 
            // Unknown Property : formServiceDemo 
            batchDataRequest = false;
            // Unknown Property : queryObjectName 
            loadBaseFormOnly = "false";
            formName = FormName;                            //Parameter
            // Unknown Property : formDSTmpl 
            // Unknown Property : formDSData 
            version = Version;                              //Parameter: Ha nem kell, akkor ZJDE0001
            formInputs = new List<object>();                //FormInterconnect valtozok mehetnenek ide.
            formServiceAction = FormServiceAction;          //Parameter e.g: R
            // Unknown Property : stopOnWarning 
            // Unknown Property : ignoreFDAFindOnEntry 
            bypassFormServiceEREvent = false;
            // Unknown Property : turboMode 
            enableAsyncEvents = false;
            // Unknown Property : aggregation 
        }
    }

    public class FormAction
    {
        public string command { get; set; }
        public string controlID { get; set; }
        public string value { get; set; }
        public object jasCommand { get; set; }
        public object gridAction { get; set; }
    }
}
