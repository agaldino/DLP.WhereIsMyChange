using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.DataContract {
    public sealed class ChangeResponse {

        public ChangeResponse() { }

        public List<KeyValuePair<int,long>> ChangeList { get; set; }
        public Nullable<long> ChangeAmount { get; set; }
        public List<OperationReport> OperationReportList { get; set; }
    }
}
