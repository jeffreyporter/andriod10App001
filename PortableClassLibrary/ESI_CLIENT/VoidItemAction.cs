using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    class VoidItemAction
    {
        private readonly ActionInterface actionPerformer;

        public VoidItemAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public bool voidItem(string usercode, string userpasssword, string clientid, string productcode)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "voiditem&id=" + clientid;

            servicerequest servicerequest = createRemoveItemRequest(productcode);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse voidItem response  [" + myServiceResponse + "]");
            return true;
        }

        private static servicerequest createRemoveItemRequest(string productcode)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.async = false;
            servicerequest.ItemElementName = ItemChoiceType.voidlinerequest;
            servicerequest.Item = new voidlinerequesttype();
            ((voidlinerequesttype)servicerequest.Item).productcode = productcode;



            StringWriter textWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(servicerequest.GetType());
            serializer.Serialize(textWriter, servicerequest);
            string payload = textWriter.ToString();
            Debug.WriteLine("payload  voidlinerequesttype  [" + payload + "]");

            return servicerequest;
        }
    }
}
