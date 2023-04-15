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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintQuoteView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_showpagenum = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txt_oftexpenses = new System.Windows.Forms.TextBox();
            this.chklstbox_itemnum = new System.Windows.Forms.CheckedListBox();
            this.lbl_UniversalLabel = new System.Windows.Forms.Label();
            this.chkbox_show = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbox_Body = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbox_Salutation = new System.Windows.Forms.RichTextBox();
            this.lbl_address = new System.Windows.Forms.Label();
            this.rtbox_Address = new System.Windows.Forms.RichTextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BSQuotation = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_addinfo = new System.Windows.Forms.Label();
            this.chkbox_LnM = new System.Windows.Forms.CheckBox();
            this.chkbox_FC = new System.Windows.Forms.CheckBox();
            this.chkbox_VAT = new System.Windows.Forms.CheckBox();
            this.txtbox_LnM = new System.Windows.Forms.TextBox();
            this.txtbox_FC = new System.Windows.Forms.TextBox();
            this.txtbox_VAT = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSQuotation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbox_VAT);
            this.panel1.Controls.Add(this.txtbox_FC);
            this.panel1.Controls.Add(this.txtbox_LnM);
            this.panel1.Controls.Add(this.chkbox_VAT);
            this.panel1.Controls.Add(this.chkbox_FC);
            this.panel1.Controls.Add(this.chkbox_LnM);
            this.panel1.Controls.Add(this.lbl_addinfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chk_showpagenum);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txt_oftexpenses);
            this.panel1.Controls.Add(this.chklstbox_itemnum);
            this.panel1.Controls.Add(this.lbl_UniversalLabel);
            this.panel1.Controls.Add(this.chkbox_show);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rtbox_Body);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rtbox_Salutation);
            this.panel1.Controls.Add(this.lbl_address);
            this.panel1.Controls.Add(this.rtbox_Address);
            this.panel1.Controls.Add(this.dtp_Date);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 144);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Show Page No.";
            // 
            // chk_showpagenum
            // 
            this.chk_showpagenum.AutoSize = true;
            this.chk_showpagenum.BackColor = System.Drawing.Color.Transparent;
            this.chk_showpagenum.Location = new System.Drawing.Point(38, 8);
            this.chk_showpagenum.Name = "chk_showpagenum";
            this.chk_showpagenum.Size = new System.Drawing.Size(15, 14);
            this.chk_showpagenum.TabIndex = 19;
            this.chk_showpagenum.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(902, 113);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 28);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txt_oftexpenses
            // 
            this.txt_oftexpenses.Location = new System.Drawing.Point(38, 106);
            this.txt_oftexpenses.Name = "txt_oftexpenses";
            this.txt_oftexpenses.Size = new System.Drawing.Size(145, 25);
            this.txt_oftexpenses.TabIndex = 17;
            this.txt_oftexpenses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_oftexpenses_KeyDown);
            // 
            // chklstbox_itemnum
            // 
            this.chklstbox_itemnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstbox_itemnum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklstbox_itemnum.FormattingEnabled = true;
            this.chklstbox_itemnum.Location = new System.Drawing.Point(902, 22);
            this.chklstbox_itemnum.Name = "chklstbox_itemnum";
            this.chklstbox_itemnum.ScrollAlwaysVisible = true;
            this.chklstbox_itemnum.Size = new System.Drawing.Size(103, 80);
            this.chklstbox_itemnum.TabIndex = 18;
            this.chklstbox_itemnum.SelectedIndexChanged += new System.EventHandler(this.chklstbox_itemnum_SelectedIndexChanged);
            // 
            // lbl_UniversalLabel
            // 
            this.lbl_UniversalLabel.AutoSize = true;
            this.lbl_UniversalLabel.Location = new System.Drawing.Point(34, 59);
            this.lbl_UniversalLabel.Name = "lbl_UniversalLabel";
            this.lbl_UniversalLabel.Size = new System.Drawing.Size(106, 19);
            this.lbl_UniversalLabel.TabIndex = 16;
            this.lbl_UniversalLabel.Text = "For Screen Only";
            // 
            // chkbox_show
            // 
            this.chkbox_show.AutoSize = true;
            this.chkbox_show.Location = new System.Drawing.Point(38, 81);
            this.chkbox_show.Name = "chkbox_show";
            this.chkbox_show.Size = new System.Drawing.Size(159, 23);
            this.chkbox_show.TabIndex = 15;
            this.chkbox_show.Text = "Screen Contract Page";
            this.chkbox_show.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkbox_show.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(627, 3);
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
            this.rtbox_Body.Location = new System.Drawing.Point(627, 26);
            this.rtbox_Body.Name = "rtbox_Body";
            this.rtbox_Body.Size = new System.Drawing.Size(40, 118);
            this.rtbox_Body.TabIndex = 13;
            this.rtbox_Body.Text = resources.GetString("rtbox_Body.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Salutation";
            // 
            // rtbox_Salutation
            // 
            this.rtbox_Salutation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbox_Salutation.Location = new System.Drawing.Point(416, 26);
            this.rtbox_Salutation.Name = "rtbox_Salutation";
            this.rtbox_Salutation.Size = new System.Drawing.Size(205, 118);
            this.rtbox_Salutation.TabIndex = 11;
            this.rtbox_Salutation.Text = "INITIAL QUOTATION\n\nDear Mr. Lee,";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(205, 3);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(58, 19);
            this.lbl_address.TabIndex = 10;
            this.lbl_address.Text = "Address";
            // 
            // rtbox_Address
            // 
            this.rtbox_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbox_Address.Location = new System.Drawing.Point(205, 26);
            this.rtbox_Address.Name = "rtbox_Address";
            this.rtbox_Address.Size = new System.Drawing.Size(205, 118);
            this.rtbox_Address.TabIndex = 9;
            this.rtbox_Address.Text = "To:\nMr. Gilbert Lee\n#408 Bougainvilla St., Ayala\nAlabang Village, Muntinlupa City" +
    "\n";
            // 
            // dtp_Date
            // 
            this.dtp_Date.CustomFormat = "MMM. dd, yyyy";
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Date.Location = new System.Drawing.Point(78, 26);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(121, 25);
            this.dtp_Date.TabIndex = 7;
            this.dtp_Date.Value = new System.DateTime(2022, 11, 22, 0, 0, 0, 0);
            this.dtp_Date.ValueChanged += new System.EventHandler(this.dtp_Date_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 144);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1008, 317);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.ZoomPercent = 75;
            // 
            // BSQuotation
            // 
            this.BSQuotation.CurrentChanged += new System.EventHandler(this.BSQuotation_CurrentChanged);
            // 
            // lbl_addinfo
            // 
            this.lbl_addinfo.AutoSize = true;
            this.lbl_addinfo.Location = new System.Drawing.Point(729, 5);
            this.lbl_addinfo.Name = "lbl_addinfo";
            this.lbl_addinfo.Size = new System.Drawing.Size(103, 19);
            this.lbl_addinfo.TabIndex = 21;
            this.lbl_addinfo.Text = "Additional  Info";
            this.lbl_addinfo.Visible = false;
            // 
            // chkbox_LnM
            // 
            this.chkbox_LnM.AutoSize = true;
            this.chkbox_LnM.Location = new System.Drawing.Point(673, 28);
            this.chkbox_LnM.Name = "chkbox_LnM";
            this.chkbox_LnM.Size = new System.Drawing.Size(123, 23);
            this.chkbox_LnM.TabIndex = 22;
            this.chkbox_LnM.Text = "Labor && Mobi...";
            this.chkbox_LnM.UseVisualStyleBackColor = true;
            this.chkbox_LnM.Visible = false;
            this.chkbox_LnM.CheckedChanged += new System.EventHandler(this.chkbox_LnM_CheckedChanged);
            // 
            // chkbox_FC
            // 
            this.chkbox_FC.AutoSize = true;
            this.chkbox_FC.Location = new System.Drawing.Point(673, 59);
            this.chkbox_FC.Name = "chkbox_FC";
            this.chkbox_FC.Size = new System.Drawing.Size(119, 23);
            this.chkbox_FC.TabIndex = 23;
            this.chkbox_FC.Text = "Freight Charge";
            this.chkbox_FC.UseVisualStyleBackColor = true;
            this.chkbox_FC.Visible = false;
            this.chkbox_FC.CheckedChanged += new System.EventHandler(this.chkbox_FC_CheckedChanged);
            // 
            // chkbox_VAT
            // 
            this.chkbox_VAT.AutoSize = true;
            this.chkbox_VAT.Location = new System.Drawing.Point(673, 88);
            this.chkbox_VAT.Name = "chkbox_VAT";
            this.chkbox_VAT.Size = new System.Drawing.Size(74, 23);
            this.chkbox_VAT.TabIndex = 24;
            this.chkbox_VAT.Text = "VAT (%)";
            this.chkbox_VAT.UseVisualStyleBackColor = true;
            this.chkbox_VAT.Visible = false;
            this.chkbox_VAT.CheckedChanged += new System.EventHandler(this.chkbox_VAT_CheckedChanged);
            // 
            // txtbox_LnM
            // 
            this.txtbox_LnM.Location = new System.Drawing.Point(802, 28);
            this.txtbox_LnM.Name = "txtbox_LnM";
            this.txtbox_LnM.Size = new System.Drawing.Size(94, 25);
            this.txtbox_LnM.TabIndex = 25;
            this.txtbox_LnM.Visible = false;
            // 
            // txtbox_FC
            // 
            this.txtbox_FC.Location = new System.Drawing.Point(802, 59);
            this.txtbox_FC.Name = "txtbox_FC";
            this.txtbox_FC.Size = new System.Drawing.Size(94, 25);
            this.txtbox_FC.TabIndex = 26;
            this.txtbox_FC.Visible = false;
            // 
            // txtbox_VAT
            // 
            this.txtbox_VAT.Location = new System.Drawing.Point(802, 90);
            this.txtbox_VAT.Name = "txtbox_VAT";
            this.txtbox_VAT.Size = new System.Drawing.Size(94, 25);
            this.txtbox_VAT.TabIndex = 27;
            this.txtbox_VAT.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.BSQuotation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbox_Body;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbox_Salutation;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.RichTextBox rtbox_Address;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource BSQuotation;
        private System.Windows.Forms.CheckBox chkbox_show;
        private System.Windows.Forms.Label lbl_UniversalLabel;
        private System.Windows.Forms.TextBox txt_oftexpenses;
        private System.Windows.Forms.CheckedListBox chklstbox_itemnum;
        private System.Windows.Forms.CheckBox chk_showpagenum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_addinfo;
        private System.Windows.Forms.CheckBox chkbox_LnM;
        private System.Windows.Forms.CheckBox chkbox_VAT;
        private System.Windows.Forms.CheckBox chkbox_FC;
        private System.Windows.Forms.TextBox txtbox_VAT;
        private System.Windows.Forms.TextBox txtbox_FC;
        private System.Windows.Forms.TextBox txtbox_LnM;
    }
}