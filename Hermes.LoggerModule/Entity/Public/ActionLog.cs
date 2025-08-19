using Hermes.LoggerModule.Entity.Private;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.LoggerModule.Entity.Public
{
    public class ActionLog : BaseLog
    {
        public ActionLog(string path) : base(path)
        {
        }
    }
}
