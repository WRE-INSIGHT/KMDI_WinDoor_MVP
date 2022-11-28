namespace PresentationLayer.Views.UserControls
{
    partial class QuoteItemListUC
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
            this.tboxWindoorNumber = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblNetPrice = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pboxItemImage = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tboxItemName = new System.Windows.Forms.TextBox();
            this.txt_ItemNumber = new System.Windows.Forms.TextBox();
            this.pboxTopView = new System.Windows.Forms.PictureBox();
            this.NudItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.NudItemDiscount = new System.Windows.Forms.NumericUpDown();
            this.nudItemPrice = new System.Windows.Forms.NumericUpDown();
            this.CMS_Items = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.suggestedPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllDiscountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemPrice)).BeginInit();
            this.CMS_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtboxDesc);
            this.panel1.Controls.Add(this.tboxWindoorNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 165);
            this.panel1.TabIndex = 19;
            // 
            // rtboxDesc
            // 
            this.rtboxDesc.AcceptsTab = true;
            this.rtboxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtboxDesc.Location = new System.Drawing.Point(0, 25);
            this.rtboxDesc.Name = "rtboxDesc";
            this.rtboxDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtboxDesc.Size = new System.Drawing.Size(201, 138);
            this.rtboxDesc.TabIndex = 17;
            this.rtboxDesc.Text = "";
            this.rtboxDesc.TextChanged += new System.EventHandler(this.rtboxDesc_TextChanged);
            // 
            // tboxWindoorNumber
            // 
            this.tboxWindoorNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxWindoorNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxWindoorNumber.Location = new System.Drawing.Point(0, 0);
            this.tboxWindoorNumber.Name = "tboxWindoorNumber";
            this.tboxWindoorNumber.Size = new System.Drawing.Size(201, 25);
            this.tboxWindoorNumber.TabIndex = 18;
            this.tboxWindoorNumber.TextChanged += new System.EventHandler(this.tboxWindoorNumber_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(404, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(119, 165);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "1";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblQuantity.TextChanged += new System.EventHandler(this.ComputeNetPriceTextChange);
            this.lblQuantity.DoubleClick += new System.EventHandler(this.lblQuantity_DoubleClick);
            // 
            // lblPrice
            // 
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(523, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(119, 165);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "1";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPrice.TextChanged += new System.EventHandler(this.ComputeNetPriceTextChange);
            this.lblPrice.DoubleClick += new System.EventHandler(this.lblPrice_DoubleClick);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(642, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(119, 165);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "30%";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDiscount.TextChanged += new System.EventHandler(this.ComputeNetPriceTextChange);
            this.lblDiscount.DoubleClick += new System.EventHandler(this.lblDiscount_DoubleClick);
            // 
            // lblNetPrice
            // 
            this.lblNetPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNetPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetPrice.Location = new System.Drawing.Point(761, 0);
            this.lblNetPrice.Name = "lblNetPrice";
            this.lblNetPrice.Size = new System.Drawing.Size(119, 165);
            this.lblNetPrice.TabIndex = 15;
            this.lblNetPrice.Text = "1";
            this.lblNetPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pboxItemImage);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pboxTopView);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 165);
            this.panel2.TabIndex = 23;
            // 
            // pboxItemImage
            // 
            this.pboxItemImage.BackColor = System.Drawing.Color.White;
            this.pboxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxItemImage.Location = new System.Drawing.Point(0, 26);
            this.pboxItemImage.Name = "pboxItemImage";
            this.pboxItemImage.Size = new System.Drawing.Size(200, 109);
            this.pboxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxItemImage.TabIndex = 20;
            this.pboxItemImage.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tboxItemName);
            this.panel3.Controls.Add(this.txt_ItemNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 26);
            this.panel3.TabIndex = 23;
            // 
            // tboxItemName
            // 
            this.tboxItemName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tboxItemName.Location = new System.Drawing.Point(58, 0);
            this.tboxItemName.Name = "tboxItemName";
            this.tboxItemName.Size = new System.Drawing.Size(142, 25);
            this.tboxItemName.TabIndex = 21;
            this.tboxItemName.TextChanged += new System.EventHandler(this.tboxItemName_TextChanged);
            // 
            // txt_ItemNumber
            // 
            this.txt_ItemNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ItemNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_ItemNumber.Enabled = false;
            this.txt_ItemNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_ItemNumber.Location = new System.Drawing.Point(0, 0);
            this.txt_ItemNumber.Name = "txt_ItemNumber";
            this.txt_ItemNumber.Size = new System.Drawing.Size(58, 25);
            this.txt_ItemNumber.TabIndex = 22;
            this.txt_ItemNumber.Text = "Item";
            // 
            // pboxTopView
            // 
            this.pboxTopView.BackColor = System.Drawing.Color.White;
            this.pboxTopView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pboxTopView.Location = new System.Drawing.Point(0, 135);
            this.pboxTopView.Name = "pboxTopView";
            this.pboxTopView.Size = new System.Drawing.Size(200, 30);
            this.pboxTopView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxTopView.TabIndex = 22;
            this.pboxTopView.TabStop = false;
            // 
            // NudItemQuantity
            // 
            this.NudItemQuantity.Location = new System.Drawing.Point(404, 1);
            this.NudItemQuantity.Name = "NudItemQuantity";
            this.NudItemQuantity.Size = new System.Drawing.Size(105, 22);
            this.NudItemQuantity.TabIndex = 24;
            this.NudItemQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudItemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudItemQuantity.ValueChanged += new System.EventHandler(this.NudItemQuantity_ValueChanged);
            this.NudItemQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudItemQuantity_KeyDown);
            // 
            // NudItemDiscount
            // 
            this.NudItemDiscount.Location = new System.Drawing.Point(642, 1);
            this.NudItemDiscount.Name = "NudItemDiscount";
            this.NudItemDiscount.Size = new System.Drawing.Size(105, 22);
            this.NudItemDiscount.TabIndex = 25;
            this.NudItemDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudItemDiscount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NudItemDiscount.ValueChanged += new System.EventHandler(this.NudItemDiscount_ValueChanged);
            this.NudItemDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudItemDiscount_KeyDown);
            // 
            // nudItemPrice
            // 
            this.nudItemPrice.Location = new System.Drawing.Point(523, 1);
            this.nudItemPrice.Name = "nudItemPrice";
            this.nudItemPrice.Size = new System.Drawing.Size(105, 22);
            this.nudItemPrice.TabIndex = 26;
            this.nudItemPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudItemPrice.ThousandsSeparator = true;
            this.nudItemPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemPrice.ValueChanged += new System.EventHandler(this.nudItemPrice_ValueChanged);
            this.nudItemPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudItemPrice_KeyDown);
            // 
            // CMS_Items
            // 
            this.CMS_Items.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suggestedPriceToolStripMenuItem,
            this.setAllDiscountToolStripMenuItem});
            this.CMS_Items.Name = "CMS_Items";
            this.CMS_Items.Size = new System.Drawing.Size(159, 48);
            // 
            // suggestedPriceToolStripMenuItem
            // 
            this.suggestedPriceToolStripMenuItem.Name = "suggestedPriceToolStripMenuItem";
            this.suggestedPriceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.suggestedPriceToolStripMenuItem.Text = "Suggested Price";
            this.suggestedPriceToolStripMenuItem.Click += new System.EventHandler(this.suggestedPriceToolStripMenuItem_Click);
            // 
            // setAllDiscountToolStripMenuItem
            // 
            this.setAllDiscountToolStripMenuItem.Name = "setAllDiscountToolStripMenuItem";
            this.setAllDiscountToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.setAllDiscountToolStripMenuItem.Text = "Set All Discount";
            this.setAllDiscountToolStripMenuItem.Click += new System.EventHandler(this.setAllDiscountToolStripMenuItem_Click);
            // 
            // QuoteItemListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.CMS_Items;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblNetPrice);
            this.Controls.Add(this.NudItemQuantity);
            this.Controls.Add(this.nudItemPrice);
            this.Controls.Add(this.NudItemDiscount);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuoteItemListUC";
            this.Size = new System.Drawing.Size(880, 165);
            this.Load += new System.EventHandler(this.QuoteItemListUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemPrice)).EndInit();
            this.CMS_Items.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtboxDesc;
        private System.Windows.Forms.TextBox tboxWindoorNumber;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblNetPrice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pboxItemImage;
        private System.Windows.Forms.TextBox tboxItemName;
        private System.Windows.Forms.NumericUpDown NudItemQuantity;
        private System.Windows.Forms.NumericUpDown NudItemDiscount;
        private System.Windows.Forms.NumericUpDown nudItemPrice;
        private System.Windows.Forms.PictureBox pboxTopView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_ItemNumber;
        private System.Windows.Forms.ContextMenuStrip CMS_Items;
        private System.Windows.Forms.ToolStripMenuItem suggestedPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllDiscountToolStripMenuItem;
    }
}
