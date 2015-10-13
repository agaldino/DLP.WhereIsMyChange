using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.DataContract {
    public abstract class AbstractRequest {
        public AbstractRequest() {
            this.ActualOperationReportList = new List<OperationReport>();
        }

        public bool IsValid {
            get {
                this.Validate();
                return (this.OperationReportList.Any() == false);
            }
        }

        internal List<OperationReport> OperationReportList {
            get { return this.ActualOperationReportList; }
        }

        private List<OperationReport> ActualOperationReportList { get; set; }

        protected abstract void Validate();

        protected void AddOperationReport(string field, string message) {
            this.ActualOperationReportList.Add(new OperationReport() {
                Field = string.Format("{0}.{1}", this.GetType().Name, field),
                Message = message
            });
        }

    }
}
