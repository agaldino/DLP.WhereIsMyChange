using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dlp.WhereIsMyChange.Core;
using Dlp.WhereIsMyChange.Core.DataContract;

namespace Dlp.WhereIsMyChange.Desktop {

    public partial class FormFodao : Form {

        private List<string> ErrorCollection;

        public FormFodao() {
            InitializeComponent();
        }

        private void CalculateChange() {
            this.UxTxtChangeAmount.Text = string.Empty;
            ChangeRequest changeRequest = new ChangeRequest();
            long productAmount;
            long paidAmount;
            ErrorCollection = new List<string>();

            if (long.TryParse(this.UxTxtProductAmount.Text, out productAmount) == false) {
                this.ErrorCollection.Add("Valor do produto precisa ser inteiro.");
            }
            if (long.TryParse(this.UxTxtPaidAmount.Text, out paidAmount) == false) {
                this.ErrorCollection.Add("Valor pago precisa ser inteiro.");
            }
            if (paidAmount < productAmount) {
                this.ErrorCollection.Add("O valor pago precisa ser igual ou maior do que o valor do produto.");
            }
            if (this.ErrorCollection.Any()) {
                foreach (string error in this.ErrorCollection) {
                    this.UxTxtChangeAmount.Text += error + Environment.NewLine;
                }
                return;
            }

            IWhereIsMyChangeManager whereIsMyChange = new WhereIsMyChangeManager(null);

            changeRequest.PaidAmount = paidAmount;
            changeRequest.ProductAmount = productAmount;

            ChangeResponse changeResponse = whereIsMyChange.CalculateChange(changeRequest);

            if (changeResponse.OperationReportList != null && changeResponse.OperationReportList.Any()) {
                foreach (OperationReport operationReport in changeResponse.OperationReportList) {

                    this.UxTxtChangeAmount.Text += string.Format("{0} - {1}{2}", operationReport.Field, operationReport.Message, Environment.NewLine);
                }
            } else {
                foreach (var item in changeResponse.ChangeList) {
                    this.UxTxtChangeAmount.Text += string.Format("{0}: {1} {2}", item.Key, item.Value, Environment.NewLine);
                }
                this.UxTxtChangeAmount.Text += string.Format("Troco: {0}{1}", changeResponse.ChangeAmount, Environment.NewLine);
            }
        }

        private void ClearForm() {
            this.UxTxtChangeAmount.Text = string.Empty;
            this.UxTxtPaidAmount.Text = string.Empty;
            this.UxTxtProductAmount.Text = string.Empty;
        }

        private void UxBtnPay_Click(object sender, EventArgs e) {
            this.CalculateChange();
        }

        private void UxBtnClear_Click(object sender, EventArgs e) {
            this.ClearForm();
        }
    }
}
