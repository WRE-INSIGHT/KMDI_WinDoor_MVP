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
            this.components = new System.ComponentModel.Container();
            this.btn_DeleteGallerySet = new System.Windows.Forms.Button();
            this.lbl_GallerySetArtNo = new System.Windows.Forms.Label();
            this.tbox_GallerySetArtNo = new System.Windows.Forms.TextBox();
            this.Cms_GallerySetArtNo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeArtNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cms_GallerySetArtNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DeleteGallerySet
            // 
            this.btn_DeleteGallerySet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteGallerySet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DeleteGallerySet.FlatAppearance.BorderSize = 0;
            this.btn_DeleteGallerySet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_DeleteGallerySet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_DeleteGallerySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteGallerySet.Location = new System.Drawing.Point(127, 0);
            this.btn_DeleteGallerySet.Name = "btn_DeleteGallerySet";
            this.btn_DeleteGallerySet.Size = new System.Drawing.Size(23, 29);
            this.btn_DeleteGallerySet.TabIndex = 20;
            this.btn_DeleteGallerySet.Text = "X";
            this.btn_DeleteGallerySet.UseVisualStyleBackColor = true;
            this.btn_DeleteGallerySet.Click += new System.EventHandler(this.btn_DeleteGallerySet_Click);
            // 
            // lbl_GallerySetArtNo
            // 
            this.lbl_GallerySetArtNo.AutoSize = true;
            this.lbl_GallerySetArtNo.Location = new System.Drawing.Point(3, 8);
            this.lbl_GallerySetArtNo.Name = "lbl_GallerySetArtNo";
            this.lbl_GallerySetArtNo.Size = new System.Drawing.Size(38, 13);
            this.lbl_GallerySetArtNo.TabIndex = 21;
            this.lbl_GallerySetArtNo.Text = "Set 00";
            // 
            // tbox_GallerySetArtNo
            // 
            this.tbox_GallerySetArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbox_GallerySetArtNo.Enabled = false;
            this.tbox_GallerySetArtNo.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_GallerySetArtNo.Location = new System.Drawing.Point(43, 4);
            this.tbox_GallerySetArtNo.Name = "tbox_GallerySetArtNo";
            this.tbox_GallerySetArtNo.Size = new System.Drawing.Size(80, 22);
            this.tbox_GallerySetArtNo.TabIndex = 22;
            // 
            // Cms_GallerySetArtNo
            // 
            this.Cms_GallerySetArtNo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeArtNoToolStripMenuItem});
            this.Cms_GallerySetArtNo.Name = "Cms_GallerySetArtNo";
            this.Cms_GallerySetArtNo.Size = new System.Drawing.Size(157, 26);
            // 
            // changeArtNoToolStripMenuItem
            // 
            this.changeArtNoToolStripMenuItem.Name = "changeArtNoToolStripMenuItem";
            this.changeArtNoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.changeArtNoToolStripMenuItem.Text = "Change Art No.";
            this.changeArtNoToolStripMenuItem.Click += new System.EventHandler(this.changeArtNoToolStripMenuItem_Click);
            // 
            // PP_LouverGallerySetOptionPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.Cms_GallerySetArtNo;
            this.Controls.Add(this.tbox_GallerySetArtNo);
            this.Controls.Add(this.lbl_GallerySetArtNo);
            this.Controls.Add(this.btn_DeleteGallerySet);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_LouverGallerySetOptionPropertyUC";
            this.Size = new System.Drawing.Size(150, 29);
            this.Load += new System.EventHandler(this.PP_LouverGallerySetOptionPropertyUC_Load);
            this.Cms_GallerySetArtNo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DeleteGallerySet;
        private System.Windows.Forms.Label lbl_GallerySetArtNo;
        private System.Windows.Forms.TextBox tbox_GallerySetArtNo;
        private System.Windows.Forms.ContextMenuStrip Cms_GallerySetArtNo;
        private System.Windows.Forms.ToolStripMenuItem changeArtNoToolStripMenuItem;
    }
}
