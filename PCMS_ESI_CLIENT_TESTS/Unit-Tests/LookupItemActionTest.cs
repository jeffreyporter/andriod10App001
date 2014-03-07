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
    public class LookupItemActionTest
    {

        [TestMethod]
        public void testLookupItemAction()
        {
            string productcode = "70024"; 

            //ActionInterface actionPerformerLogin = new BaseAction();// real server
            //ActionInterface actionPerformerLookupItem = new BaseAction();// real server

            ActionInterface actionPerformerLogin = new FakeBaseActionFeatures(); // fake server
            ActionInterface actionPerformerLookupItem = new FakeBaseActionFeatures(); // fake server

            // You might need to login first if no session exists. (when testing aginst real server)
            LoginAction la = new LoginAction(actionPerformerLogin);
            bool succ = la.login("9999", "9999", "posclient1");
            Assert.IsTrue(succ);

            LookupItemAction li = new LookupItemAction(actionPerformerLookupItem);
            productdetailtype success = li.lookupItem("9999", "9999", "posclient1", productcode);

            Assert.IsNotNull(success);
        }

    }
}
