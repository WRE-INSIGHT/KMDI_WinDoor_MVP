namespace PresentationLayer.Views
{
    partial class PrintQuoteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintQuoteView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbox_Body = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbox_Salutation = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbox_Address = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_QuoteNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CustRef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rtbox_Body);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rtbox_Salutation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rtbox_Address);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dtp_Date);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_QuoteNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_CustRef);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 137);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Body";
            // 
            // rtbox_Body
            // 
            this.rtbox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbox_Body.Location = new System.Drawing.Point(664, 22);
            this.rtbox_Body.Name = "rtbox_Body";
            this.rtbox_Body.Size = new System.Drawing.Size(260, 112);
            this.rtbox_Body.TabIndex = 13;
            this.rtbox_Body.Text = resources.GetString("rtbox_Body.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Salutation";
            // 
            // rtbox_Salutation
            // 
            this.rtbox_Salutation.Location = new System.Drawing.Point(453, 22);
            this.rtbox_Salutation.Name = "rtbox_Salutation";
            this.rtbox_Salutation.Size = new System.Drawing.Size(205, 112);
            this.rtbox_Salutation.TabIndex = 11;
            this.rtbox_Salutation.Text = "INITIAL QUOTATION\n\nDear Mr. Lee,";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Address";
            // 
            // rtbox_Address
            // 
            this.rtbox_Address.Location = new System.Drawing.Point(242, 22);
            this.rtbox_Address.Name = "rtbox_Address";
            this.rtbox_Address.Size = new System.Drawing.Size(205, 112);
            this.rtbox_Address.TabIndex = 9;
            this.rtbox_Address.Text = "To:\nMr. Gilbert Lee\n#408 Bougainvilla St., Ayala\nAlabang Village, Muntinlupa City" +
    "\n";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(930, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dtp_Date
            // 
            this.dtp_Date.CustomFormat = "MMM. dd, yyyy";
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Date.Location = new System.Drawing.Point(84, 101);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(152, 25);
            this.dtp_Date.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // txt_QuoteNo
            // 
            this.txt_QuoteNo.Location = new System.Drawing.Point(84, 62);
            this.txt_QuoteNo.Name = "txt_QuoteNo";
            this.txt_QuoteNo.Size = new System.Drawing.Size(152, 25);
            this.txt_QuoteNo.TabIndex = 5;
            this.txt_QuoteNo.Text = "3D6568";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quote No.";
            // 
            // txt_CustRef
            // 
            this.txt_CustRef.Location = new System.Drawing.Point(84, 23);
            this.txt_CustRef.Name = "txt_CustRef";
            this.txt_CustRef.Size = new System.Drawing.Size(152, 25);
            this.txt_CustRef.TabIndex = 3;
            this.txt_CustRef.Text = "1E2648";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cust. Ref";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 137);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1008, 324);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.ZoomPercent = 75;
            // 
            // PrintQuoteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 461);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "PrintQuoteView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Quote";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintQuoteView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbox_Body;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbox_Salutation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbox_Address;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_QuoteNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CustRef;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}