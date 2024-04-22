namespace PresentationLayer.Views
{
    partial class ScreenPartialAdjusmentSelectionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenPartialAdjusmentSelectionView));
            this.chklst_itemList = new System.Windows.Forms.CheckedListBox();
            this.btn_addToList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklst_itemList
            // 
            this.chklst_itemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.chklst_itemList.FormattingEnabled = true;
            this.chklst_itemList.Location = new System.Drawing.Point(0, 0);
            this.chklst_itemList.Name = "chklst_itemList";
            this.chklst_itemList.Size = new System.Drawing.Size(300, 199);
            this.chklst_itemList.TabIndex = 0;
            // 
            // btn_addToList
            // 
            this.btn_addToList.BackColor = System.Drawing.SystemColors.Control;
            this.btn_addToList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addToList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_addToList.Location = new System.Drawing.Point(0, 199);
            this.btn_addToList.Name = "btn_addToList";
            this.btn_addToList.Size = new System.Drawing.Size(300, 26);
            this.btn_addToList.TabIndex = 1;
            this.btn_addToList.Text = "Done";
            this.btn_addToList.UseVisualStyleBackColor = false;
            this.btn_addToList.Click += new System.EventHandler(this.btn_addToList_Click);
            // 
            // ScreenPartialAdjusmentSelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 226);
            this.Controls.Add(this.btn_addToList);
            this.Controls.Add(this.chklst_itemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenPartialAdjusmentSelectionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partial Adjusment Selection";
            this.Load += new System.EventHandler(this.ScreenPartialAdjusmentSelectionView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklst_itemList;
        private System.Windows.Forms.Button btn_addToList;
    }
}