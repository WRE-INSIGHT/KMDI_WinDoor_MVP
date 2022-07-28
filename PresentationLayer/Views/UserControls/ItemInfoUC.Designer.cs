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
            this.lbl_item = new System.Windows.Forms.Label();
            this.pnl_itmbot_ = new System.Windows.Forms.Panel();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_dimension = new System.Windows.Forms.Label();
            this.pbox_itemImage = new System.Windows.Forms.PictureBox();
            this.pboxSlidingTopView = new System.Windows.Forms.PictureBox();
            this.pnl_itmbot_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSlidingTopView)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_item
            // 
            this.lbl_item.AutoEllipsis = true;
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
            this.lbl_item.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_item_MouseDoubleClick);
            // 
            // pnl_itmbot_
            // 
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
            this.lbl_desc.AutoEllipsis = true;
            this.lbl_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_desc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_desc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.Location = new System.Drawing.Point(2, 25);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(162, 106);
            this.lbl_desc.TabIndex = 1;
            this.lbl_desc.Text = "lbldesc_";
            this.lbl_desc.UseMnemonic = false;
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
            this.pbox_itemImage.Location = new System.Drawing.Point(-1, 20);
            this.pbox_itemImage.Name = "pbox_itemImage";
            this.pbox_itemImage.Size = new System.Drawing.Size(166, 178);
            this.pbox_itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_itemImage.TabIndex = 9;
            this.pbox_itemImage.TabStop = false;
            // 
            // pboxSlidingTopView
            // 
            this.pboxSlidingTopView.BackColor = System.Drawing.SystemColors.Control;
            this.pboxSlidingTopView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pboxSlidingTopView.Location = new System.Drawing.Point(0, 200);
            this.pboxSlidingTopView.Name = "pboxSlidingTopView";
            this.pboxSlidingTopView.Size = new System.Drawing.Size(166, 40);
            this.pboxSlidingTopView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxSlidingTopView.TabIndex = 10;
            this.pboxSlidingTopView.TabStop = false;
            // 
            // ItemInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbox_itemImage);
            this.Controls.Add(this.pboxSlidingTopView);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.pnl_itmbot_);
            this.Name = "ItemInfoUC";
            this.Size = new System.Drawing.Size(166, 373);
            this.Load += new System.EventHandler(this.ItemInfoUC_Load);
            this.pnl_itmbot_.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSlidingTopView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Panel pnl_itmbot_;
        public System.Windows.Forms.Label lbl_desc;
        public System.Windows.Forms.Label lbl_dimension;
        public System.Windows.Forms.PictureBox pbox_itemImage;
        public System.Windows.Forms.PictureBox pboxSlidingTopView;
    }
}
