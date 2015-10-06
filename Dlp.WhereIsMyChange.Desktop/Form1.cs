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

namespace Dlp.WhereIsMyChange.Desktop {
    public partial class formFodao : Form {
        public formFodao() {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void UxBtnPay_Click(object sender, EventArgs e) {
            double productAmount = Convert.ToDouble(this.UxTxtProductAmount.Text);
            double paidAmount = Convert.ToDouble(this.UxTxtPaidAmount.Text);
            WhereIsMyChangeManager whereIsMyChange = new WhereIsMyChangeManager();

            double changeAmount = whereIsMyChange.CalculateChange(productAmount, paidAmount);
            this.UxTxtChangeAmount.Text = changeAmount.ToString();
        }
    }
}
