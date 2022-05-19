namespace PresentationLayer.Views
{
    partial class QuoteItemListView
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
            this.pnlPrintBody = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrintHeader = new System.Windows.Forms.Panel();
            this.TSbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlPrintHeader.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrintBody
            // 
            this.pnlPrintBody.AutoScroll = true;
            this.pnlPrintBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrintBody.Location = new System.Drawing.Point(0, 73);
            this.pnlPrintBody.Name = "pnlPrintBody";
            this.pnlPrintBody.Size = new System.Drawing.Size(868, 276);
            this.pnlPrintBody.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "Price";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(628, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "Discount\r\n%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Net Price";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlPrintHeader
            // 
            this.pnlPrintHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintHeader.Controls.Add(this.label4);
            this.pnlPrintHeader.Controls.Add(this.label3);
            this.pnlPrintHeader.Controls.Add(this.label2);
            this.pnlPrintHeader.Controls.Add(this.label1);
            this.pnlPrintHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrintHeader.Location = new System.Drawing.Point(0, 25);
            this.pnlPrintHeader.Name = "pnlPrintHeader";
            this.pnlPrintHeader.Size = new System.Drawing.Size(868, 48);
            this.pnlPrintHeader.TabIndex = 4;
            // 
            // TSbtnPrint
            // 
            this.TSbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSbtnPrint.Image = global::PresentationLayer.Properties.Resources.print;
            this.TSbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSbtnPrint.Name = "TSbtnPrint";
            this.TSbtnPrint.Size = new System.Drawing.Size(23, 22);
            this.TSbtnPrint.Text = "Print";
            this.TSbtnPrint.Click += new System.EventHandler(this.TSbtnPrint_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSbtnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // QuoteItemListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(868, 349);
            this.Controls.Add(this.pnlPrintBody);
            this.Controls.Add(this.pnlPrintHeader);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuoteItemListView";
            this.ShowIcon = false;
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.QuoteItemListView_Load);
            this.pnlPrintHeader.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrintBody;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPrintHeader;
        private System.Windows.Forms.ToolStripButton TSbtnPrint;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}