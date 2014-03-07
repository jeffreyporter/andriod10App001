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
    public class LookupItemAction 
    {
        private readonly ActionInterface actionPerformer;

        public LookupItemAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public productdetailtype lookupItem(string usercode, string userpasssword, string clientid, string productcode)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "lookupitem&id=" + clientid;

            servicerequest servicerequest = createLookItemRequest(productcode);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse lookupItem  [" + myServiceResponse + "]");

            if ((myServiceResponse != null) && (myServiceResponse.statuscode.Equals("200")))
            {
                return myServiceResponse.itemresponse;
            }

            return null;
        }

        private static servicerequest createLookItemRequest(string productcode)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.ItemElementName = ItemChoiceType.productrequest;
            servicerequest.Item = new producttype();
            ((producttype)servicerequest.Item).productcode = productcode;

            StringWriter textWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(servicerequest.GetType());
            serializer.Serialize(textWriter, servicerequest);
            string payload = textWriter.ToString();
            Debug.WriteLine("payload   [" + payload + "]");

            return servicerequest;
        }

    }
}
