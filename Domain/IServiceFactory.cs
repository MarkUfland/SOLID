using System;
namespace Domain
{
    public interface IServiceFactory
    {
        IService GetService(string serviceName);
    }
}
