namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RotoswingForSlidingPropertyUC
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
            this.cmb_RotoswingForSlidingNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-1, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Article No.";
            // 
            // cmb_RotoswingForSlidingNo
            // 
            this.cmb_RotoswingForSlidingNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_RotoswingForSlidingNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RotoswingForSlidingNo.FormattingEnabled = true;
            this.cmb_RotoswingForSlidingNo.Location = new System.Drawing.Point(70, 4);
            this.cmb_RotoswingForSlidingNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_RotoswingForSlidingNo.Name = "cmb_RotoswingForSlidingNo";
            this.cmb_RotoswingForSlidingNo.Size = new System.Drawing.Size(82, 21);
            this.cmb_RotoswingForSlidingNo.TabIndex = 35;
            this.cmb_RotoswingForSlidingNo.SelectedValueChanged += new System.EventHandler(this.cmb_RotoswingForSlidingNo_SelectedValueChanged);
            // 
            // PP_RotoswingForSlidingPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_RotoswingForSlidingNo);
            this.Name = "PP_RotoswingForSlidingPropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_RotoswingForSlidingPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_RotoswingForSlidingNo;
    }
}
