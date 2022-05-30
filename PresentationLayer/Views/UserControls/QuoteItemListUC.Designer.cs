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
            this.lblNetPrice = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtboxDesc = new System.Windows.Forms.RichTextBox();
            this.tboxDimension = new System.Windows.Forms.TextBox();
            this.pboxItemImage = new System.Windows.Forms.PictureBox();
            this.tboxItemName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNetPrice
            // 
            this.lblNetPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNetPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetPrice.Location = new System.Drawing.Point(761, 0);
            this.lblNetPrice.Name = "lblNetPrice";
            this.lblNetPrice.Size = new System.Drawing.Size(119, 165);
            this.lblNetPrice.TabIndex = 15;
            this.lblNetPrice.Text = "0";
            this.lblNetPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(642, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(119, 165);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "0";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(523, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(119, 165);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "0";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(404, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(119, 165);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "0";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtboxDesc);
            this.panel1.Controls.Add(this.tboxDimension);
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
            // 
            // tboxDimension
            // 
            this.tboxDimension.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxDimension.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDimension.Location = new System.Drawing.Point(0, 0);
            this.tboxDimension.Name = "tboxDimension";
            this.tboxDimension.ReadOnly = true;
            this.tboxDimension.Size = new System.Drawing.Size(201, 25);
            this.tboxDimension.TabIndex = 16;
            // 
            // pboxItemImage
            // 
            this.pboxItemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxItemImage.Location = new System.Drawing.Point(0, 25);
            this.pboxItemImage.Name = "pboxItemImage";
            this.pboxItemImage.Size = new System.Drawing.Size(201, 140);
            this.pboxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxItemImage.TabIndex = 20;
            this.pboxItemImage.TabStop = false;
            // 
            // tboxItemName
            // 
            this.tboxItemName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tboxItemName.Location = new System.Drawing.Point(0, 0);
            this.tboxItemName.Name = "tboxItemName";
            this.tboxItemName.Size = new System.Drawing.Size(201, 25);
            this.tboxItemName.TabIndex = 21;
            // 
            // QuoteItemListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pboxItemImage);
            this.Controls.Add(this.tboxItemName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblNetPrice);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuoteItemListUC";
            this.Size = new System.Drawing.Size(880, 165);
            this.Load += new System.EventHandler(this.QuoteItemListUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxItemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNetPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtboxDesc;
        private System.Windows.Forms.TextBox tboxDimension;
        private System.Windows.Forms.PictureBox pboxItemImage;
        private System.Windows.Forms.TextBox tboxItemName;
    }
}
