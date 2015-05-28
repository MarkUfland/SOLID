using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Domain;
using Ploeh.AutoFixture;
using Presenters;
using Moq.AutoMock;
using Moq;
using DataAccessInterfaces;

namespace SOLIDTests.Presenter_Tests
{
    [TestClass]
    public class WhenCallingTheCalculateMethod
    {
        [TestMethod]
        public void Then_The_ServiceCommand_Object_Is_Correctly_Mapped()
        {
            var fixture             = new Fixture();
            var solidVM             = fixture.Create<SOLIDVM>();
            var fakeTransferService = new FakeTransferService();
            var fakeSOLIDView       = new fakeSOLIDView();
            var solidPresenter      = new SOLIDPresenter( fakeTransferService );

            solidPresenter.Initialise( fakeSOLIDView );
            solidPresenter.CalculateTransfer( solidVM );

            Assert.AreEqual( solidVM.Amount, fakeTransferService.ServiceCommand.Amount );
        }

        [TestMethod]
        public void Then_The_ServiceCommand_Object_Is_Correctly_Mapped2()
        {
            var mocker = new AutoMocker();

            mocker.Use<IDataContext>(o => o.GetById<FXData>(It.IsAny<object>()) == new FXData());
            
            var serv = mocker.GetMock<IService>();

            mocker.Use<IServiceFactory>(o => o.GetService(It.IsAny<string>()) == serv.Object);

            var mockTransferService = new Mock<ITransferService>();
            mockTransferService.Setup( x => x.GetAmount( It.IsAny<ServiceCommand>()));

            var solidPresenter      = new SOLIDPresenter( mockTransferService.Object );
            var fixture             = new Fixture();
            var solidVM             = fixture.Create<SOLIDVM>();
            var mockView            = mocker.GetMock<ISOLIDView>();
            var serviceCommand      = fixture.Create<ServiceCommand>();
            
            solidPresenter.Initialise( mockView.Object );
            solidPresenter.CalculateTransfer( solidVM );

            mockTransferService.Verify( x => x.GetAmount( It.Is<ServiceCommand>( fn=>fn.Amount == solidVM.Amount )));
        }
    }

    class FakeTransferService : ITransferService
    {
        public ServiceCommand ServiceCommand { get; set; }

        public decimal GetAmount(ServiceCommand serviceCommand)
        {
            ServiceCommand = serviceCommand;

            return 0.0m;
        }
    }

    class fakeSOLIDView : ISOLIDView
    {
        public decimal Amount { get; set; }
        
        public void UpdateTransferAmount( SOLIDVM vm )
        {
            Amount = vm.Amount;            
        }
    }
}
