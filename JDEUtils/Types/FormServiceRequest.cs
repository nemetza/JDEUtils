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
        public string ssoUniqueId { get; set; }
        public string psToken { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string jasProcessingInstruction { get; set; }
        public bool aliasNaming { get; set; }
        public bool showActionControls { get; set; }
        public string outputType { get; set; }
        public bool includeTimings { get; set; }
        public bool allowCache { get; set; }
        public bool forceUpdate { get; set; }
        public int cacheTime { get; set; }
        public bool setDirtyOnly { get; set; }
        public string findOnEntry { get; set; }
        public string maxPageSize { get; set; }
        public string returnControlIDs { get; set; }
        public string variableNames { get; set; }
        public List<FormAction> formActions { get; set; }
        public string query { get; set; }
        public string formServiceDemo { get; set; }
        public bool batchDataRequest { get; set; }
        public string querystringName { get; set; }
        public string loadBaseFormOnly { get; set; }
        public string formName { get; set; }
        public string formDSTmpl { get; set; }
        public string formDSData { get; set; }
        public string version { get; set; }
        public List<string> formInputs { get; set; }
        public string formServiceAction { get; set; }
        public string stopOnWarning { get; set; }
        public string ignoreFDAFindOnEntry { get; set; }
        public bool bypassFormServiceEREvent { get; set; }
        public string turboMode { get; set; }
        public bool enableAsyncEvents { get; set; }
        public string aggregation { get; set; }

        public FormserviceRequest(string FormName, string Version, string FormServiceAction)
        {
            environment = "";           //Token request utan toltom kuldeskor
            role = "*ALL";              //Ez igy jo minden helyzetben
            //jasserver = "";           //Ezt tilos. null-nak kell lennie   ("http://vs05web:81"-t majd berakja az AIS maga, mert o tudja hol a JAS szerver )
            token = "";                 //Token request utan toltom kuldeskor
            deviceName = "MobileApp";   //Token request utan toltom kuldeskor
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
            // Unknown Property : querystringName 
            loadBaseFormOnly = "false";
            formName = FormName;                            //Parameter
            // Unknown Property : formDSTmpl 
            // Unknown Property : formDSData 
            version = Version;                              //Parameter: Ha nem kell, akkor ZJDE0001
            formInputs = new List<string>();                //FormInterconnect valtozok mehetnenek ide.
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
        public string jasCommand { get; set; }
        public GridAction gridAction { get; set; }

        //Command: SetControlValue, DoAction, ...
        public FormAction(string command, string controlID, string value, string jasCommand=null, GridAction gridAction = null)
        {
            this.command = command;
            this.controlID = controlID;
            this.value = value;
            this.jasCommand = jasCommand;
            this.gridAction = gridAction;
        }
    }

    public class GridAction
    {
        public string gridID { get; set; }
        public List<GridRowUpdateEvent> gridRowUpdateEvents { get; set; }
        public List<GridRowInsertEvent> gridRowInsertEvents { get; set; }
    }

    public class GridColumnEvent
    {
        public string command { get; set; }
        public string columnID { get; set; }
        public string value { get; set; }
    }

    public class GridRowInsertEvent
    {
        public List<GridColumnEvent> gridColumnEvents { get; set; }
    }

    public class GridRowUpdateEvent
    {
        public List<GridColumnEvent> gridColumnEvents { get; set; }
    }
}
