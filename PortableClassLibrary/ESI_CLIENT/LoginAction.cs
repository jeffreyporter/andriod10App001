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
    public class LoginAction
    {
        private readonly ActionInterface actionPerformer;

        public LoginAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public bool login(string usercode, string userpasssword, string clientid)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "signon&id=" + clientid;

            // Create login request object
            servicerequest servicerequest = createLoginRequest(usercode, userpasssword);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse signin status code [" + myServiceResponse + "]");
           return ((myServiceResponse != null) && (myServiceResponse.statuscode.Equals("200")));
        }

        private static servicerequest createLoginRequest(string usercode, string userpasssword)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.ItemElementName = ItemChoiceType.signonrequest;
            servicerequest.Item = new signontype();
            ((signontype)servicerequest.Item).usercode = usercode; 
            ((signontype)servicerequest.Item).userpassword = userpasssword;
            return servicerequest;
        }

    }
}
