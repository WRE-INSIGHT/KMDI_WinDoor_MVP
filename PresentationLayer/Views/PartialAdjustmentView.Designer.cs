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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._ItemPanelToolstripBtn = new System.Windows.Forms.ToolStripButton();
            this._pnlHeader = new System.Windows.Forms.Panel();
            this.lbl_currItem = new System.Windows.Forms.Label();
            this.lbl_prevItem = new System.Windows.Forms.Label();
            this.pnl_itemList = new System.Windows.Forms.Panel();
            this._btn_addItem = new System.Windows.Forms.Button();
            this.chklstbx_itemList = new System.Windows.Forms.CheckedListBox();
            this._pnlBody = new System.Windows.Forms.Panel();
            this._itemSortToolStrpBtn = new System.Windows.Forms.ToolStripButton();
            this._paToolStripMenu.SuspendLayout();
            this._pnlHeader.SuspendLayout();
            this.pnl_itemList.SuspendLayout();
            this.SuspendLayout();
            // 
            // _paToolStripMenu
            // 
            this._paToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._printToolStripBtn,
            this.toolStripSeparator1,
            this._ItemPanelToolstripBtn,
            this._itemSortToolStrpBtn});
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _ItemPanelToolstripBtn
            // 
            this._ItemPanelToolstripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ItemPanelToolstripBtn.Image = ((System.Drawing.Image)(resources.GetObject("_ItemPanelToolstripBtn.Image")));
            this._ItemPanelToolstripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ItemPanelToolstripBtn.Name = "_ItemPanelToolstripBtn";
            this._ItemPanelToolstripBtn.Size = new System.Drawing.Size(23, 22);
            this._ItemPanelToolstripBtn.Text = "Add Item To List";
            this._ItemPanelToolstripBtn.Click += new System.EventHandler(this._ItemPanelToolstripBtn_Click);
            // 
            // _pnlHeader
            // 
            this._pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlHeader.Controls.Add(this.lbl_currItem);
            this._pnlHeader.Controls.Add(this.lbl_prevItem);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.Location = new System.Drawing.Point(0, 144);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(733, 35);
            this._pnlHeader.TabIndex = 1;
            // 
            // lbl_currItem
            // 
            this.lbl_currItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_currItem.AutoSize = true;
            this.lbl_currItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currItem.Location = new System.Drawing.Point(478, 7);
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
            this.lbl_prevItem.Location = new System.Drawing.Point(106, 7);
            this.lbl_prevItem.Name = "lbl_prevItem";
            this.lbl_prevItem.Size = new System.Drawing.Size(140, 17);
            this.lbl_prevItem.TabIndex = 5;
            this.lbl_prevItem.Text = "Previous Item Design";
            // 
            // pnl_itemList
            // 
            this.pnl_itemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_itemList.Controls.Add(this._btn_addItem);
            this.pnl_itemList.Controls.Add(this.chklstbx_itemList);
            this.pnl_itemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_itemList.Location = new System.Drawing.Point(0, 25);
            this.pnl_itemList.Name = "pnl_itemList";
            this.pnl_itemList.Size = new System.Drawing.Size(733, 119);
            this.pnl_itemList.TabIndex = 3;
            // 
            // _btn_addItem
            // 
            this._btn_addItem.Dock = System.Windows.Forms.DockStyle.Left;
            this._btn_addItem.Location = new System.Drawing.Point(0, 90);
            this._btn_addItem.Name = "_btn_addItem";
            this._btn_addItem.Size = new System.Drawing.Size(82, 27);
            this._btn_addItem.TabIndex = 1;
            this._btn_addItem.Text = "Add To List";
            this._btn_addItem.UseVisualStyleBackColor = true;
            this._btn_addItem.Click += new System.EventHandler(this._btn_addItem_Click);
            // 
            // chklstbx_itemList
            // 
            this.chklstbx_itemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklstbx_itemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.chklstbx_itemList.FormattingEnabled = true;
            this.chklstbx_itemList.Location = new System.Drawing.Point(0, 0);
            this.chklstbx_itemList.MultiColumn = true;
            this.chklstbx_itemList.Name = "chklstbx_itemList";
            this.chklstbx_itemList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chklstbx_itemList.Size = new System.Drawing.Size(731, 90);
            this.chklstbx_itemList.TabIndex = 0;
            // 
            // _pnlBody
            // 
            this._pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlBody.Location = new System.Drawing.Point(0, 179);
            this._pnlBody.Name = "_pnlBody";
            this._pnlBody.Size = new System.Drawing.Size(733, 229);
            this._pnlBody.TabIndex = 4;
            // 
            // _itemSortToolStrpBtn
            // 
            this._itemSortToolStrpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._itemSortToolStrpBtn.Image = ((System.Drawing.Image)(resources.GetObject("_itemSortToolStrpBtn.Image")));
            this._itemSortToolStrpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._itemSortToolStrpBtn.Name = "_itemSortToolStrpBtn";
            this._itemSortToolStrpBtn.Size = new System.Drawing.Size(23, 22);
            this._itemSortToolStrpBtn.Text = "Sort";
            this._itemSortToolStrpBtn.Click += new System.EventHandler(this._itemSortToolStrpBtn_Click);
            // 
            // PartialAdjustmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 408);
            this.Controls.Add(this._pnlBody);
            this.Controls.Add(this._pnlHeader);
            this.Controls.Add(this.pnl_itemList);
            this.Controls.Add(this._paToolStripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(749, 447);
            this.Name = "PartialAdjustmentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "    ";
            this.Load += new System.EventHandler(this.PartialAdjustmentView_Load);
            this._paToolStripMenu.ResumeLayout(false);
            this._paToolStripMenu.PerformLayout();
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            this.pnl_itemList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _paToolStripMenu;
        private System.Windows.Forms.ToolStripButton _printToolStripBtn;
        private System.Windows.Forms.Panel _pnlHeader;
        private System.Windows.Forms.Label lbl_currItem;
        private System.Windows.Forms.Label lbl_prevItem;
        private System.Windows.Forms.Panel pnl_itemList;
        private System.Windows.Forms.Panel _pnlBody;
        private System.Windows.Forms.CheckedListBox chklstbx_itemList;
        private System.Windows.Forms.Button _btn_addItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _ItemPanelToolstripBtn;
        private System.Windows.Forms.ToolStripButton _itemSortToolStrpBtn;
    }
}