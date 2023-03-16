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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtboxDesc = new System.Windows.Forms.RichTextBox();
            this.lbl_dimension = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pboxItemImage = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_item = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtboxDesc);
            this.panel1.Controls.Add(this.lbl_dimension);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(271, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 80);
            this.panel1.TabIndex = 19;
            // 
            // rtboxDesc
            // 
            this.rtboxDesc.AcceptsTab = true;
            this.rtboxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtboxDesc.Location = new System.Drawing.Point(0, 20);
            this.rtboxDesc.Name = "rtboxDesc";
            this.rtboxDesc.ReadOnly = true;
            this.rtboxDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtboxDesc.Size = new System.Drawing.Size(327, 58);
            this.rtboxDesc.TabIndex = 17;
            this.rtboxDesc.Text = "";
            // 
            // lbl_dimension
            // 
            this.lbl_dimension.AutoEllipsis = true;
            this.lbl_dimension.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_dimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_dimension.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_dimension.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_dimension.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dimension.ForeColor = System.Drawing.Color.Black;
            this.lbl_dimension.Location = new System.Drawing.Point(0, 0);
            this.lbl_dimension.Name = "lbl_dimension";
            this.lbl_dimension.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_dimension.Size = new System.Drawing.Size(327, 20);
            this.lbl_dimension.TabIndex = 22;
            this.lbl_dimension.Tag = "";
            this.lbl_dimension.Text = "lbl_dimension";
            this.lbl_dimension.UseMnemonic = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pboxItemImage);
            this.panel2.Controls.Add(this.cb_item);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 80);
            this.panel2.TabIndex = 23;
            // 
            // pboxItemImage
            // 
            this.pboxItemImage.BackColor = System.Drawing.Color.White;
            this.pboxItemImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxItemImage.Location = new System.Drawing.Point(0, 20);
            this.pboxItemImage.Name = "pboxItemImage";
            this.pboxItemImage.Size = new System.Drawing.Size(271, 60);
            this.pboxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxItemImage.TabIndex = 20;
            this.pboxItemImage.TabStop = false;
            this.pboxItemImage.Click += new System.EventHandler(this.pboxItemImage_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.duplicateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // cb_item
            // 
            this.cb_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_item.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cb_item.FlatAppearance.BorderSize = 3;
            this.cb_item.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cb_item.Location = new System.Drawing.Point(0, 0);
            this.cb_item.Name = "cb_item";
            this.cb_item.Size = new System.Drawing.Size(271, 20);
            this.cb_item.TabIndex = 25;
            this.cb_item.UseVisualStyleBackColor = true;
            this.cb_item.CheckedChanged += new System.EventHandler(this.cb_item_CheckedChanged);
            this.cb_item.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseDown);
            this.cb_item.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseMove);
            this.cb_item.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseUp);
            // 
            // SortItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SortItemUC";
            this.Size = new System.Drawing.Size(600, 80);
            this.Load += new System.EventHandler(this.SortItemUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtboxDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pboxItemImage;
        public System.Windows.Forms.Label lbl_dimension;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_item;
    }
}
