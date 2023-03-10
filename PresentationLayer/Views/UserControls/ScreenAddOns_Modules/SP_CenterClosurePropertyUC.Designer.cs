namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_CenterClosurePropertyUC
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
            this.pnl_option = new System.Windows.Forms.Panel();
            this.chkBox_CenterClosure = new System.Windows.Forms.CheckBox();
            this.pnl_Body = new System.Windows.Forms.Panel();
            this.nud_IntermediatePartQty = new System.Windows.Forms.NumericUpDown();
            this.nud_LatchKitQty = new System.Windows.Forms.NumericUpDown();
            this.lbl_IntermediatePart = new System.Windows.Forms.Label();
            this.lbl_LatchKit = new System.Windows.Forms.Label();
            this.pnl_option.SuspendLayout();
            this.pnl_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IntermediatePartQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LatchKitQty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_option
            // 
            this.pnl_option.Controls.Add(this.chkBox_CenterClosure);
            this.pnl_option.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_option.Location = new System.Drawing.Point(0, 0);
            this.pnl_option.Name = "pnl_option";
            this.pnl_option.Size = new System.Drawing.Size(227, 27);
            this.pnl_option.TabIndex = 30;
            // 
            // chkBox_CenterClosure
            // 
            this.chkBox_CenterClosure.AutoSize = true;
            this.chkBox_CenterClosure.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBox_CenterClosure.Location = new System.Drawing.Point(3, 4);
            this.chkBox_CenterClosure.Name = "chkBox_CenterClosure";
            this.chkBox_CenterClosure.Size = new System.Drawing.Size(120, 17);
            this.chkBox_CenterClosure.TabIndex = 31;
            this.chkBox_CenterClosure.Text = "With Center Closure";
            this.chkBox_CenterClosure.UseVisualStyleBackColor = true;
            this.chkBox_CenterClosure.CheckedChanged += new System.EventHandler(this.chkBox_CenterClosure_CheckedChanged);
            // 
            // pnl_Body
            // 
            this.pnl_Body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Body.Controls.Add(this.nud_IntermediatePartQty);
            this.pnl_Body.Controls.Add(this.nud_LatchKitQty);
            this.pnl_Body.Controls.Add(this.lbl_IntermediatePart);
            this.pnl_Body.Controls.Add(this.lbl_LatchKit);
            this.pnl_Body.Location = new System.Drawing.Point(0, 27);
            this.pnl_Body.Name = "pnl_Body";
            this.pnl_Body.Size = new System.Drawing.Size(227, 61);
            this.pnl_Body.TabIndex = 31;
            // 
            // nud_IntermediatePartQty
            // 
            this.nud_IntermediatePartQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_IntermediatePartQty.Location = new System.Drawing.Point(102, 36);
            this.nud_IntermediatePartQty.Name = "nud_IntermediatePartQty";
            this.nud_IntermediatePartQty.Size = new System.Drawing.Size(122, 20);
            this.nud_IntermediatePartQty.TabIndex = 30;
            this.nud_IntermediatePartQty.ValueChanged += new System.EventHandler(this.nud_IntermediatePartQty_ValueChanged);
            this.nud_IntermediatePartQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nud_IntermediatePartQty_KeyDown);
            // 
            // nud_LatchKitQty
            // 
            this.nud_LatchKitQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_LatchKitQty.Location = new System.Drawing.Point(102, 8);
            this.nud_LatchKitQty.Name = "nud_LatchKitQty";
            this.nud_LatchKitQty.Size = new System.Drawing.Size(122, 20);
            this.nud_LatchKitQty.TabIndex = 29;
            this.nud_LatchKitQty.ValueChanged += new System.EventHandler(this.nud_LatchKitQty_ValueChanged);
            this.nud_LatchKitQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nud_LatchKitQty_KeyDown);
            // 
            // lbl_IntermediatePart
            // 
            this.lbl_IntermediatePart.AutoSize = true;
            this.lbl_IntermediatePart.Location = new System.Drawing.Point(7, 38);
            this.lbl_IntermediatePart.Name = "lbl_IntermediatePart";
            this.lbl_IntermediatePart.Size = new System.Drawing.Size(87, 13);
            this.lbl_IntermediatePart.TabIndex = 32;
            this.lbl_IntermediatePart.Text = "Intermediate Part";
            // 
            // lbl_LatchKit
            // 
            this.lbl_LatchKit.AutoSize = true;
            this.lbl_LatchKit.Location = new System.Drawing.Point(7, 10);
            this.lbl_LatchKit.Name = "lbl_LatchKit";
            this.lbl_LatchKit.Size = new System.Drawing.Size(49, 13);
            this.lbl_LatchKit.TabIndex = 31;
            this.lbl_LatchKit.Text = "Latch Kit";
            // 
            // SP_CenterClosurePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Body);
            this.Controls.Add(this.pnl_option);
            this.Name = "SP_CenterClosurePropertyUC";
            this.Size = new System.Drawing.Size(227, 88);
            this.Load += new System.EventHandler(this.SP_CenterClosurePropertyUC_Load);
            this.pnl_option.ResumeLayout(false);
            this.pnl_option.PerformLayout();
            this.pnl_Body.ResumeLayout(false);
            this.pnl_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IntermediatePartQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LatchKitQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_option;
        private System.Windows.Forms.CheckBox chkBox_CenterClosure;
        private System.Windows.Forms.Panel pnl_Body;
        private System.Windows.Forms.NumericUpDown nud_IntermediatePartQty;
        private System.Windows.Forms.NumericUpDown nud_LatchKitQty;
        private System.Windows.Forms.Label lbl_IntermediatePart;
        private System.Windows.Forms.Label lbl_LatchKit;
    }
}
