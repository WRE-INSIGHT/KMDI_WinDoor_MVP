﻿namespace PresentationLayer.Views.UserControls
{
    partial class PartialAdjustmentUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartialAdjustmentUC));
            this.pnl_Header = new System.Windows.Forms.Panel();
            this.lbl_ItemNo = new System.Windows.Forms.Label();
            this.btn_UsePartialAdjustment = new System.Windows.Forms.Button();
            this.btn_HideAndShow = new System.Windows.Forms.Button();
            this._paOldDescRTextBox = new System.Windows.Forms.RichTextBox();
            this._paPnlAfter = new System.Windows.Forms.Panel();
            this._paCurrentDescRTextBox = new System.Windows.Forms.RichTextBox();
            this._paOldDesPictureBox = new System.Windows.Forms.PictureBox();
            this._paCurrectDesPictureBox = new System.Windows.Forms.PictureBox();
            this.lbl_PrevPrice = new System.Windows.Forms.Label();
            this.lbl_CurrPrice = new System.Windows.Forms.Label();
            this.tmr_BGChange = new System.Windows.Forms.Timer(this.components);
            this.cMenuStrip_Delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_Qty = new System.Windows.Forms.Label();
            this.num_Qty = new System.Windows.Forms.NumericUpDown();
            this.pnl_Header.SuspendLayout();
            this._paPnlAfter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paOldDesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._paCurrectDesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Qty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Header.Controls.Add(this.lbl_ItemNo);
            this.pnl_Header.Controls.Add(this.btn_UsePartialAdjustment);
            this.pnl_Header.Controls.Add(this.btn_HideAndShow);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Size = new System.Drawing.Size(732, 29);
            this.pnl_Header.TabIndex = 0;
            this.pnl_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Header_MouseDown);
            this.pnl_Header.MouseEnter += new System.EventHandler(this.pnl_Header_MouseEnter);
            this.pnl_Header.MouseLeave += new System.EventHandler(this.pnl_Header_MouseLeave);
            // 
            // lbl_ItemNo
            // 
            this.lbl_ItemNo.AutoSize = true;
            this.lbl_ItemNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ItemNo.Location = new System.Drawing.Point(6, 5);
            this.lbl_ItemNo.Name = "lbl_ItemNo";
            this.lbl_ItemNo.Size = new System.Drawing.Size(20, 17);
            this.lbl_ItemNo.TabIndex = 4;
            this.lbl_ItemNo.Text = "...";
            // 
            // btn_UsePartialAdjustment
            // 
            this.btn_UsePartialAdjustment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_UsePartialAdjustment.BackgroundImage")));
            this.btn_UsePartialAdjustment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_UsePartialAdjustment.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_UsePartialAdjustment.Location = new System.Drawing.Point(673, 0);
            this.btn_UsePartialAdjustment.Name = "btn_UsePartialAdjustment";
            this.btn_UsePartialAdjustment.Size = new System.Drawing.Size(30, 29);
            this.btn_UsePartialAdjustment.TabIndex = 5;
            this.btn_UsePartialAdjustment.UseVisualStyleBackColor = true;
            this.btn_UsePartialAdjustment.Click += new System.EventHandler(this.btn_UsePartialAdjustment_Click);
            this.btn_UsePartialAdjustment.MouseEnter += new System.EventHandler(this.btn_UsePartialAdjustment_MouseEnter);
            this.btn_UsePartialAdjustment.MouseLeave += new System.EventHandler(this.btn_UsePartialAdjustment_MouseLeave);
            // 
            // btn_HideAndShow
            // 
            this.btn_HideAndShow.BackgroundImage = global::PresentationLayer.Properties.Resources.view;
            this.btn_HideAndShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_HideAndShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_HideAndShow.Location = new System.Drawing.Point(703, 0);
            this.btn_HideAndShow.Name = "btn_HideAndShow";
            this.btn_HideAndShow.Size = new System.Drawing.Size(29, 29);
            this.btn_HideAndShow.TabIndex = 6;
            this.btn_HideAndShow.UseVisualStyleBackColor = true;
            this.btn_HideAndShow.Click += new System.EventHandler(this.btn_HideAndShow_Click);
            this.btn_HideAndShow.MouseEnter += new System.EventHandler(this.btn_HideAndShow_MouseEnter);
            this.btn_HideAndShow.MouseLeave += new System.EventHandler(this.btn_HideAndShow_MouseLeave);
            // 
            // _paOldDescRTextBox
            // 
            this._paOldDescRTextBox.Location = new System.Drawing.Point(179, 0);
            this._paOldDescRTextBox.Name = "_paOldDescRTextBox";
            this._paOldDescRTextBox.Size = new System.Drawing.Size(184, 145);
            this._paOldDescRTextBox.TabIndex = 1;
            this._paOldDescRTextBox.Text = "";
            // 
            // _paPnlAfter
            // 
            this._paPnlAfter.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._paPnlAfter.Controls.Add(this._paOldDescRTextBox);
            this._paPnlAfter.Controls.Add(this._paCurrentDescRTextBox);
            this._paPnlAfter.Controls.Add(this._paOldDesPictureBox);
            this._paPnlAfter.Controls.Add(this._paCurrectDesPictureBox);
            this._paPnlAfter.Dock = System.Windows.Forms.DockStyle.Top;
            this._paPnlAfter.Location = new System.Drawing.Point(0, 29);
            this._paPnlAfter.Name = "_paPnlAfter";
            this._paPnlAfter.Size = new System.Drawing.Size(732, 146);
            this._paPnlAfter.TabIndex = 2;
            this._paPnlAfter.Resize += new System.EventHandler(this._paPnlAfter_Resize);
            // 
            // _paCurrentDescRTextBox
            // 
            this._paCurrentDescRTextBox.Location = new System.Drawing.Point(553, 0);
            this._paCurrentDescRTextBox.Name = "_paCurrentDescRTextBox";
            this._paCurrentDescRTextBox.Size = new System.Drawing.Size(177, 145);
            this._paCurrentDescRTextBox.TabIndex = 1;
            this._paCurrentDescRTextBox.Text = "";
            // 
            // _paOldDesPictureBox
            // 
            this._paOldDesPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._paOldDesPictureBox.Location = new System.Drawing.Point(0, 0);
            this._paOldDesPictureBox.Name = "_paOldDesPictureBox";
            this._paOldDesPictureBox.Size = new System.Drawing.Size(181, 145);
            this._paOldDesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._paOldDesPictureBox.TabIndex = 0;
            this._paOldDesPictureBox.TabStop = false;
            // 
            // _paCurrectDesPictureBox
            // 
            this._paCurrectDesPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._paCurrectDesPictureBox.Location = new System.Drawing.Point(363, 0);
            this._paCurrectDesPictureBox.Name = "_paCurrectDesPictureBox";
            this._paCurrectDesPictureBox.Size = new System.Drawing.Size(191, 145);
            this._paCurrectDesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._paCurrectDesPictureBox.TabIndex = 0;
            this._paCurrectDesPictureBox.TabStop = false;
            // 
            // lbl_PrevPrice
            // 
            this.lbl_PrevPrice.AutoSize = true;
            this.lbl_PrevPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrevPrice.Location = new System.Drawing.Point(178, 178);
            this.lbl_PrevPrice.Name = "lbl_PrevPrice";
            this.lbl_PrevPrice.Size = new System.Drawing.Size(20, 17);
            this.lbl_PrevPrice.TabIndex = 6;
            this.lbl_PrevPrice.Text = "...";
            // 
            // lbl_CurrPrice
            // 
            this.lbl_CurrPrice.AutoSize = true;
            this.lbl_CurrPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CurrPrice.Location = new System.Drawing.Point(552, 178);
            this.lbl_CurrPrice.Name = "lbl_CurrPrice";
            this.lbl_CurrPrice.Size = new System.Drawing.Size(20, 17);
            this.lbl_CurrPrice.TabIndex = 7;
            this.lbl_CurrPrice.Text = "...";
            // 
            // tmr_BGChange
            // 
            this.tmr_BGChange.Interval = 1;
            this.tmr_BGChange.Tick += new System.EventHandler(this.tmr_BGChange_Tick);
            // 
            // cMenuStrip_Delete
            // 
            this.cMenuStrip_Delete.Name = "cMenuStrip_Delete";
            this.cMenuStrip_Delete.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_Qty
            // 
            this.lbl_Qty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Qty.AutoSize = true;
            this.lbl_Qty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Qty.Location = new System.Drawing.Point(368, 178);
            this.lbl_Qty.Name = "lbl_Qty";
            this.lbl_Qty.Size = new System.Drawing.Size(30, 17);
            this.lbl_Qty.TabIndex = 8;
            this.lbl_Qty.Text = "Qty";
            // 
            // num_Qty
            // 
            this.num_Qty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.num_Qty.Location = new System.Drawing.Point(395, 178);
            this.num_Qty.Name = "num_Qty";
            this.num_Qty.Size = new System.Drawing.Size(56, 20);
            this.num_Qty.TabIndex = 9;
            this.num_Qty.ValueChanged += new System.EventHandler(this.num_Qty_ValueChanged);
            // 
            // PartialAdjustmentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.num_Qty);
            this.Controls.Add(this.lbl_Qty);
            this.Controls.Add(this.lbl_CurrPrice);
            this.Controls.Add(this.lbl_PrevPrice);
            this.Controls.Add(this._paPnlAfter);
            this.Controls.Add(this.pnl_Header);
            this.Name = "PartialAdjustmentUC";
            this.Size = new System.Drawing.Size(732, 200);
            this.Load += new System.EventHandler(this.PartialAdjustmentUC_Load);
            this.pnl_Header.ResumeLayout(false);
            this.pnl_Header.PerformLayout();
            this._paPnlAfter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._paOldDesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._paCurrectDesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Header;
        private System.Windows.Forms.Panel _paPnlAfter;
        private System.Windows.Forms.PictureBox _paOldDesPictureBox;
        private System.Windows.Forms.PictureBox _paCurrectDesPictureBox;
        private System.Windows.Forms.RichTextBox _paOldDescRTextBox;
        private System.Windows.Forms.RichTextBox _paCurrentDescRTextBox;
        private System.Windows.Forms.Button btn_HideAndShow;
        private System.Windows.Forms.Label lbl_ItemNo;
        private System.Windows.Forms.Button btn_UsePartialAdjustment;
        private System.Windows.Forms.Label lbl_PrevPrice;
        private System.Windows.Forms.Label lbl_CurrPrice;
        private System.Windows.Forms.Timer tmr_BGChange;
        private System.Windows.Forms.ContextMenuStrip cMenuStrip_Delete;
        private System.Windows.Forms.Label lbl_Qty;
        private System.Windows.Forms.NumericUpDown num_Qty;
    }
}
