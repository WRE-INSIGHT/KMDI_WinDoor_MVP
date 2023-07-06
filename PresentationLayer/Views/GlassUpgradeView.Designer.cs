﻿namespace PresentationLayer.Views
{
    partial class GlassUpgradeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlassUpgradeView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Header = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_discount = new System.Windows.Forms.Label();
            this.num_discount = new System.Windows.Forms.NumericUpDown();
            this.pnl_desc = new System.Windows.Forms.Panel();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.pbox_itemImage = new System.Windows.Forms.PictureBox();
            this.txt_itemDesc = new System.Windows.Forms.TextBox();
            this.chkbx_ItemList = new System.Windows.Forms.CheckedListBox();
            this._glassUpgToolStrip = new System.Windows.Forms.ToolStrip();
            this._printBtn = new System.Windows.Forms.ToolStripButton();
            this._date = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this._quoteNum = new System.Windows.Forms.Label();
            this.lbl_quoteNum = new System.Windows.Forms.Label();
            this._clientAdd = new System.Windows.Forms.Label();
            this._clientName = new System.Windows.Forms.Label();
            this._namepos = new System.Windows.Forms.Label();
            this.cmb_glassType = new System.Windows.Forms.ComboBox();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_ClientName = new System.Windows.Forms.Label();
            this.lbl_AE = new System.Windows.Forms.Label();
            this.lbl_glass = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glassUpgradeDGV = new System.Windows.Forms.DataGridView();
            this.num_glassAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.num_wdwsAndDoors = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsGlassUpgrade = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_discount)).BeginInit();
            this.pnl_desc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).BeginInit();
            this._glassUpgToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glassUpgradeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_glassAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_wdwsAndDoors)).BeginInit();
            this.cmsGlassUpgrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.BackColor = System.Drawing.SystemColors.Window;
            this.panel_Header.Controls.Add(this.btn_add);
            this.panel_Header.Controls.Add(this.lbl_discount);
            this.panel_Header.Controls.Add(this.num_discount);
            this.panel_Header.Controls.Add(this.pnl_desc);
            this.panel_Header.Controls.Add(this.pbox_itemImage);
            this.panel_Header.Controls.Add(this.txt_itemDesc);
            this.panel_Header.Controls.Add(this.chkbx_ItemList);
            this.panel_Header.Controls.Add(this._glassUpgToolStrip);
            this.panel_Header.Controls.Add(this._date);
            this.panel_Header.Controls.Add(this.lbl_Date);
            this.panel_Header.Controls.Add(this._quoteNum);
            this.panel_Header.Controls.Add(this.lbl_quoteNum);
            this.panel_Header.Controls.Add(this._clientAdd);
            this.panel_Header.Controls.Add(this._clientName);
            this.panel_Header.Controls.Add(this._namepos);
            this.panel_Header.Controls.Add(this.cmb_glassType);
            this.panel_Header.Controls.Add(this.lbl_Address);
            this.panel_Header.Controls.Add(this.lbl_ClientName);
            this.panel_Header.Controls.Add(this.lbl_AE);
            this.panel_Header.Controls.Add(this.lbl_glass);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(932, 192);
            this.panel_Header.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_add.Location = new System.Drawing.Point(834, 107);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(96, 23);
            this.btn_add.TabIndex = 20;
            this.btn_add.Text = "Add To List";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_discount
            // 
            this.lbl_discount.AutoSize = true;
            this.lbl_discount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount.Location = new System.Drawing.Point(297, 35);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(59, 13);
            this.lbl_discount.TabIndex = 13;
            this.lbl_discount.Text = "Discount: ";
            // 
            // num_discount
            // 
            this.num_discount.Location = new System.Drawing.Point(362, 33);
            this.num_discount.Name = "num_discount";
            this.num_discount.Size = new System.Drawing.Size(68, 20);
            this.num_discount.TabIndex = 14;
            // 
            // pnl_desc
            // 
            this.pnl_desc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_desc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_desc.Controls.Add(this.lbl_desc);
            this.pnl_desc.Location = new System.Drawing.Point(638, 25);
            this.pnl_desc.Name = "pnl_desc";
            this.pnl_desc.Size = new System.Drawing.Size(192, 163);
            this.pnl_desc.TabIndex = 19;
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Location = new System.Drawing.Point(3, 5);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(46, 13);
            this.lbl_desc.TabIndex = 0;
            this.lbl_desc.Text = "lbl_desc";
            // 
            // pbox_itemImage
            // 
            this.pbox_itemImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbox_itemImage.Location = new System.Drawing.Point(448, 27);
            this.pbox_itemImage.Name = "pbox_itemImage";
            this.pbox_itemImage.Size = new System.Drawing.Size(187, 161);
            this.pbox_itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_itemImage.TabIndex = 18;
            this.pbox_itemImage.TabStop = false;
            // 
            // txt_itemDesc
            // 
            this.txt_itemDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_itemDesc.Location = new System.Drawing.Point(3, 163);
            this.txt_itemDesc.Multiline = true;
            this.txt_itemDesc.Name = "txt_itemDesc";
            this.txt_itemDesc.Size = new System.Drawing.Size(23, 25);
            this.txt_itemDesc.TabIndex = 17;
            this.txt_itemDesc.Visible = false;
            // 
            // chkbx_ItemList
            // 
            this.chkbx_ItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ItemList.FormattingEnabled = true;
            this.chkbx_ItemList.Location = new System.Drawing.Point(834, 26);
            this.chkbx_ItemList.Name = "chkbx_ItemList";
            this.chkbx_ItemList.Size = new System.Drawing.Size(96, 79);
            this.chkbx_ItemList.TabIndex = 16;
            this.chkbx_ItemList.SelectedValueChanged += new System.EventHandler(this.chkbx_ItemList_SelectedValueChanged);
            // 
            // _glassUpgToolStrip
            // 
            this._glassUpgToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._glassUpgToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._printBtn});
            this._glassUpgToolStrip.Location = new System.Drawing.Point(0, 0);
            this._glassUpgToolStrip.Name = "_glassUpgToolStrip";
            this._glassUpgToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._glassUpgToolStrip.Size = new System.Drawing.Size(932, 25);
            this._glassUpgToolStrip.TabIndex = 12;
            this._glassUpgToolStrip.Text = "_glassUpgToolStrip";
            // 
            // _printBtn
            // 
            this._printBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._printBtn.Image = ((System.Drawing.Image)(resources.GetObject("_printBtn.Image")));
            this._printBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._printBtn.Name = "_printBtn";
            this._printBtn.Size = new System.Drawing.Size(23, 22);
            this._printBtn.Text = "toolStripButton1";
            // 
            // _date
            // 
            this._date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._date.AutoSize = true;
            this._date.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._date.Location = new System.Drawing.Point(359, 78);
            this._date.Name = "_date";
            this._date.Size = new System.Drawing.Size(35, 13);
            this._date.TabIndex = 11;
            this._date.Text = "_date";
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.Location = new System.Drawing.Point(294, 78);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(37, 13);
            this.lbl_Date.TabIndex = 10;
            this.lbl_Date.Text = "Date: ";
            // 
            // _quoteNum
            // 
            this._quoteNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._quoteNum.AutoSize = true;
            this._quoteNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._quoteNum.Location = new System.Drawing.Point(357, 62);
            this._quoteNum.Name = "_quoteNum";
            this._quoteNum.Size = new System.Drawing.Size(67, 13);
            this._quoteNum.TabIndex = 9;
            this._quoteNum.Text = "_quoteNum";
            // 
            // lbl_quoteNum
            // 
            this.lbl_quoteNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_quoteNum.AutoSize = true;
            this.lbl_quoteNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quoteNum.Location = new System.Drawing.Point(294, 62);
            this.lbl_quoteNum.Name = "lbl_quoteNum";
            this.lbl_quoteNum.Size = new System.Drawing.Size(57, 13);
            this.lbl_quoteNum.TabIndex = 8;
            this.lbl_quoteNum.Text = "QuoteNo:";
            // 
            // _clientAdd
            // 
            this._clientAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._clientAdd.AutoSize = true;
            this._clientAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clientAdd.Location = new System.Drawing.Point(90, 121);
            this._clientAdd.Name = "_clientAdd";
            this._clientAdd.Size = new System.Drawing.Size(61, 13);
            this._clientAdd.TabIndex = 7;
            this._clientAdd.Text = "_clientAdd";
            // 
            // _clientName
            // 
            this._clientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._clientName.AutoSize = true;
            this._clientName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clientName.Location = new System.Drawing.Point(90, 105);
            this._clientName.Name = "_clientName";
            this._clientName.Size = new System.Drawing.Size(69, 13);
            this._clientName.TabIndex = 6;
            this._clientName.Text = "_clientName";
            // 
            // _namepos
            // 
            this._namepos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._namepos.AutoSize = true;
            this._namepos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._namepos.Location = new System.Drawing.Point(90, 60);
            this._namepos.Name = "_namepos";
            this._namepos.Size = new System.Drawing.Size(68, 13);
            this._namepos.TabIndex = 5;
            this._namepos.Text = "_name&&pos";
            // 
            // cmb_glassType
            // 
            this.cmb_glassType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_glassType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_glassType.FormattingEnabled = true;
            this.cmb_glassType.Location = new System.Drawing.Point(90, 32);
            this.cmb_glassType.Name = "cmb_glassType";
            this.cmb_glassType.Size = new System.Drawing.Size(200, 21);
            this.cmb_glassType.TabIndex = 4;
            // 
            // lbl_Address
            // 
            this.lbl_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.Location = new System.Drawing.Point(13, 121);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(54, 13);
            this.lbl_Address.TabIndex = 3;
            this.lbl_Address.Text = "Address: ";
            // 
            // lbl_ClientName
            // 
            this.lbl_ClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ClientName.AutoSize = true;
            this.lbl_ClientName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ClientName.Location = new System.Drawing.Point(13, 105);
            this.lbl_ClientName.Name = "lbl_ClientName";
            this.lbl_ClientName.Size = new System.Drawing.Size(72, 13);
            this.lbl_ClientName.TabIndex = 2;
            this.lbl_ClientName.Text = "Client Name:";
            // 
            // lbl_AE
            // 
            this.lbl_AE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_AE.AutoSize = true;
            this.lbl_AE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_AE.Location = new System.Drawing.Point(13, 60);
            this.lbl_AE.Name = "lbl_AE";
            this.lbl_AE.Size = new System.Drawing.Size(26, 13);
            this.lbl_AE.TabIndex = 1;
            this.lbl_AE.Text = "AE: ";
            // 
            // lbl_glass
            // 
            this.lbl_glass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_glass.AutoSize = true;
            this.lbl_glass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_glass.Location = new System.Drawing.Point(13, 37);
            this.lbl_glass.Name = "lbl_glass";
            this.lbl_glass.Size = new System.Drawing.Size(40, 13);
            this.lbl_glass.TabIndex = 0;
            this.lbl_glass.Text = "Glass: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.glassUpgradeDGV);
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 257);
            this.panel1.TabIndex = 1;
            // 
            // glassUpgradeDGV
            // 
            this.glassUpgradeDGV.AllowUserToAddRows = false;
            this.glassUpgradeDGV.AllowUserToResizeColumns = false;
            this.glassUpgradeDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassUpgradeDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.glassUpgradeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.glassUpgradeDGV.ContextMenuStrip = this.cmsGlassUpgrade;
            this.glassUpgradeDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glassUpgradeDGV.Location = new System.Drawing.Point(0, 0);
            this.glassUpgradeDGV.Name = "glassUpgradeDGV";
            this.glassUpgradeDGV.Size = new System.Drawing.Size(932, 257);
            this.glassUpgradeDGV.TabIndex = 0;
            // 
            // num_glassAmount
            // 
            this.num_glassAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.num_glassAmount.Location = new System.Drawing.Point(856, 457);
            this.num_glassAmount.Name = "num_glassAmount";
            this.num_glassAmount.Size = new System.Drawing.Size(68, 20);
            this.num_glassAmount.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(768, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Glass Amount: ";
            // 
            // num_wdwsAndDoors
            // 
            this.num_wdwsAndDoors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.num_wdwsAndDoors.Location = new System.Drawing.Point(856, 482);
            this.num_wdwsAndDoors.Name = "num_wdwsAndDoors";
            this.num_wdwsAndDoors.Size = new System.Drawing.Size(68, 20);
            this.num_wdwsAndDoors.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(749, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Windows / Doors: ";
            // 
            // cmsGlassUpgrade
            // 
            this.cmsGlassUpgrade.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsGlassUpgrade.Name = "cmsGlassUpgrade";
            this.cmsGlassUpgrade.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // GlassUpgradeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 510);
            this.Controls.Add(this.num_wdwsAndDoors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_glassAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Header);
            this.MinimumSize = new System.Drawing.Size(948, 549);
            this.Name = "GlassUpgradeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glass Upgrade";
            this.Load += new System.EventHandler(this.GlassUpgradeView_Load);
            this.SizeChanged += new System.EventHandler(this.GlassUpgradeView_SizeChanged);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_discount)).EndInit();
            this.pnl_desc.ResumeLayout(false);
            this.pnl_desc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_itemImage)).EndInit();
            this._glassUpgToolStrip.ResumeLayout(false);
            this._glassUpgToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.glassUpgradeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_glassAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_wdwsAndDoors)).EndInit();
            this.cmsGlassUpgrade.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView glassUpgradeDGV;
        private System.Windows.Forms.Label _quoteNum;
        private System.Windows.Forms.Label lbl_quoteNum;
        private System.Windows.Forms.Label _clientAdd;
        private System.Windows.Forms.Label _clientName;
        private System.Windows.Forms.Label _namepos;
        private System.Windows.Forms.ComboBox cmb_glassType;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_ClientName;
        private System.Windows.Forms.Label lbl_AE;
        private System.Windows.Forms.Label lbl_glass;
        private System.Windows.Forms.Label _date;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.ToolStrip _glassUpgToolStrip;
        private System.Windows.Forms.ToolStripButton _printBtn;
        private System.Windows.Forms.NumericUpDown num_discount;
        private System.Windows.Forms.Label lbl_discount;
        private System.Windows.Forms.NumericUpDown num_glassAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_wdwsAndDoors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkbx_ItemList;
        private System.Windows.Forms.TextBox txt_itemDesc;
        private System.Windows.Forms.PictureBox pbox_itemImage;
        private System.Windows.Forms.Panel pnl_desc;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ContextMenuStrip cmsGlassUpgrade;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}