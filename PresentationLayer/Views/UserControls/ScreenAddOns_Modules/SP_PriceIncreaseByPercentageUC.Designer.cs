namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_PriceIncreaseByPercentageUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_head = new System.Windows.Forms.Panel();
            this.chkbox_AdditionalPercentage = new System.Windows.Forms.CheckBox();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.nud_Percentage = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_head.SuspendLayout();
            this.pnl_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Percentage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_head
            // 
            this.pnl_head.Controls.Add(this.chkbox_AdditionalPercentage);
            this.pnl_head.Location = new System.Drawing.Point(0, 0);
            this.pnl_head.Name = "pnl_head";
            this.pnl_head.Size = new System.Drawing.Size(227, 27);
            this.pnl_head.TabIndex = 0;
            // 
            // chkbox_AdditionalPercentage
            // 
            this.chkbox_AdditionalPercentage.AutoSize = true;
            this.chkbox_AdditionalPercentage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbox_AdditionalPercentage.Location = new System.Drawing.Point(3, 4);
            this.chkbox_AdditionalPercentage.Name = "chkbox_AdditionalPercentage";
            this.chkbox_AdditionalPercentage.Size = new System.Drawing.Size(122, 17);
            this.chkbox_AdditionalPercentage.TabIndex = 0;
            this.chkbox_AdditionalPercentage.Text = "Additional % to Price";
            this.chkbox_AdditionalPercentage.UseVisualStyleBackColor = true;
            this.chkbox_AdditionalPercentage.CheckedChanged += new System.EventHandler(this.chkbox_AdditionalPercentage_CheckedChanged);
            // 
            // pnl_body
            // 
            this.pnl_body.Controls.Add(this.nud_Percentage);
            this.pnl_body.Controls.Add(this.label1);
            this.pnl_body.Location = new System.Drawing.Point(0, 27);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(227, 26);
            this.pnl_body.TabIndex = 1;
            // 
            // nud_Percentage
            // 
            this.nud_Percentage.Location = new System.Drawing.Point(121, 0);
            this.nud_Percentage.Name = "nud_Percentage";
            this.nud_Percentage.Size = new System.Drawing.Size(55, 20);
            this.nud_Percentage.TabIndex = 1;
            this.nud_Percentage.ValueChanged += new System.EventHandler(this.nud_Percentage_ValueChanged);
            this.nud_Percentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nud_Percentage_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Increase Price By: ";
            // 
            // SP_PriceIncreaseByPercentageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_body);
            this.Controls.Add(this.pnl_head);
            this.Name = "SP_PriceIncreaseByPercentageUC";
            this.Size = new System.Drawing.Size(227, 54);
            this.Load += new System.EventHandler(this.SP_PriceIncreaseByPercentageUC_Load);
            this.pnl_head.ResumeLayout(false);
            this.pnl_head.PerformLayout();
            this.pnl_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Percentage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_head;
        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.CheckBox chkbox_AdditionalPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Percentage;
    }
}
