using Hermes.LoggerModule.Entity.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hermes.LoggerModule.Entity.Private
{
    public abstract class BaseLog : ILog
    {
        /// <summary>
        /// Not implemented in the interface since it is a private component.
        /// </summary>
        private Channel<string> _lines { get; set; }
        private string _path;

        private ChannelReader<string> _reader => _lines.Reader;
        private ChannelWriter<string> _writer => _lines.Writer;

        /// <summary>
        /// Creates a new log.
        /// </summary>
        /// <param name="path">The final path (and filename) where the log will be store.</param>
        public BaseLog(string path) 
        {
            _lines = Channel.CreateBounded<string>(new BoundedChannelOptions(ConfigurationManager.Option<int>("LoggerChannelThreshold"))
            {
                SingleWriter = false,
                SingleReader = false,
                FullMode = BoundedChannelFullMode.Wait
            });
            _path = path;
        }

        public async Task<bool> RegisterLine(string line)
        {
            bool flushed = _reader.Completion.IsCompleted ? FlushChannel().Result : false;
            return _writer.WriteAsync(line).IsCompleted;
        }
        public async Task<bool> FlushChannel()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                while (_reader.Count != 0)
                {
                    sb.AppendLine(await _reader.ReadAsync());
                }

                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    await sw.WriteAsync(sb);
                    sb.Clear();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new InsufficientMemoryException();
            }
        }
        public void Dispose()
        {
            FlushChannel();
        }
    }
}
