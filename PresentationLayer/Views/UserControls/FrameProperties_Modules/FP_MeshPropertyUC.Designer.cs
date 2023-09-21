namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_MeshPropertyUC
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
            this.lbl_MeshType = new System.Windows.Forms.Label();
            this.cmb_MeshType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_MeshType
            // 
            this.lbl_MeshType.AutoSize = true;
            this.lbl_MeshType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_MeshType.Location = new System.Drawing.Point(0, 7);
            this.lbl_MeshType.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_MeshType.Name = "lbl_MeshType";
            this.lbl_MeshType.Size = new System.Drawing.Size(63, 15);
            this.lbl_MeshType.TabIndex = 22;
            this.lbl_MeshType.Text = "Mesh Type";
            this.lbl_MeshType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_MeshType
            // 
            this.cmb_MeshType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MeshType.FormattingEnabled = true;
            this.cmb_MeshType.Location = new System.Drawing.Point(72, 5);
            this.cmb_MeshType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_MeshType.Name = "cmb_MeshType";
            this.cmb_MeshType.Size = new System.Drawing.Size(83, 21);
            this.cmb_MeshType.TabIndex = 21;
            this.cmb_MeshType.SelectedValueChanged += new System.EventHandler(this.cmb_MeshType_SelectedValueChanged);
            this.cmb_MeshType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_MeshType_KeyPress);
            this.cmb_MeshType.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_MeshType_MouseWheel);
            // 
            // FP_MeshPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_MeshType);
            this.Controls.Add(this.cmb_MeshType);
            this.Name = "FP_MeshPropertyUC";
            this.Size = new System.Drawing.Size(159, 30);
            this.Load += new System.EventHandler(this.FP_MeshPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MeshType;
        private System.Windows.Forms.ComboBox cmb_MeshType;
    }
}
