using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.DataContract {
    public class ChangeRequest {

        public ChangeRequest() { }

        public long PaidAmount { get; set; }

        public long ProductAmount { get; set; }
    }
}
