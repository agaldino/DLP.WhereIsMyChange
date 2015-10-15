using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class SilverProcessor : AbstractProcessor {

        public SilverProcessor() { }

        internal override List<int> GetAvailableChange() {

            return new List<int> { 100000, 50000, 25000 };
        }
    }
}
