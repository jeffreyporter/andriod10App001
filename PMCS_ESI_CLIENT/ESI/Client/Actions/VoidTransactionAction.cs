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
    public class VoidTransactionAction 
    {
        private readonly ActionInterface actionPerformer;

        public VoidTransactionAction(ActionInterface actionPerformer)
        {
            this.actionPerformer = actionPerformer;
        }

        public bool voidTransaction(string usercode, string userpasssword, string clientid)
        {
            string uri = ConfigHolder.BaseURL + ":" + ConfigHolder.Port + ConfigHolder.ContextRoot + "voidtransaction&id=" + clientid;


            serviceresponse myServiceResponseVoidTransaction = actionPerformer.sendRequestAndGetResponse(uri, "");
            Debug.WriteLine("Serviceresponse void trasnsaction, expect null  [" + myServiceResponseVoidTransaction + "]");

            return true;
        }

    }
}
