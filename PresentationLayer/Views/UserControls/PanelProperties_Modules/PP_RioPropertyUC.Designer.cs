namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RioPropertyUC
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
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_RioArtNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Article No.";
            // 
            // cmb_RioArtNo
            // 
            this.cmb_RioArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_RioArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RioArtNo.FormattingEnabled = true;
            this.cmb_RioArtNo.Location = new System.Drawing.Point(64, 3);
            this.cmb_RioArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_RioArtNo.Name = "cmb_RioArtNo";
            this.cmb_RioArtNo.Size = new System.Drawing.Size(88, 21);
            this.cmb_RioArtNo.TabIndex = 32;
            this.cmb_RioArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_RioArtNo_SelectedValueChanged);
            // 
            // PP_RioPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmb_RioArtNo);
            this.Name = "PP_RioPropertyUC";
            this.Size = new System.Drawing.Size(154, 28);
            this.Load += new System.EventHandler(this.PP_RioPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_RioArtNo;
    }
}
