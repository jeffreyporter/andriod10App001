using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public class LogReasonAction 
    {
        private readonly ActionInterface actionPerformer;

        public LogReasonAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }


        public bool logReason(string usercode, string userpasssword, string clientid, string reasonCode)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "logreason&id=" + clientid;

            // Create login request object
            servicerequest servicerequest = createLogReasonRequest(reasonCode);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse log reason code [" + myServiceResponse + "]");
            return (myServiceResponse != null);
        }

        private static servicerequest createLogReasonRequest(string reasonCode)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.ItemElementName =  ItemChoiceType.logreasonrequest;

            servicerequest.Item = new logreasonrequesttype();
            //((logreasonrequesttype)servicerequest.Item).reasoncategory = ?
            ((logreasonrequesttype)servicerequest.Item).reasoncode = reasonCode;
            //((logreasonrequesttype)servicerequest.Item).itemcode = ?
            //((logreasonrequesttype)servicerequest.Item).itemdescription = ?
            //((logreasonrequesttype)servicerequest.Item).itemlinenumber = ?

            // SUB REASONS..
            // 1
            //((logreasonrequesttype)servicerequest.Item).Item = new agereasondetailstype();
            //((agereasondetailstype)((logreasonrequesttype)servicerequest.Item).Item).agevalidated = ?
            //((agereasondetailstype)((logreasonrequesttype)servicerequest.Item).Item).requiredage = ?

            // 2
            //((logreasonrequesttype)servicerequest.Item).Item = new requestextensiontype();
            // no values to set.

            // 3
            //((logreasonrequesttype)servicerequest.Item).Item = new restricteditemdetailstype();
            //((restricteditemdetailstype)((logreasonrequesttype)servicerequest.Item).Item).messagenumber = ?
            //((restricteditemdetailstype)((logreasonrequesttype)servicerequest.Item).Item).suppliercode = ?


            return servicerequest;
        }

    }
}
