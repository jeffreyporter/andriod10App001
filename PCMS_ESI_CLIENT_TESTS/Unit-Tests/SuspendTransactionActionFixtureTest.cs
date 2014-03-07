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
    public class SuspendTransactionActionFixtureTest
    {

        [TestMethod]
        public void testThatWeCanSuspendTransaction()
        {
            //ActionInterface actionPerformer = new BaseActionFeatures();// real server
            ActionInterface actionPerformer = new FakeBaseActionFeatures(); // fake server

            SuspendTransactionAction suspendTransaction = new SuspendTransactionAction(actionPerformer);
            Boolean successIN = suspendTransaction.suspend("9999", "9999", "uk_epClientVnP001", "Reference-mpos-Win8");


            Assert.IsNotNull(suspendTransaction);
            Assert.IsTrue(successIN);
        }

    }
}
