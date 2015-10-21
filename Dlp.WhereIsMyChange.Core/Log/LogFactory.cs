using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.WhereIsMyChange.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {
    public static class LogFactory {

        public static AbstractLog Create(LoggerEnum logger) {

            switch (logger) {
                case LoggerEnum.WindowsEventLog:
                    return new WindowsEventLog();

                case LoggerEnum.FileLog:
                default:
                    return FileLog.GetInstance(new ConfigurationUtility());
            }
        }
    }
}
