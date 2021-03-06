﻿using Dlp.WhereIsMyChange.Core.Log;
using System;
using System.Collections.Generic;

namespace Dlp.WhereIsMyChange.Core.Processors {

    public class CoinProcessor : AbstractProcessor {

        public CoinProcessor() { }

        protected override void Log(DateTime data) {
            ILog log = LogFactory.Create(Enums.LoggerEnum.WindowsEventLog);

            log.Save(data, Enums.LogTypeEnum.Warning);
        }

        internal override List<int> GetAvailableChange() {
            return new List<int> { 10, 100, 25, 50, 5 };
        }
    }
}
