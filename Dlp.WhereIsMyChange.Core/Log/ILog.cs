using Dlp.WhereIsMyChange.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {

    public interface ILog {

        void Save(object logData, LogTypeEnum logType);
    }
}
