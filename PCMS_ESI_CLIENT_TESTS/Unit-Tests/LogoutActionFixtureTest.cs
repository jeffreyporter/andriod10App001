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
    public class LogoutActionFixtureTest
    {

        [TestMethod]
        public void testThatWeCanLogout()
        {
            //ActionInterface actionPerformer = new BaseActionFeatures();// real server
            ActionInterface actionPerformer = new FakeBaseActionFeatures(); // fake server

            LogoutAction logoutAction = new LogoutAction(actionPerformer);
            Boolean successOUT = logoutAction.logout("9999",  "uk_epClientVnP001");


            Assert.IsNotNull(logoutAction);
            Assert.IsTrue(successOUT);
        }

    }
}
