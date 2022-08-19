namespace PresentationLayer.Views.UserControls
{
    partial class SortItemUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_item = new System.Windows.Forms.Label();
            this.rtboxDesc = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_description = new System.Windows.Forms.Label();
            this.pboxItemImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_item);
            this.panel1.Controls.Add(this.rtboxDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(189, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 76);
            this.panel1.TabIndex = 19;
            // 
            // lbl_item
            // 
            this.lbl_item.AutoEllipsis = true;
            this.lbl_item.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_item.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.ForeColor = System.Drawing.Color.Black;
            this.lbl_item.Location = new System.Drawing.Point(0, 0);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_item.Size = new System.Drawing.Size(201, 20);
            this.lbl_item.TabIndex = 18;
            this.lbl_item.Tag = "lbl_item";
            this.lbl_item.Text = "lbl_item";
            this.lbl_item.UseMnemonic = false;
            // 
            // rtboxDesc
            // 
            this.rtboxDesc.AcceptsTab = true;
            this.rtboxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtboxDesc.Location = new System.Drawing.Point(0, 0);
            this.rtboxDesc.Name = "rtboxDesc";
            this.rtboxDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtboxDesc.Size = new System.Drawing.Size(201, 74);
            this.rtboxDesc.TabIndex = 17;
            this.rtboxDesc.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbl_description);
            this.panel2.Controls.Add(this.pboxItemImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 76);
            this.panel2.TabIndex = 23;
            // 
            // lbl_description
            // 
            this.lbl_description.AutoEllipsis = true;
            this.lbl_description.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_description.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_description.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_description.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.Black;
            this.lbl_description.Location = new System.Drawing.Point(0, 0);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_description.Size = new System.Drawing.Size(189, 20);
            this.lbl_description.TabIndex = 21;
            this.lbl_description.Tag = "lbl_description";
            this.lbl_description.Text = "label1";
            this.lbl_description.UseMnemonic = false;
            // 
            // pboxItemImage
            // 
            this.pboxItemImage.BackColor = System.Drawing.Color.White;
            this.pboxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxItemImage.Location = new System.Drawing.Point(0, 0);
            this.pboxItemImage.Name = "pboxItemImage";
            this.pboxItemImage.Size = new System.Drawing.Size(189, 76);
            this.pboxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxItemImage.TabIndex = 20;
            this.pboxItemImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // SortItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SortItemUC";
            this.Size = new System.Drawing.Size(392, 76);
            this.Load += new System.EventHandler(this.SortItemUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtboxDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pboxItemImage;
        public System.Windows.Forms.Label lbl_item;
        public System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
