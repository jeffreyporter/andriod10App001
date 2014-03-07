using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public class SuspendTransactionAction 
    {
        private readonly ActionInterface actionPerformer;

        public SuspendTransactionAction(ActionInterface mailSender)
        {
            this.actionPerformer = mailSender;
        }

        public bool suspend(string usercode, string userpasssword, string clientid, string reference)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "suspendtransaction&id=" + clientid;

            // Create login request object
            servicerequest servicerequest = createSuspendRequest(usercode, userpasssword, reference);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse signin [" + myServiceResponse + "]");
            return true;
        }





        private static servicerequest createSuspendRequest(string usercode, string userpasssword, string reference)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.async = false;
            servicerequest.ItemElementName = ItemChoiceType.txnsuspendrequest;
            servicerequest.Item = new txnsuspendtype();
            ((txnsuspendtype)servicerequest.Item).suspendref = reference; 
            return servicerequest;
        }





    }
}
