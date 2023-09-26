namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_DHandlePropertyUC
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
            this.cmb_DArtNo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_DArtNo
            // 
            this.cmb_DArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DArtNo.FormattingEnabled = true;
            this.cmb_DArtNo.Location = new System.Drawing.Point(57, 4);
            this.cmb_DArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_DArtNo.Name = "cmb_DArtNo";
            this.cmb_DArtNo.Size = new System.Drawing.Size(95, 21);
            this.cmb_DArtNo.TabIndex = 36;
            this.cmb_DArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_DArtNo_SelectedValueChanged);
            this.cmb_DArtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_DArtNo_KeyPress);
            this.cmb_DArtNo.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_DArtNo_MouseWheel);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-2, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Article No.";
            // 
            // PP_DHandlePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_DArtNo);
            this.Controls.Add(this.label12);
            this.Name = "PP_DHandlePropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_DHandlePropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_DArtNo;
        private System.Windows.Forms.Label label12;
    }
}
