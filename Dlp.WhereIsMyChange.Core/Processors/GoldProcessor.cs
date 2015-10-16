using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class GoldProcessor : AbstractProcessor {

        public GoldProcessor() {}
        
        internal override List<int> GetAvailableChange() {

            return new List<int> { 200000, 500000 };
        }
    }
}
