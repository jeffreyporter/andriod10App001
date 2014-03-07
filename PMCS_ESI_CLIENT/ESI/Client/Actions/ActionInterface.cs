using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public interface ActionInterface
    {
        string convertRequestToXML(servicerequest servicerequest);

        serviceresponse sendRequestAndGetResponse(string uri, string xmlPayload);
    }
}
