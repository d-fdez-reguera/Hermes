using Hermes.Core.Factory;
using Hermes.LoggerModule.Entity.Public.Interface;

namespace Hermes.Test
{
    public class LoggerTests
    {
        /// <summary>
        /// Checks if the Action Log registers the lines into a channel, and flushes them.
        /// </summary>
        [Fact]
        public async void AL1()
        {
            try
            {
                using (ILog log = LogFactory.CreateActionLog(@"C:\temp\log.txt"))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        log.RegisterLine($"{DateTime.Now.ToString()}//////////////////////////////////////////////////////////////////////// Linea de log nº" + i.ToString() + "--------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"USE CASE CODE AL1 FAILED:{ex.Message}");
            }
        }
    }
}