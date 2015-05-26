using Domain;
using System;
namespace Services
{
    public interface ITransferService
    {
        decimal GetAmount(ServiceCommand serviceCommand);
    }
}
