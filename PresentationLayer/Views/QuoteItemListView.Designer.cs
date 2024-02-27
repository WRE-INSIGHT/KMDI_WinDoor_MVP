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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuoteItemListView));
            this.pnlPrintBody = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrintHeader = new System.Windows.Forms.Panel();
            this.chkbox_selectall = new System.Windows.Forms.CheckBox();
            this.TSbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSbtnGlassSummary = new System.Windows.Forms.ToolStripButton();
            this.TSbtnContractSummary = new System.Windows.Forms.ToolStripButton();
            this.TSbtnPDFCompiler = new System.Windows.Forms.ToolStripButton();
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
            this.label4.Location = new System.Drawing.Point(396, 0);
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
            this.label3.Location = new System.Drawing.Point(515, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 46);
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
            this.pnlPrintHeader.Controls.Add(this.chkbox_selectall);
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
            // chkbox_selectall
            // 
            this.chkbox_selectall.AutoSize = true;
            this.chkbox_selectall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbox_selectall.Location = new System.Drawing.Point(0, 30);
            this.chkbox_selectall.Name = "chkbox_selectall";
            this.chkbox_selectall.Size = new System.Drawing.Size(71, 17);
            this.chkbox_selectall.TabIndex = 8;
            this.chkbox_selectall.TabStop = false;
            this.chkbox_selectall.Text = "Select all";
            this.chkbox_selectall.UseVisualStyleBackColor = true;
            this.chkbox_selectall.CheckedChanged += new System.EventHandler(this.chkbox_selectall_CheckedChanged);
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
            this.TSbtnPrint,
            this.TSbtnGlassSummary,
            this.TSbtnContractSummary,
            this.TSbtnPDFCompiler});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSbtnGlassSummary
            // 
            this.TSbtnGlassSummary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSbtnGlassSummary.Image = global::PresentationLayer.Properties.Resources.glass;
            this.TSbtnGlassSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSbtnGlassSummary.Name = "TSbtnGlassSummary";
            this.TSbtnGlassSummary.Size = new System.Drawing.Size(23, 22);
            this.TSbtnGlassSummary.Text = "Glass Summary";
            this.TSbtnGlassSummary.Click += new System.EventHandler(this.TSbtnGlassSummary_Click);
            // 
            // TSbtnContractSummary
            // 
            this.TSbtnContractSummary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSbtnContractSummary.Image = global::PresentationLayer.Properties.Resources.report;
            this.TSbtnContractSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSbtnContractSummary.Name = "TSbtnContractSummary";
            this.TSbtnContractSummary.Size = new System.Drawing.Size(23, 22);
            this.TSbtnContractSummary.Text = "Contract Summary";
            this.TSbtnContractSummary.Click += new System.EventHandler(this.TSbtnContractSummary_Click);
            // 
            // TSbtnPDFCompiler
            // 
            this.TSbtnPDFCompiler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSbtnPDFCompiler.Image = ((System.Drawing.Image)(resources.GetObject("TSbtnPDFCompiler.Image")));
            this.TSbtnPDFCompiler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSbtnPDFCompiler.Name = "TSbtnPDFCompiler";
            this.TSbtnPDFCompiler.Size = new System.Drawing.Size(23, 22);
            this.TSbtnPDFCompiler.Text = "PDF Compiler";
            this.TSbtnPDFCompiler.Click += new System.EventHandler(this.TSbtnPDFCompiler_Click);
            // 
            // QuoteItemListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(868, 349);
            this.Controls.Add(this.pnlPrintBody);
            this.Controls.Add(this.pnlPrintHeader);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuoteItemListView";
            this.ShowIcon = false;
            this.Text = "Item List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuoteItemListView_FormClosed);
            this.Load += new System.EventHandler(this.QuoteItemListView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuoteItemListView_KeyDown);
            this.pnlPrintHeader.ResumeLayout(false);
            this.pnlPrintHeader.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton TSbtnGlassSummary;
        private System.Windows.Forms.ToolStripButton TSbtnContractSummary;
        private System.Windows.Forms.CheckBox chkbox_selectall;
        private System.Windows.Forms.ToolStripButton TSbtnPDFCompiler;
    }
}