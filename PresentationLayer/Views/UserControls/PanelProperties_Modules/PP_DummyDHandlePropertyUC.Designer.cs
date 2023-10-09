namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_DummyDHandlePropertyUC
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
            this.cmb_DummyDArtNo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_DummyDArtNo
            // 
            this.cmb_DummyDArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DummyDArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DummyDArtNo.FormattingEnabled = true;
            this.cmb_DummyDArtNo.Location = new System.Drawing.Point(57, 4);
            this.cmb_DummyDArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_DummyDArtNo.Name = "cmb_DummyDArtNo";
            this.cmb_DummyDArtNo.Size = new System.Drawing.Size(95, 21);
            this.cmb_DummyDArtNo.TabIndex = 36;
            this.cmb_DummyDArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_DummyDArtNo_SelectedValueChanged);
            this.cmb_DummyDArtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_DummyDArtNo_KeyPress);
            this.cmb_DummyDArtNo.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_DummyDArtNo_MouseWheel);
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
            // PP_DummyDHandlePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_DummyDArtNo);
            this.Controls.Add(this.label12);
            this.Name = "PP_DummyDHandlePropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_DummyDHandlePropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_DummyDArtNo;
        private System.Windows.Forms.Label label12;
    }
}
