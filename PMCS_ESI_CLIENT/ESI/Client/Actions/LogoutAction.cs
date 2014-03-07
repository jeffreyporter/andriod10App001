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
    public class LogoutAction 
    {
         private readonly ActionInterface actionPerformer;

         public LogoutAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;

        }
        public bool logout(string usercode, string clientid)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "signoff&id=" + clientid;

            // Create login request object
            servicerequest servicerequest = createLogoutRequest(usercode);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse signout [" + myServiceResponse + "]");
            return true;
        }


        public static servicerequest createLogoutRequest(string usercode)
        {
            servicerequest servicerequest = new servicerequest();
            //((signontype)servicerequest.Item).usercode = usercode; 
            return servicerequest;
        }

 



      

       

   



    }
}
