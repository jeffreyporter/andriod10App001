using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS_ESI_CLIENT.ESI.Client.Actions
{
    public class ConfigHolder
    {
        static ConfigHolder()
        {
            BaseURL = "http://127.0.0.1";
            Port = "8080";
            ContextRoot = "/mpos/stream?action=";
        }
        public static string BaseURL { get; set; }

        public static string Port { get; set; }

        public static string ContextRoot { get; set; }
    }
}
