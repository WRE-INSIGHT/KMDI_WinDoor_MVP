namespace PresentationLayer.Views
{
    partial class PartialAdjustmentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartialAdjustmentView));
            this._paToolStripMenu = new System.Windows.Forms.ToolStrip();
            this._printToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this._pnlHeader = new System.Windows.Forms.Panel();
            this.lbl_currItem = new System.Windows.Forms.Label();
            this.lbl_prevItem = new System.Windows.Forms.Label();
            this._pnlBody = new System.Windows.Forms.Panel();
            this._paToolStripMenu.SuspendLayout();
            this._pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // _paToolStripMenu
            // 
            this._paToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._printToolStripBtn});
            this._paToolStripMenu.Location = new System.Drawing.Point(0, 0);
            this._paToolStripMenu.Name = "_paToolStripMenu";
            this._paToolStripMenu.Size = new System.Drawing.Size(733, 25);
            this._paToolStripMenu.TabIndex = 0;
            this._paToolStripMenu.Text = "toolStrip1";
            // 
            // _printToolStripBtn
            // 
            this._printToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._printToolStripBtn.Image = global::PresentationLayer.Properties.Resources.print;
            this._printToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._printToolStripBtn.Name = "_printToolStripBtn";
            this._printToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this._printToolStripBtn.Text = "Print";
            this._printToolStripBtn.Click += new System.EventHandler(this._printToolStripBtn_Click);
            // 
            // _pnlHeader
            // 
            this._pnlHeader.Controls.Add(this.lbl_currItem);
            this._pnlHeader.Controls.Add(this.lbl_prevItem);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.Location = new System.Drawing.Point(0, 25);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(733, 35);
            this._pnlHeader.TabIndex = 1;
            // 
            // lbl_currItem
            // 
            this.lbl_currItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_currItem.AutoSize = true;
            this.lbl_currItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currItem.Location = new System.Drawing.Point(479, 8);
            this.lbl_currItem.Name = "lbl_currItem";
            this.lbl_currItem.Size = new System.Drawing.Size(133, 17);
            this.lbl_currItem.TabIndex = 6;
            this.lbl_currItem.Text = "Current Item Design";
            // 
            // lbl_prevItem
            // 
            this.lbl_prevItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_prevItem.AutoSize = true;
            this.lbl_prevItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prevItem.Location = new System.Drawing.Point(107, 8);
            this.lbl_prevItem.Name = "lbl_prevItem";
            this.lbl_prevItem.Size = new System.Drawing.Size(140, 17);
            this.lbl_prevItem.TabIndex = 5;
            this.lbl_prevItem.Text = "Previous Item Design";
            // 
            // _pnlBody
            // 
            this._pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this._pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlBody.Location = new System.Drawing.Point(0, 60);
            this._pnlBody.MinimumSize = new System.Drawing.Size(732, 176);
            this._pnlBody.Name = "_pnlBody";
            this._pnlBody.Size = new System.Drawing.Size(733, 348);
            this._pnlBody.TabIndex = 2;
            // 
            // PartialAdjustmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 408);
            this.Controls.Add(this._pnlBody);
            this.Controls.Add(this._pnlHeader);
            this.Controls.Add(this._paToolStripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(749, 447);
            this.Name = "PartialAdjustmentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partial Adjustment";
            this.Load += new System.EventHandler(this.PartialAdjustmentView_Load);
            this._paToolStripMenu.ResumeLayout(false);
            this._paToolStripMenu.PerformLayout();
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _paToolStripMenu;
        private System.Windows.Forms.ToolStripButton _printToolStripBtn;
        private System.Windows.Forms.Panel _pnlHeader;
        private System.Windows.Forms.Panel _pnlBody;
        private System.Windows.Forms.Label lbl_currItem;
        private System.Windows.Forms.Label lbl_prevItem;
    }
}