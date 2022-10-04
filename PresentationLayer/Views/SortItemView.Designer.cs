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
            this.SuspendLayout();
            // 
            // pnlSortItem
            // 
            this.pnlSortItem.AllowDrop = true;
            this.pnlSortItem.AutoScroll = true;
            this.pnlSortItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSortItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSortItem.Location = new System.Drawing.Point(0, 0);
            this.pnlSortItem.Name = "pnlSortItem";
            this.pnlSortItem.Size = new System.Drawing.Size(584, 597);
            this.pnlSortItem.TabIndex = 6;
            this.pnlSortItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlSortItem_DragDrop);
            this.pnlSortItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlSortItem_DragEnter);
            // 
            // SortItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 597);
            this.Controls.Add(this.pnlSortItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SortItemView";
            this.Text = "SortItem";
            this.Load += new System.EventHandler(this.SortItemView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSortItem;
    }
}