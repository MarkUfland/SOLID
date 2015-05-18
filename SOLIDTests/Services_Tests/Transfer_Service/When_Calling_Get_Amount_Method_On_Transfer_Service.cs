﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Domain;
using DataAccess;

namespace SOLIDTests
{
    [TestClass]
    public class When_Calling_Get_Amount_Method_On_Transfer_Service
    {
        [TestMethod]
        [TestCategory("SIDService")]
        public void Then_The_GetService_Method_Of_The_Service_Factory_Was_Called()
        {
           var service = "SID";
            var amount = 10000.0m;

            var serviceFactory = new FakeServiceFactory();
            //var repository = new FakeRepository();

            var dataContext = new FakeDataContext();

            var transferservice=new TransferService(serviceFactory,dataContext);

            var expectedamount = transferservice.GetAmount(service, amount);

            Assert.IsTrue(serviceFactory.getServiceMethodWasCalled);
        }
    }

    public class FakeServiceFactory : IServiceFactory
    {
        public bool getServiceMethodWasCalled { get; set; }

        public IService GetService(string serviceName)
        {
            getServiceMethodWasCalled = true;

            return new FakeService();
        }

    }

    public class FakeService : IService
    {

        public decimal CalculateAmount(decimal amount)
        {
            return 6000.0m;
        }
    }

    public class FakeDataContext : IDataContext
    {

        public System.Collections.Generic.IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<T> GetByCriteria<T>(string query) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(object item)
        {
            throw new NotImplementedException();
        }

        public void Delete(object item)
        {
            throw new NotImplementedException();
        }

        public void Save(object item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class FakeRepository : IDataRepository<FXData>
    {

        public void Create(FXData item)
        {
            throw new NotImplementedException();
        }

        public void Update(FXData item)
        {
            throw new NotImplementedException();
        }

        public void Delete(FXData item)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<FXData> GetAll()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<FXData> GetByCriteria(string query)
        {
            throw new NotImplementedException();
        }

        public FXData GetByKey(object key)
        {
            throw new NotImplementedException();
        }
    }

}

   