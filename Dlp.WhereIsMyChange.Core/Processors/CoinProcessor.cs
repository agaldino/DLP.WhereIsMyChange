using Dlp.WhereIsMyChange.Core.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {

    public class CoinProcessor : AbstractProcessor {
        
        public CoinProcessor() { }

        internal override List<int> GetAvailableChange() {
            return new List<int> { 10, 100, 25, 50, 5 };
        }
    }
}
