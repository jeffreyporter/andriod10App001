using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public class GetVoidTransactionReasonsAction
    {
        public string REASONTYPE_VOID = "9";


        private readonly ActionInterface actionPerformer;

        public GetVoidTransactionReasonsAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public reasontype[] getReasons(string usercode, string userpasssword, string clientid)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "reasonlist&id=" + clientid;

            // Create login request object
            servicerequest servicerequest = createRequest(REASONTYPE_VOID);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse reasonlist for void [" + myServiceResponse + "]");
            if (myServiceResponse == null)
            {
                return null;
            }
            else 
            {
                return myServiceResponse.reasonresponse;
            }
        }

        private static servicerequest createRequest(string reasontype)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.ItemElementName = ItemChoiceType.reasonrequest;
            servicerequest.Item = new reasonrequesttype();
            ((reasonrequesttype)servicerequest.Item).reasoncode = reasontype;
            return servicerequest;
        }


    }
}
