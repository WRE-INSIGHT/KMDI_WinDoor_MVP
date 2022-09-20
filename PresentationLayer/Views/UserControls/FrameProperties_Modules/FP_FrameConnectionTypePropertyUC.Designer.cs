namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_FrameConnectionTypePropertyUC
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
            this.lbl_ConnectionType = new System.Windows.Forms.Label();
            this.cmb_ConnectionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_ConnectionType
            // 
            this.lbl_ConnectionType.AutoSize = true;
            this.lbl_ConnectionType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_ConnectionType.Location = new System.Drawing.Point(-2, 5);
            this.lbl_ConnectionType.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_ConnectionType.Name = "lbl_ConnectionType";
            this.lbl_ConnectionType.Size = new System.Drawing.Size(69, 30);
            this.lbl_ConnectionType.TabIndex = 18;
            this.lbl_ConnectionType.Text = "Connection\r\nType";
            this.lbl_ConnectionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_ConnectionType
            // 
            this.cmb_ConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ConnectionType.FormattingEnabled = true;
            this.cmb_ConnectionType.Location = new System.Drawing.Point(70, 10);
            this.cmb_ConnectionType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_ConnectionType.Name = "cmb_ConnectionType";
            this.cmb_ConnectionType.Size = new System.Drawing.Size(82, 21);
            this.cmb_ConnectionType.TabIndex = 17;
            // 
            // FP_FrameConnectionTypePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ConnectionType);
            this.Controls.Add(this.cmb_ConnectionType);
            this.Name = "FP_FrameConnectionTypePropertyUC";
            this.Size = new System.Drawing.Size(156, 39);
            this.Load += new System.EventHandler(this.FP_FrameConnectionTypePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ConnectionType;
        private System.Windows.Forms.ComboBox cmb_ConnectionType;
    }
}
