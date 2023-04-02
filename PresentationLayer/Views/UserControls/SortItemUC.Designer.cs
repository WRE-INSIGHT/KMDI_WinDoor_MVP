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
            this.panelSort = new System.Windows.Forms.Panel();
            this.rtboxDesc = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.lbl_dimension = new System.Windows.Forms.Label();
            this.cb_item = new System.Windows.Forms.CheckBox();
            this.pboxItemImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSort.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSort
            // 
            this.panelSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSort.Controls.Add(this.rtboxDesc);
            this.panelSort.Controls.Add(this.panel3);
            this.panelSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSort.Location = new System.Drawing.Point(271, 0);
            this.panelSort.Name = "panelSort";
            this.panelSort.Size = new System.Drawing.Size(296, 28);
            this.panelSort.TabIndex = 19;
            // 
            // rtboxDesc
            // 
            this.rtboxDesc.AcceptsTab = true;
            this.rtboxDesc.BackColor = System.Drawing.Color.White;
            this.rtboxDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtboxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtboxDesc.Location = new System.Drawing.Point(0, 27);
            this.rtboxDesc.Name = "rtboxDesc";
            this.rtboxDesc.ReadOnly = true;
            this.rtboxDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtboxDesc.Size = new System.Drawing.Size(294, 0);
            this.rtboxDesc.TabIndex = 17;
            this.rtboxDesc.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.lbl_dimension);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 27);
            this.panel3.TabIndex = 18;
            // 
            // btnView
            // 
            this.btnView.BackgroundImage = global::PresentationLayer.Properties.Resources.view;
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnView.Location = new System.Drawing.Point(267, 0);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(27, 27);
            this.btnView.TabIndex = 24;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_dimension
            // 
            this.lbl_dimension.AutoEllipsis = true;
            this.lbl_dimension.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_dimension.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_dimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_dimension.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dimension.ForeColor = System.Drawing.Color.Black;
            this.lbl_dimension.Location = new System.Drawing.Point(0, 0);
            this.lbl_dimension.Name = "lbl_dimension";
            this.lbl_dimension.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_dimension.Size = new System.Drawing.Size(294, 27);
            this.lbl_dimension.TabIndex = 23;
            this.lbl_dimension.Tag = "";
            this.lbl_dimension.Text = "lbl_dimension";
            this.lbl_dimension.UseMnemonic = false;
            // 
            // cb_item
            // 
            this.cb_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_item.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cb_item.FlatAppearance.BorderSize = 0;
            this.cb_item.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cb_item.Location = new System.Drawing.Point(0, 0);
            this.cb_item.Name = "cb_item";
            this.cb_item.Size = new System.Drawing.Size(271, 28);
            this.cb_item.TabIndex = 25;
            this.cb_item.UseVisualStyleBackColor = true;
            this.cb_item.CheckedChanged += new System.EventHandler(this.cb_item_CheckedChanged);
            this.cb_item.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseDown);
            this.cb_item.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseMove);
            this.cb_item.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cb_item_MouseUp);
            // 
            // pboxItemImage
            // 
            this.pboxItemImage.BackColor = System.Drawing.Color.White;
            this.pboxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxItemImage.Location = new System.Drawing.Point(0, 28);
            this.pboxItemImage.Name = "pboxItemImage";
            this.pboxItemImage.Size = new System.Drawing.Size(271, 0);
            this.pboxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxItemImage.TabIndex = 20;
            this.pboxItemImage.TabStop = false;
            this.pboxItemImage.Click += new System.EventHandler(this.pboxItemImage_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pboxItemImage);
            this.panel2.Controls.Add(this.cb_item);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 28);
            this.panel2.TabIndex = 23;
            // 
            // SortItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelSort);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SortItemUC";
            this.Size = new System.Drawing.Size(567, 28);
            this.Load += new System.EventHandler(this.SortItemUC_Load);
            this.panelSort.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSort;
        private System.Windows.Forms.RichTextBox rtboxDesc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.Label lbl_dimension;
        private System.Windows.Forms.CheckBox cb_item;
        private System.Windows.Forms.PictureBox pboxItemImage;
        private System.Windows.Forms.Panel panel2;
    }
}
