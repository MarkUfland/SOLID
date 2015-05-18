using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace SOLIDTests
{
    [TestClass]
    public class When_Calling_Calculate_Transfer_Method_On_SID_Class
    {
        [TestMethod]
        public void Then_6000_Is_Returned()
        {
            var amount = 10000.0m;

            var sidService = new SIDService();

            var expectedAmount = sidService.CalculateAmount(amount);

            Assert.AreEqual(6000, expectedAmount);
        }
    }

    
}
