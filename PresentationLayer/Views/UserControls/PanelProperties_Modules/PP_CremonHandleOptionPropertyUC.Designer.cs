
namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_CremonHandleOptionPropertyUC
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
            this.cmb_CremonArtNo = new System.Windows.Forms.ComboBox();
            this.lbl_CremonArtNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_CremonArtNo
            // 
            this.cmb_CremonArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CremonArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CremonArtNo.DropDownWidth = 69;
            this.cmb_CremonArtNo.FormattingEnabled = true;
            this.cmb_CremonArtNo.Location = new System.Drawing.Point(95, 5);
            this.cmb_CremonArtNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.cmb_CremonArtNo.Name = "cmb_CremonArtNo";
            this.cmb_CremonArtNo.Size = new System.Drawing.Size(99, 24);
            this.cmb_CremonArtNo.TabIndex = 39;
            this.cmb_CremonArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_CremonArtNo_SelectedValueChanged);
            // 
            // lbl_CremonArtNo
            // 
            this.lbl_CremonArtNo.AutoSize = true;
            this.lbl_CremonArtNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CremonArtNo.Location = new System.Drawing.Point(3, 9);
            this.lbl_CremonArtNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CremonArtNo.Name = "lbl_CremonArtNo";
            this.lbl_CremonArtNo.Size = new System.Drawing.Size(72, 19);
            this.lbl_CremonArtNo.TabIndex = 38;
            this.lbl_CremonArtNo.Text = "Article No.";
            // 
            // PP_CremonHandleOptionPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_CremonArtNo);
            this.Controls.Add(this.lbl_CremonArtNo);
            this.Name = "PP_CremonHandleOptionPropertyUC";
            this.Size = new System.Drawing.Size(200, 34);
            this.Load += new System.EventHandler(this.PP_CremonHandleOptionPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_CremonArtNo;
        private System.Windows.Forms.Label lbl_CremonArtNo;
    }
}
