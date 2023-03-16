namespace PresentationLayer.Views
{
    partial class SortItemView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSortItem = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSortItem
            // 
            this.pnlSortItem.AllowDrop = true;
            this.pnlSortItem.AutoScroll = true;
            this.pnlSortItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSortItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSortItem.Location = new System.Drawing.Point(0, 61);
            this.pnlSortItem.Name = "pnlSortItem";
            this.pnlSortItem.Size = new System.Drawing.Size(584, 536);
            this.pnlSortItem.TabIndex = 6;
            this.pnlSortItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlSortItem_DragDrop);
            this.pnlSortItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlSortItem_DragEnter);
            this.pnlSortItem.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSortItem_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 61);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Location = new System.Drawing.Point(3, 35);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(124, 23);
            this.btn_Delete.TabIndex = 0;
            this.btn_Delete.Text = "Delete Selected Items";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // SortItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 597);
            this.Controls.Add(this.pnlSortItem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SortItemView";
            this.Text = "SortItem";
            this.Load += new System.EventHandler(this.SortItemView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSortItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Delete;
    }
}