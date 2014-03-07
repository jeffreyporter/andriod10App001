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
    public class AddItemActionFixtureTest
    {

        [TestMethod]
        public void testThatWeCanAddItemToBasketx()
        {
            string productcode = "1000600061073";
            int quantitysold = 1;
            decimal pricesold = new decimal(25.99);

            //ActionInterface actionPerformer = new BaseAction();// real server
            ActionInterface actionPerformer = new FakeBaseActionFeatures(); // fake server

            AddItemAction addItemAction = new AddItemAction(actionPerformer);
            Boolean successIN = addItemAction.addItem("9999", "9999", "posclient1", productcode, quantitysold, pricesold);
           

            Assert.IsNotNull(addItemAction);
            Assert.IsTrue(successIN);
        }

       
    }
    
}
