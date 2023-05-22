namespace PresentationLayer.Views.UserControls
{
    partial class ItemInfoUC
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
            this.lbl_item = new System.Windows.Forms.Label();
            this.pnl_itmbot_ = new System.Windows.Forms.Panel();
            this.lbl_desc = new System.Windows.Forms.RichTextBox();
            this.cms_Default_Desc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.defaultDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_dimension = new System.Windows.Forms.Label();
            this.pbox_itemImage = new System.Windows.Forms.PictureBox();
            this.pnl_itmbot_.SuspendLayout();
            this.cms_Default_Desc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_item
            // 
            this.lbl_item.AutoEllipsis = true;
            this.lbl_item.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_item.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.ForeColor = System.Drawing.Color.Blue;
            this.lbl_item.Location = new System.Drawing.Point(0, 0);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_item.Size = new System.Drawing.Size(166, 20);
            this.lbl_item.TabIndex = 3;
            this.lbl_item.Tag = "lbl_item";
            this.lbl_item.Text = "lbl_item";
            this.lbl_item.UseMnemonic = false;
            this.lbl_item.TextChanged += new System.EventHandler(this.lbl_item_TextChanged);
            this.lbl_item.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbl_item_DragEnter);
            this.lbl_item.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_item_MouseDoubleClick);
            this.lbl_item.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_item_MouseDown);
            this.lbl_item.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_item_MouseMove);
            this.lbl_item.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_item_MouseUp);
            // 
            // pnl_itmbot_
            // 
            this.pnl_itmbot_.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_itmbot_.Controls.Add(this.lbl_desc);
            this.pnl_itmbot_.Controls.Add(this.lbl_dimension);
            this.pnl_itmbot_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_itmbot_.Location = new System.Drawing.Point(0, 240);
            this.pnl_itmbot_.Name = "pnl_itmbot_";
            this.pnl_itmbot_.Padding = new System.Windows.Forms.Padding(2);
            this.pnl_itmbot_.Size = new System.Drawing.Size(166, 133);
            this.pnl_itmbot_.TabIndex = 5;
            // 
            // lbl_desc
            // 
            this.lbl_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_desc.ContextMenuStrip = this.cms_Default_Desc;
            this.lbl_desc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_desc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.Location = new System.Drawing.Point(2, 25);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(162, 106);
            this.lbl_desc.TabIndex = 1;
            this.lbl_desc.Text = "";
            // 
            // cms_Default_Desc
            // 
            this.cms_Default_Desc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultDescriptionToolStripMenuItem});
            this.cms_Default_Desc.Name = "cms_Default_Desc";
            this.cms_Default_Desc.Size = new System.Drawing.Size(176, 26);
            // 
            // defaultDescriptionToolStripMenuItem
            // 
            this.defaultDescriptionToolStripMenuItem.Name = "defaultDescriptionToolStripMenuItem";
            this.defaultDescriptionToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.defaultDescriptionToolStripMenuItem.Text = "Default Description";
            this.defaultDescriptionToolStripMenuItem.Click += new System.EventHandler(this.defaultDescriptionToolStripMenuItem_Click);
            // 
            // lbl_dimension
            // 
            this.lbl_dimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_dimension.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_dimension.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dimension.Location = new System.Drawing.Point(2, 2);
            this.lbl_dimension.Name = "lbl_dimension";
            this.lbl_dimension.Size = new System.Drawing.Size(162, 23);
            this.lbl_dimension.TabIndex = 0;
            this.lbl_dimension.Text = "lbldimension_";
            this.lbl_dimension.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbox_itemImage
            // 
            this.pbox_itemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_itemImage.Location = new System.Drawing.Point(0, 20);
            this.pbox_itemImage.Name = "pbox_itemImage";
            this.pbox_itemImage.Size = new System.Drawing.Size(166, 220);
            this.pbox_itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_itemImage.TabIndex = 9;
            this.pbox_itemImage.TabStop = false;
            // 
            // ItemInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbox_itemImage);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.pnl_itmbot_);
            this.Name = "ItemInfoUC";
            this.Size = new System.Drawing.Size(166, 373);
            this.Load += new System.EventHandler(this.ItemInfoUC_Load);
            this.pnl_itmbot_.ResumeLayout(false);
            this.cms_Default_Desc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Panel pnl_itmbot_;
        public System.Windows.Forms.Label lbl_dimension;
        public System.Windows.Forms.PictureBox pbox_itemImage;
        public System.Windows.Forms.RichTextBox lbl_desc;
        private System.Windows.Forms.ContextMenuStrip cms_Default_Desc;
        private System.Windows.Forms.ToolStripMenuItem defaultDescriptionToolStripMenuItem;
    }
}
