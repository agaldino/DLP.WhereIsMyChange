using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class BillProcessor : AbstractProcessor {

        public BillProcessor() { }

        internal override List<int> GetAvailableChange() {
            return new List<int> { 10000, 5000, 2000, 1000, 500, 200 };
        }
    }
}
