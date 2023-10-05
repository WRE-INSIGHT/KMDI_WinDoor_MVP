namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RotoswingPropertyUC
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_RotoswingNo = new System.Windows.Forms.ComboBox();
            this.pnl_RotoswingDefaultOptions = new System.Windows.Forms.Panel();
            this.pnl_RotoswingOptions = new System.Windows.Forms.Panel();
            this.pnl_RotoswingDefaultOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-2, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Article No.";
            // 
            // cmb_RotoswingNo
            // 
            this.cmb_RotoswingNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_RotoswingNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RotoswingNo.FormattingEnabled = true;
            this.cmb_RotoswingNo.Location = new System.Drawing.Point(69, 4);
            this.cmb_RotoswingNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_RotoswingNo.Name = "cmb_RotoswingNo";
            this.cmb_RotoswingNo.Size = new System.Drawing.Size(82, 21);
            this.cmb_RotoswingNo.TabIndex = 33;
            this.cmb_RotoswingNo.SelectedValueChanged += new System.EventHandler(this.cmb_RotoswingNo_SelectedValueChanged);
            this.cmb_RotoswingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_RotoswingNo_KeyPress);
            // 
            // pnl_RotoswingDefaultOptions
            // 
            this.pnl_RotoswingDefaultOptions.Controls.Add(this.label6);
            this.pnl_RotoswingDefaultOptions.Controls.Add(this.cmb_RotoswingNo);
            this.pnl_RotoswingDefaultOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_RotoswingDefaultOptions.Location = new System.Drawing.Point(0, 0);
            this.pnl_RotoswingDefaultOptions.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_RotoswingDefaultOptions.Name = "pnl_RotoswingDefaultOptions";
            this.pnl_RotoswingDefaultOptions.Size = new System.Drawing.Size(154, 55);
            this.pnl_RotoswingDefaultOptions.TabIndex = 35;
            // 
            // pnl_RotoswingOptions
            // 
            this.pnl_RotoswingOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_RotoswingOptions.Location = new System.Drawing.Point(0, 55);
            this.pnl_RotoswingOptions.Name = "pnl_RotoswingOptions";
            this.pnl_RotoswingOptions.Size = new System.Drawing.Size(154, 0);
            this.pnl_RotoswingOptions.TabIndex = 36;
            // 
            // PP_RotoswingPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_RotoswingOptions);
            this.Controls.Add(this.pnl_RotoswingDefaultOptions);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_RotoswingPropertyUC";
            this.Size = new System.Drawing.Size(154, 28);
            this.Load += new System.EventHandler(this.PP_RotoswingPropertyUC_Load);
            this.pnl_RotoswingDefaultOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_RotoswingNo;
        private System.Windows.Forms.Panel pnl_RotoswingDefaultOptions;
        private System.Windows.Forms.Panel pnl_RotoswingOptions;
    }
}
