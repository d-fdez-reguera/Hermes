using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hermes.LoggerModule.Entity.Public.Interface
{
    /// <summary>
    /// The base interface which all logs implements. It is used in order to access all logs types from the factory.<br/>
    /// It implements IDisposable as well, in order to flush all contents in case of a fatal exception.
    /// </summary>
    public interface ILog : IDisposable
    {
        Task<bool> RegisterLine(string line);
        Task<bool> FlushChannel();
    }
}
