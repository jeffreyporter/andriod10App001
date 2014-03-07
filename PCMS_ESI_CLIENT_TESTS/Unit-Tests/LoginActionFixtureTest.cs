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
    public class LoginActionFixtureTest
    {

        [TestMethod]
        public void testThatWeCanLogin()
        {
            //ActionInterface actionPerformer = new BaseAction();// real server
            ActionInterface actionPerformer = new FakeBaseActionFeatures(); // fake server

            LoginAction loginAction = new LoginAction(actionPerformer);
            Boolean successIN = loginAction.login("9999", "9999", "posclient1");


            Assert.IsNotNull(loginAction);
            Assert.IsTrue(successIN);
        }

    }
}
