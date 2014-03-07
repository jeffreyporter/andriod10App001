﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PMCS_ESI_CLIENT.ESI.Client.Actions;



namespace PCMS_ESI_CLIENT_TESTS.Unit_Tests
{
    [TestClass]
    public class GetTransactionReasonActionTest
    {

        [TestMethod]
        public void testGetVoidTransactionReasons()
        {
            //ActionInterface actionPerformerLogin = new BaseAction();// real server
            //ActionInterface actionPerformerVoid = new BaseAction();// real server

            ActionInterface actionPerformerLogin = new FakeBaseActionFeatures(); // fake server
            ActionInterface actionPerformerVoid = new FakeBaseActionFeatures(); // fake server

            // You might need to login first if no session exists. (when testing aginst real server)
            LoginAction la = new LoginAction(actionPerformerLogin);
            bool succ = la.login("9999", "9999", "posclient1");
            Assert.IsTrue(succ);

            GetVoidTransactionReasonsAction gvtr = new GetVoidTransactionReasonsAction(actionPerformerVoid);
            reasontype[] reasons = gvtr.getReasons("9999", "9999", "posclient1");

            Assert.IsNotNull(reasons);
            Assert.AreEqual(3, reasons.Length);
        }

    }
}
