using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Domain;
using Ploeh.AutoFixture;
using Presenters;

namespace SOLIDTests.Presenter_Tests
{
    [TestClass]
    public class WhenCallingTheCalculateMethod
    {
        [TestMethod]
        public void Then_The_ServiceCommand_Object_Is_Correctly_Mapped()
        {
            var fixture = new Fixture();
            var solidVM = fixture.Create<SOLIDVM>();
            var fakeTransferService = new FakeTransferService();
            var solidPresenter = new SOLIDPresenter(fakeTransferService);

            solidPresenter.CalculateTransfer(solidVM);

            Assert.AreEqual(solidVM.Amount, fakeTransferService.ServiceCommand.Amount);

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
}
