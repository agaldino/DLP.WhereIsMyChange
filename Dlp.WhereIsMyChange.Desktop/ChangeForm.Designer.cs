namespace Dlp.WhereIsMyChange.Desktop {
    partial class FormFodao {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UxTxtProductAmount = new System.Windows.Forms.TextBox();
            this.UxTxtChangeAmount = new System.Windows.Forms.TextBox();
            this.UxTxtPaidAmount = new System.Windows.Forms.TextBox();
            this.UxLblProductAmount = new System.Windows.Forms.Label();
            this.UxLblPaidAmount = new System.Windows.Forms.Label();
            this.UxLblChangeAmount = new System.Windows.Forms.Label();
            this.UxBtnPay = new System.Windows.Forms.Button();
            this.UxBtnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UxTxtProductAmount
            // 
            this.UxTxtProductAmount.Location = new System.Drawing.Point(239, 37);
            this.UxTxtProductAmount.Name = "UxTxtProductAmount";
            this.UxTxtProductAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtProductAmount.TabIndex = 0;
            // 
            // UxTxtChangeAmount
            // 
            this.UxTxtChangeAmount.Location = new System.Drawing.Point(239, 186);
            this.UxTxtChangeAmount.Multiline = true;
            this.UxTxtChangeAmount.Name = "UxTxtChangeAmount";
            this.UxTxtChangeAmount.ReadOnly = true;
            this.UxTxtChangeAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UxTxtChangeAmount.Size = new System.Drawing.Size(209, 103);
            this.UxTxtChangeAmount.TabIndex = 1;
            // 
            // UxTxtPaidAmount
            // 
            this.UxTxtPaidAmount.Location = new System.Drawing.Point(239, 91);
            this.UxTxtPaidAmount.Name = "UxTxtPaidAmount";
            this.UxTxtPaidAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtPaidAmount.TabIndex = 2;
            // 
            // UxLblProductAmount
            // 
            this.UxLblProductAmount.AutoSize = true;
            this.UxLblProductAmount.Location = new System.Drawing.Point(80, 43);
            this.UxLblProductAmount.Name = "UxLblProductAmount";
            this.UxLblProductAmount.Size = new System.Drawing.Size(136, 20);
            this.UxLblProductAmount.TabIndex = 3;
            this.UxLblProductAmount.Text = "Preço do Produto:";
            // 
            // UxLblPaidAmount
            // 
            this.UxLblPaidAmount.AutoSize = true;
            this.UxLblPaidAmount.Location = new System.Drawing.Point(126, 97);
            this.UxLblPaidAmount.Name = "UxLblPaidAmount";
            this.UxLblPaidAmount.Size = new System.Drawing.Size(90, 20);
            this.UxLblPaidAmount.TabIndex = 4;
            this.UxLblPaidAmount.Text = "Valor pago:";
            // 
            // UxLblChangeAmount
            // 
            this.UxLblChangeAmount.AutoSize = true;
            this.UxLblChangeAmount.Location = new System.Drawing.Point(163, 186);
            this.UxLblChangeAmount.Name = "UxLblChangeAmount";
            this.UxLblChangeAmount.Size = new System.Drawing.Size(53, 20);
            this.UxLblChangeAmount.TabIndex = 5;
            this.UxLblChangeAmount.Text = "Troco:";
            // 
            // UxBtnPay
            // 
            this.UxBtnPay.Location = new System.Drawing.Point(264, 138);
            this.UxBtnPay.Name = "UxBtnPay";
            this.UxBtnPay.Size = new System.Drawing.Size(75, 31);
            this.UxBtnPay.TabIndex = 6;
            this.UxBtnPay.Text = "Pagar";
            this.UxBtnPay.UseVisualStyleBackColor = true;
            this.UxBtnPay.Click += new System.EventHandler(this.UxBtnPay_Click);
            // 
            // UxBtnClear
            // 
            this.UxBtnClear.Location = new System.Drawing.Point(355, 138);
            this.UxBtnClear.Name = "UxBtnClear";
            this.UxBtnClear.Size = new System.Drawing.Size(75, 31);
            this.UxBtnClear.TabIndex = 7;
            this.UxBtnClear.Text = "Clear";
            this.UxBtnClear.UseVisualStyleBackColor = true;
            this.UxBtnClear.Click += new System.EventHandler(this.UxBtnClear_Click);
            // 
            // FormFodao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 315);
            this.Controls.Add(this.UxBtnClear);
            this.Controls.Add(this.UxBtnPay);
            this.Controls.Add(this.UxLblChangeAmount);
            this.Controls.Add(this.UxLblPaidAmount);
            this.Controls.Add(this.UxLblProductAmount);
            this.Controls.Add(this.UxTxtPaidAmount);
            this.Controls.Add(this.UxTxtChangeAmount);
            this.Controls.Add(this.UxTxtProductAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormFodao";
            this.Text = "Where\'s my Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxTxtProductAmount;
        private System.Windows.Forms.TextBox UxTxtChangeAmount;
        private System.Windows.Forms.TextBox UxTxtPaidAmount;
        private System.Windows.Forms.Label UxLblProductAmount;
        private System.Windows.Forms.Label UxLblPaidAmount;
        private System.Windows.Forms.Label UxLblChangeAmount;
        private System.Windows.Forms.Button UxBtnPay;
        private System.Windows.Forms.Button UxBtnClear;
    }
}

