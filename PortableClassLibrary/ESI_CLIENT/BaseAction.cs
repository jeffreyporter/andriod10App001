using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Serialization;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public class BaseAction : ActionInterface
    {
        private ManualResetEvent allDone = new ManualResetEvent(false);
        private string xmlPayload = "";
        private serviceresponse myServiceResponse = null;

        public serviceresponse sendRequestAndGetResponse(string uri, string xmlPayload)
        {
            this.xmlPayload = xmlPayload;
            this.myServiceResponse = null;

            // Create a new HttpWebRequest object.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            // Set the Method property to 'POST' to post data to the URI.
            request.Method = "POST";

            // start the asynchronous operation
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);

            // Keep the main thread from continuing while the asynchronous 
            // operation completes. A real world application 
            // could do something useful such as updating its user interface. 
            allDone.WaitOne();


            return myServiceResponse;
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);

            // Convert the string into a byte array. 
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlPayload);

            // Write to the request stream.
            postStream.Write(byteArray, 0, xmlPayload.Length);
            postStream.Flush();

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();

            decodeServiceResponse(streamResponse);

            allDone.Set();
        }

        public void decodeServiceResponse(Stream readerResponse)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(serviceresponse));
            // Call the Deserialize method to restore the object's state.
            using (readerResponse)
            {
                myServiceResponse = (serviceresponse)serializer.Deserialize(readerResponse);
            }

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
