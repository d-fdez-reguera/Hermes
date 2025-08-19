using Hermes.LoggerModule.Entity.Public;
using Hermes.LoggerModule.Entity.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Core.Factory
{
    public class LogFactory
    {
        public static ILog CreateActionLog(string path)
        {
            return new ActionLog(path);
        }
    }
}
