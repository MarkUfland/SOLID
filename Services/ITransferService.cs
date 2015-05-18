using System;
namespace Services
{
    public interface ITransferService
    {
        decimal GetAmount(string service, decimal amount);
    }
}
