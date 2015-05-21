using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IOC;

namespace SOLID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load<IOCDataModule>();
            kernel.Load<IOCDomainModule>();
            kernel.Load<IOCServicesModule>();
            kernel.Load<IOCPresentationModule>();
            kernel.Load<IOCLoggingModule>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(kernel.Get<SOLIDForm>());
        }
    }
}
