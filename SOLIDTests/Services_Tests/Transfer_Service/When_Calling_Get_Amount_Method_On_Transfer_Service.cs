﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Domain;
using DataAccess;
using Moq;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using DataAccessInterfaces;
using Logging;

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
            var serviceCommand = new ServiceCommand() { Service = service, Amount = amount };

            var serviceFactory = new FakeServiceFactory();
            //var repository = new FakeRepository();

            var dataContext = new FakeDataContext();

            var logger = new FakeLogger();

            var transferservice=new TransferService(serviceFactory,dataContext,logger);

            var expectedamount = transferservice.GetAmount(serviceCommand);

            Assert.IsTrue(serviceFactory.getServiceMethodWasCalled);
        }

        [TestMethod]
        [TestCategory("SIDService")]
        public void Then_The_GetService_Method_Of_The_Service_Factory_Was_Called2()
        {
            var mocker = new AutoMocker();
            var fixture = new Fixture();

            mocker.Use<IDataContext>(o => o.GetById<FXData>(It.IsAny<object>()) == new FXData());
            mocker.Use<IService>(o =>o.CalculateAmount(It.IsAny<ServiceCommand>()) == 10.0m);
            var serv = mocker.GetMock<IService>();

            mocker.Use<IServiceFactory>(o => o.GetService(It.IsAny<string>()) == serv.Object);

            var transferService = mocker.CreateInstance<TransferService>();

            var serviceCommand = fixture.Create<ServiceCommand>();

            var expectedamount = transferService.GetAmount(serviceCommand);

            var factory = mocker.GetMock<IServiceFactory>();

            factory.Verify(f => f.GetService(It.IsAny<String>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("SIDService")]
        public void Then_The_Log_Method_Of_The_Logger_Was_Called()
        {
            var mocker = new AutoMocker();
            var fixture = new Fixture();

            mocker.Use<IDataContext>(o => o.GetById<FXData>(It.IsAny<object>()) == new FXData());
            mocker.Use<IService>(o => o.CalculateAmount(It.IsAny<ServiceCommand>()) == 10.0m);
            mocker.Use<ILogger>(o => o.Log(It.IsAny<LogCommand>()) == true );
            var serv = mocker.GetMock<IService>();

            mocker.Use<IServiceFactory>(o => o.GetService(It.IsAny<string>()) == serv.Object);

            var transferService = mocker.CreateInstance<TransferService>();

            var serviceCommand = fixture.Create<ServiceCommand>();
            var expectedamount = transferService.GetAmount(serviceCommand);

            var logger = mocker.GetMock<ILogger>();

            logger.Verify( l => l.Log(It.IsAny<LogCommand>()), Times.Once());
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

        public decimal CalculateAmount(ServiceCommand serviceCommand)
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

        bool IDataContext.IsDirty
        {
            get { throw new NotImplementedException(); }
        }

        bool IDataContext.IsInTransaction
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.Generic.IList<T> IDataContext.GetAll<T>()
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IList<T> IDataContext.GetAll<T>(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IList<T> IDataContext.GetByCriteria<T>(Query query)
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IList<T> IDataContext.GetByCriteria<T>(Query query, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        T IDataContext.GetById<T>(object id)
        {
            return new FXData() { FXRate = 0.6m } as T;
        }

        int IDataContext.GetCount<T>()
        {
            throw new NotImplementedException();
        }

        int IDataContext.GetCount<T>(Query query)
        {
            throw new NotImplementedException();
        }

        void IDataContext.Add(object item)
        {
            throw new NotImplementedException();
        }

        void IDataContext.Delete(object item)
        {
            throw new NotImplementedException();
        }

        void IDataContext.Save(object item)
        {
            throw new NotImplementedException();
        }

        void IDataContext.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        void IDataContext.Commit()
        {
            throw new NotImplementedException();
        }

        void IDataContext.Rollback()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
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

    public class FakeLogger : ILogger
    {
        public bool HasLogged { get; set; }
        public bool Log(LogCommand logCommand)
        {
            HasLogged = true;
            
            return true;
        }
    }


}


