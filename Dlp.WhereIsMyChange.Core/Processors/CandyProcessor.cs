using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {
    public class CandyProcessor : AbstractProcessor {

        public CandyProcessor() { }

        internal override List<int> GetAvailableChange() {
            return new List<int> { 3, 1 };
        }
    }
}
