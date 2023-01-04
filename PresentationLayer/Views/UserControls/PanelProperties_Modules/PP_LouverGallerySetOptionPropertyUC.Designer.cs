namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_LouverGallerySetOptionPropertyUC
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
            this.btn_DeleteCladding = new System.Windows.Forms.Button();
            this.lbl_GallerySetArtNo = new System.Windows.Forms.Label();
            this.tbox_GallerySetArtNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_DeleteCladding
            // 
            this.btn_DeleteCladding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteCladding.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DeleteCladding.FlatAppearance.BorderSize = 0;
            this.btn_DeleteCladding.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_DeleteCladding.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_DeleteCladding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteCladding.Location = new System.Drawing.Point(127, 0);
            this.btn_DeleteCladding.Name = "btn_DeleteCladding";
            this.btn_DeleteCladding.Size = new System.Drawing.Size(23, 29);
            this.btn_DeleteCladding.TabIndex = 20;
            this.btn_DeleteCladding.Text = "X";
            this.btn_DeleteCladding.UseVisualStyleBackColor = true;
            // 
            // lbl_GallerySetArtNo
            // 
            this.lbl_GallerySetArtNo.AutoSize = true;
            this.lbl_GallerySetArtNo.Location = new System.Drawing.Point(3, 8);
            this.lbl_GallerySetArtNo.Name = "lbl_GallerySetArtNo";
            this.lbl_GallerySetArtNo.Size = new System.Drawing.Size(23, 13);
            this.lbl_GallerySetArtNo.TabIndex = 21;
            this.lbl_GallerySetArtNo.Text = "Set";
            // 
            // tbox_GallerySetArtNo
            // 
            this.tbox_GallerySetArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbox_GallerySetArtNo.Enabled = false;
            this.tbox_GallerySetArtNo.Location = new System.Drawing.Point(27, 4);
            this.tbox_GallerySetArtNo.Name = "tbox_GallerySetArtNo";
            this.tbox_GallerySetArtNo.Size = new System.Drawing.Size(96, 22);
            this.tbox_GallerySetArtNo.TabIndex = 22;
            // 
            // PP_LouverGallerySetOptionPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbox_GallerySetArtNo);
            this.Controls.Add(this.lbl_GallerySetArtNo);
            this.Controls.Add(this.btn_DeleteCladding);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_LouverGallerySetOptionPropertyUC";
            this.Size = new System.Drawing.Size(150, 29);
            this.Load += new System.EventHandler(this.PP_LouverGallerySetOptionPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DeleteCladding;
        private System.Windows.Forms.Label lbl_GallerySetArtNo;
        private System.Windows.Forms.TextBox tbox_GallerySetArtNo;
    }
}
