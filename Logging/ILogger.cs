using System;
namespace Logging
{
    public interface ILogger
    {
        bool Log(LogCommand logCommand);
    }
}
