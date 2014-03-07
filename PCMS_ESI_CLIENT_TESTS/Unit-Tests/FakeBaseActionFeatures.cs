using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PMCS_ESI_CLIENT.ESI.Client.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PCMS_ESI_CLIENT_TESTS.Unit_Tests
{

    public class FakeBaseActionFeatures : ActionInterface
    {


        public serviceresponse sendRequestAndGetResponse(string uri, string xmlPayload)
        {
            serviceresponse myServiceResponse = new serviceresponse();
            myServiceResponse.statuscode = "200";

            myServiceResponse.reasonresponse = new reasontype[3];
            myServiceResponse.reasonresponse[0] = new reasontype();
            myServiceResponse.reasonresponse[1] = new reasontype();
            myServiceResponse.reasonresponse[2] = new reasontype();


            return myServiceResponse;
        }

        public serviceresponse decodeServiceResponse(Stream readerResponse)
        {
            serviceresponse myServiceResponse = null;
            XmlSerializer serializer = new XmlSerializer(typeof(serviceresponse));
            // Call the Deserialize method to restore the object's state.
            using (readerResponse)
            {
                myServiceResponse = (serviceresponse)serializer.Deserialize(readerResponse);
            }
            return myServiceResponse;

        }


        public string convertRequestToXML(servicerequest servicerequest)
        {
            StringWriter textWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(servicerequest.GetType());
            serializer.Serialize(textWriter, servicerequest);
            string payload = textWriter.ToString();
            Debug.WriteLine("payload   [" + payload + "]");
      
            return payload;
        }

        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
