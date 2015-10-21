using Dlp.WhereIsMyChange.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class BillProcessor : AbstractProcessor {

        public BillProcessor() { }

        protected override void Log(DateTime data) {
            AbstractLog log = LogFactory.Create(Enums.LoggerEnum.FileLog);

            log.Log(data, Enums.LogTypeEnum.Warning);
        }

        internal override List<int> GetAvailableChange() {
            return new List<int> { 10000, 5000, 2000, 1000, 500, 200 };
        }
    }
}
