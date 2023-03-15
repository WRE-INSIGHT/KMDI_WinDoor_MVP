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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExchangeRateView));
            this.lblEuro = new System.Windows.Forms.Label();
            this.nud_ExchangeRate = new System.Windows.Forms.NumericUpDown();
            this.lblAUD = new System.Windows.Forms.Label();
            this.nud_ExchangeRateAUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRateAUD)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEuro
            // 
            this.lblEuro.AutoSize = true;
            this.lblEuro.Location = new System.Drawing.Point(0, 9);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(44, 13);
            this.lblEuro.TabIndex = 0;
            this.lblEuro.Text = "Euro (€)";
            // 
            // nud_ExchangeRate
            // 
            this.nud_ExchangeRate.Location = new System.Drawing.Point(44, 6);
            this.nud_ExchangeRate.Name = "nud_ExchangeRate";
            this.nud_ExchangeRate.Size = new System.Drawing.Size(69, 20);
            this.nud_ExchangeRate.TabIndex = 1;
            this.nud_ExchangeRate.ValueChanged += new System.EventHandler(this.nud_ExchangeRate_ValueChanged);
            // 
            // lblAUD
            // 
            this.lblAUD.AutoSize = true;
            this.lblAUD.Location = new System.Drawing.Point(115, 9);
            this.lblAUD.Name = "lblAUD";
            this.lblAUD.Size = new System.Drawing.Size(39, 13);
            this.lblAUD.TabIndex = 2;
            this.lblAUD.Text = "AUD $";
            // 
            // nud_ExchangeRateAUD
            // 
            this.nud_ExchangeRateAUD.Location = new System.Drawing.Point(158, 6);
            this.nud_ExchangeRateAUD.Name = "nud_ExchangeRateAUD";
            this.nud_ExchangeRateAUD.Size = new System.Drawing.Size(69, 20);
            this.nud_ExchangeRateAUD.TabIndex = 3;
            this.nud_ExchangeRateAUD.ValueChanged += new System.EventHandler(this.nud_ExchangeRateAUD_ValueChanged);
            // 
            // ExchangeRateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 30);
            this.Controls.Add(this.nud_ExchangeRateAUD);
            this.Controls.Add(this.lblAUD);
            this.Controls.Add(this.nud_ExchangeRate);
            this.Controls.Add(this.lblEuro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExchangeRateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Rate";
            this.Load += new System.EventHandler(this.ExchangeRateView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExchangeRateAUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.NumericUpDown nud_ExchangeRate;
        private System.Windows.Forms.Label lblAUD;
        private System.Windows.Forms.NumericUpDown nud_ExchangeRateAUD;
    }
}