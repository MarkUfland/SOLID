using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHDataAccess;
using DataAccessInterfaces;
using Domain;

namespace SOLIDTests.Data_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dataContext = new DataContext();

            var fxData = dataContext.GetById<FXData>(1);

        }
    }
}
