namespace PresentationLayer.Views
{
    partial class RDLCReportCompilerView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCompileReport = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chk_showimagelist = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_selectall = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.txt_SummaryVat = new System.Windows.Forms.TextBox();
            this.txt_oftexpenses = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkbox_showVat = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 36);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "WinDoor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Screen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Summary of Contract";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 145);
            this.panel2.TabIndex = 1;
            // 
            // btnCompileReport
            // 
            this.btnCompileReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompileReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompileReport.Location = new System.Drawing.Point(3, 97);
            this.btnCompileReport.Name = "btnCompileReport";
            this.btnCompileReport.Size = new System.Drawing.Size(161, 23);
            this.btnCompileReport.TabIndex = 1;
            this.btnCompileReport.Text = "Compile Report";
            this.btnCompileReport.UseVisualStyleBackColor = true;
            this.btnCompileReport.Click += new System.EventHandler(this.btnCompileReport_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chk_showimagelist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(139, 123);
            this.panel4.TabIndex = 1;
            // 
            // chk_showimagelist
            // 
            this.chk_showimagelist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chk_showimagelist.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk_showimagelist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_showimagelist.FormattingEnabled = true;
            this.chk_showimagelist.Location = new System.Drawing.Point(0, 0);
            this.chk_showimagelist.Name = "chk_showimagelist";
            this.chk_showimagelist.ScrollAlwaysVisible = true;
            this.chk_showimagelist.Size = new System.Drawing.Size(139, 123);
            this.chk_showimagelist.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chk_selectall);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 20);
            this.panel3.TabIndex = 0;
            // 
            // chk_selectall
            // 
            this.chk_selectall.AutoSize = true;
            this.chk_selectall.Location = new System.Drawing.Point(57, 1);
            this.chk_selectall.Name = "chk_selectall";
            this.chk_selectall.Size = new System.Drawing.Size(70, 17);
            this.chk_selectall.TabIndex = 4;
            this.chk_selectall.Text = "Select All";
            this.chk_selectall.UseVisualStyleBackColor = true;
            this.chk_selectall.CheckedChanged += new System.EventHandler(this.chk_selectall_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(287, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "*Out of Town Expenses";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Optional";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Pdf Files|*.pdf";
            this.saveFileDialog.Title = "Save ";
            // 
            // txt_SummaryVat
            // 
            this.txt_SummaryVat.Location = new System.Drawing.Point(3, 56);
            this.txt_SummaryVat.Multiline = true;
            this.txt_SummaryVat.Name = "txt_SummaryVat";
            this.txt_SummaryVat.Size = new System.Drawing.Size(78, 24);
            this.txt_SummaryVat.TabIndex = 6;
            // 
            // txt_oftexpenses
            // 
            this.txt_oftexpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_oftexpenses.Location = new System.Drawing.Point(3, 3);
            this.txt_oftexpenses.Multiline = true;
            this.txt_oftexpenses.Name = "txt_oftexpenses";
            this.txt_oftexpenses.Size = new System.Drawing.Size(161, 24);
            this.txt_oftexpenses.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txt_oftexpenses, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_SummaryVat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkbox_showVat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCompileReport, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(288, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(167, 123);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chkbox_showVat
            // 
            this.chkbox_showVat.AutoSize = true;
            this.chkbox_showVat.ForeColor = System.Drawing.Color.Red;
            this.chkbox_showVat.Location = new System.Drawing.Point(3, 33);
            this.chkbox_showVat.Name = "chkbox_showVat";
            this.chkbox_showVat.Size = new System.Drawing.Size(42, 17);
            this.chkbox_showVat.TabIndex = 7;
            this.chkbox_showVat.Text = "Vat";
            this.chkbox_showVat.UseVisualStyleBackColor = true;
            this.chkbox_showVat.CheckedChanged += new System.EventHandler(this.chkbox_showVat_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(3, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(161, 4);
            this.panel5.TabIndex = 8;
            // 
            // RDLCReportCompilerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 181);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(473, 220);
            this.MinimumSize = new System.Drawing.Size(473, 220);
            this.Name = "RDLCReportCompilerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Summary";
            this.Load += new System.EventHandler(this.RDLCReportCompilerView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox chk_showimagelist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_selectall;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnCompileReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_oftexpenses;
        private System.Windows.Forms.TextBox txt_SummaryVat;
        private System.Windows.Forms.CheckBox chkbox_showVat;
        private System.Windows.Forms.Panel panel5;
    }
}