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
    public class AddItemAction 
    {
        private readonly ActionInterface actionPerformer;

        public AddItemAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public bool addItem(string usercode, string userpasssword, string clientid, string productcode, int quantitysold, decimal pricesold)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "additem&id=" + clientid;

            servicerequest servicerequest = createAddItemRequest(productcode, quantitysold, pricesold);

            // create XML from request object
            string xmlPayload = actionPerformer.convertRequestToXML(servicerequest);

            serviceresponse myServiceResponse = actionPerformer.sendRequestAndGetResponse(uri, xmlPayload);

            Debug.WriteLine("Serviceresponse addItemtobasket  [" + myServiceResponse + "]");

         

            return true;
        }





        private static servicerequest createAddItemRequest(string productcode, int quantitysold, decimal pricesold)
        {
            servicerequest servicerequest = new servicerequest();
            servicerequest.ItemElementName = ItemChoiceType.productrequest;
            servicerequest.Item = new producttype();
            ((producttype)servicerequest.Item).productcode = productcode;

            ((producttype)servicerequest.Item).quantitysold = quantitysold;
            ((producttype)servicerequest.Item).quantitysoldSpecified = true;

            ((producttype)servicerequest.Item).pricesold = pricesold;
            ((producttype)servicerequest.Item).pricesoldSpecified = true;


            StringWriter textWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(servicerequest.GetType());
            serializer.Serialize(textWriter, servicerequest);
            string payload = textWriter.ToString();
            Debug.WriteLine("payload   [" + payload + "]");

            return servicerequest;
        }





    }
}
