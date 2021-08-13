namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RotolinePropertyUC
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
            this.cmb_RotolineArtNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Article No.";
            // 
            // cmb_RotolineArtNo
            // 
            this.cmb_RotolineArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_RotolineArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RotolineArtNo.FormattingEnabled = true;
            this.cmb_RotolineArtNo.Location = new System.Drawing.Point(64, 3);
            this.cmb_RotolineArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_RotolineArtNo.Name = "cmb_RotolineArtNo";
            this.cmb_RotolineArtNo.Size = new System.Drawing.Size(88, 21);
            this.cmb_RotolineArtNo.TabIndex = 34;
            this.cmb_RotolineArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_RotolineArtNo_SelectedValueChanged);
            // 
            // PP_RotolinePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmb_RotolineArtNo);
            this.Name = "PP_RotolinePropertyUC";
            this.Size = new System.Drawing.Size(154, 28);
            this.Load += new System.EventHandler(this.PP_RotolinePropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_RotolineArtNo;
    }
}
