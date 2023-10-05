namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_NTCenterHingePropertyUC
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
            this.cmb_NTCenterHinge = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_NTCenterHinge
            // 
            this.cmb_NTCenterHinge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_NTCenterHinge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NTCenterHinge.DropDownWidth = 69;
            this.cmb_NTCenterHinge.FormattingEnabled = true;
            this.cmb_NTCenterHinge.Location = new System.Drawing.Point(70, 3);
            this.cmb_NTCenterHinge.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_NTCenterHinge.Name = "cmb_NTCenterHinge";
            this.cmb_NTCenterHinge.Size = new System.Drawing.Size(80, 21);
            this.cmb_NTCenterHinge.TabIndex = 41;
            this.cmb_NTCenterHinge.SelectedValueChanged += new System.EventHandler(this.cmb_NTCenterHinge_SelectedValueChanged);
            this.cmb_NTCenterHinge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_NTCenterHinge_KeyPress);
            this.cmb_NTCenterHinge.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_NTCenterHinge_MouseWheel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "NT Cetner\r\n Hinge";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PP_NTCenterHingePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_NTCenterHinge);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_NTCenterHingePropertyUC";
            this.Size = new System.Drawing.Size(152, 28);
            this.Load += new System.EventHandler(this.PP_NTCenterHingePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_NTCenterHinge;
        private System.Windows.Forms.Label label1;
    }
}
