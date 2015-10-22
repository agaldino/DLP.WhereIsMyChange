using Dlp.Framework.Container;
using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.WhereIsMyChange.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {

    public static class LogFactory {

        public static ILog Create(LoggerEnum logger) {

            return IocFactory.ResolveByName<ILog>(logger.ToString());

        }
    }
}
