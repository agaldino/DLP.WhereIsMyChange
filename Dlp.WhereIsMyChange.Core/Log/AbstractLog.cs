﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {
    public abstract class AbstractLog {

        public AbstractLog() {}

        public abstract void Log(object logData, string logType);
    }
}