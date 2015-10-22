using Dlp.WhereIsMyChange.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class SilverProcessor : AbstractProcessor {

        public SilverProcessor() { }

        protected override void Log(DateTime data) {
            ILog log = LogFactory.Create(Enums.LoggerEnum.WindowsEventLog);

            log.Save(data, Enums.LogTypeEnum.Warning);
        }

        internal override List<int> GetAvailableChange() {

            return new List<int> { 100000, 50000, 25000 };
        }
    }
}
