using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PMCS_ESI_CLIENT.ESI.Client.Actions;



namespace PCMS_ESI_CLIENT_TESTS.Unit_Tests
{
    [TestClass]
    public class LogReasonActionTest
    {

        [TestMethod]
        public void testLogReasonAction()
        {
            string reasonCode = "9"; // void - Customer Walked out

            //ActionInterface actionPerformerLogin = new BaseAction();// real server
            //ActionInterface actionPerformerLogReason = new BaseAction();// real server

            ActionInterface actionPerformerLogin = new FakeBaseActionFeatures(); // fake server
            ActionInterface actionPerformerLogReason = new FakeBaseActionFeatures(); // fake server

            // You might need to login first if no session exists. (when testing aginst real server)
            LoginAction la = new LoginAction(actionPerformerLogin);
            bool succ = la.login("9999", "9999", "posclient1");
            Assert.IsTrue(succ);

            LogReasonAction lra = new LogReasonAction(actionPerformerLogReason);
            bool success = lra.logReason("9999", "9999", "posclient1", reasonCode);

            Assert.IsTrue(success);
        }

    }
}
