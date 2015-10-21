using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.DataContract {
    public sealed class ChangeRequest: AbstractRequest {

        public ChangeRequest() { }

        public long PaidAmount { get; set; }

        public long ProductAmount { get; set; }

        protected override void Validate() {
  
            if (this.PaidAmount < this.ProductAmount) {
                base.AddOperationReport("PaidAmount", "PaidAmout não pode ser menor que ProductAmount.");
            }
            if (this.PaidAmount <= 0) {
                base.AddOperationReport("PaidAmount", "PaidAmout não pode ser menor ou igual a zero.");
            }
            if (this.ProductAmount <= 0) {
                base.AddOperationReport("ProductAmount", "ProductAmount não pode ser menor ou igual a zero.");
            }

            if (this.ProductAmount == this.PaidAmount) {
                base.AddOperationReport("ChangeAmount", "Não há troco.");
            }
        }
    }
}
