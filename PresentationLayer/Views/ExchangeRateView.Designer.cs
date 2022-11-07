namespace PresentationLayer.Views
{
    partial class ExchangeRateView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEuro = new System.Windows.Forms.Label();
            this.nud_ExchangeRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEuro
            // 
            this.lblEuro.AutoSize = true;
            this.lblEuro.Location = new System.Drawing.Point(12, 9);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(44, 13);
            this.lblEuro.TabIndex = 0;
            this.lblEuro.Text = "Euro (€)";
            // 
            // nud_ExchangeRate
            // 
            this.nud_ExchangeRate.Location = new System.Drawing.Point(68, 6);
            this.nud_ExchangeRate.Name = "nud_ExchangeRate";
            this.nud_ExchangeRate.Size = new System.Drawing.Size(120, 20);
            this.nud_ExchangeRate.TabIndex = 1;
            this.nud_ExchangeRate.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nud_ExchangeRate.ValueChanged += new System.EventHandler(this.nud_ExchangeRate_ValueChanged);
            // 
            // ExchangeRateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 30);
            this.Controls.Add(this.nud_ExchangeRate);
            this.Controls.Add(this.lblEuro);
            this.Name = "ExchangeRateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Rate";
            this.Load += new System.EventHandler(this.ExchangeRateView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.NumericUpDown nud_ExchangeRate;
    }
}