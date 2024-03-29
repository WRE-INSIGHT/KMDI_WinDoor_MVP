﻿namespace PresentationLayer.Views
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
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkbx_SummaryLessD = new System.Windows.Forms.CheckBox();
            this.btnCompileReport = new System.Windows.Forms.Button();
            this.txt_SummaryVat = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_oftexpenses = new System.Windows.Forms.TextBox();
            this.chkbox_showVat = new System.Windows.Forms.CheckBox();
            this.chklst_glassType = new System.Windows.Forms.CheckedListBox();
            this.txt_guVat = new System.Windows.Forms.TextBox();
            this.chkbx_guShowVat = new System.Windows.Forms.CheckBox();
            this.cmb_guNotedBy = new System.Windows.Forms.ComboBox();
            this.chkbx_guShowNotedBy = new System.Windows.Forms.CheckBox();
            this.cmb_guReviewedBy = new System.Windows.Forms.ComboBox();
            this.chkbx_guShowReviewedBy = new System.Windows.Forms.CheckBox();
            this.cmb_GlassType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbox_rowlimit = new System.Windows.Forms.TextBox();
            this.chkbox_subtotal = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chk_showimagelist = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_selectall = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.txtbx_SummaryLessD = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 36);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(554, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 34);
            this.label7.TabIndex = 3;
            this.label7.Text = "Glass Upgrade";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Screen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Summary of Contract";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtbx_SummaryLessD);
            this.panel2.Controls.Add(this.chkbx_SummaryLessD);
            this.panel2.Controls.Add(this.btnCompileReport);
            this.panel2.Controls.Add(this.txt_SummaryVat);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.txt_oftexpenses);
            this.panel2.Controls.Add(this.chkbox_showVat);
            this.panel2.Controls.Add(this.chklst_glassType);
            this.panel2.Controls.Add(this.txt_guVat);
            this.panel2.Controls.Add(this.chkbx_guShowVat);
            this.panel2.Controls.Add(this.cmb_guNotedBy);
            this.panel2.Controls.Add(this.chkbx_guShowNotedBy);
            this.panel2.Controls.Add(this.cmb_guReviewedBy);
            this.panel2.Controls.Add(this.chkbx_guShowReviewedBy);
            this.panel2.Controls.Add(this.cmb_GlassType);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtbox_rowlimit);
            this.panel2.Controls.Add(this.chkbox_subtotal);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 145);
            this.panel2.TabIndex = 1;
            // 
            // chkbx_SummaryLessD
            // 
            this.chkbx_SummaryLessD.AutoSize = true;
            this.chkbx_SummaryLessD.ForeColor = System.Drawing.Color.Red;
            this.chkbx_SummaryLessD.Location = new System.Drawing.Point(375, 49);
            this.chkbx_SummaryLessD.Name = "chkbx_SummaryLessD";
            this.chkbx_SummaryLessD.Size = new System.Drawing.Size(94, 17);
            this.chkbx_SummaryLessD.TabIndex = 15;
            this.chkbx_SummaryLessD.Text = "*LessDiscount";
            this.chkbx_SummaryLessD.UseVisualStyleBackColor = true;
            this.chkbx_SummaryLessD.CheckedChanged += new System.EventHandler(this.chkbx_SummaryLessD_CheckedChanged);
            // 
            // btnCompileReport
            // 
            this.btnCompileReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompileReport.Location = new System.Drawing.Point(296, 101);
            this.btnCompileReport.Name = "btnCompileReport";
            this.btnCompileReport.Size = new System.Drawing.Size(161, 37);
            this.btnCompileReport.TabIndex = 1;
            this.btnCompileReport.Text = "Compile Report";
            this.btnCompileReport.UseVisualStyleBackColor = true;
            this.btnCompileReport.Click += new System.EventHandler(this.btnCompileReport_Click);
            // 
            // txt_SummaryVat
            // 
            this.txt_SummaryVat.Location = new System.Drawing.Point(296, 66);
            this.txt_SummaryVat.Multiline = true;
            this.txt_SummaryVat.Name = "txt_SummaryVat";
            this.txt_SummaryVat.Size = new System.Drawing.Size(78, 24);
            this.txt_SummaryVat.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(296, 93);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(161, 4);
            this.panel5.TabIndex = 8;
            // 
            // txt_oftexpenses
            // 
            this.txt_oftexpenses.Location = new System.Drawing.Point(296, 21);
            this.txt_oftexpenses.Multiline = true;
            this.txt_oftexpenses.Name = "txt_oftexpenses";
            this.txt_oftexpenses.Size = new System.Drawing.Size(161, 23);
            this.txt_oftexpenses.TabIndex = 0;
            // 
            // chkbox_showVat
            // 
            this.chkbox_showVat.AutoSize = true;
            this.chkbox_showVat.ForeColor = System.Drawing.Color.Red;
            this.chkbox_showVat.Location = new System.Drawing.Point(296, 49);
            this.chkbox_showVat.Name = "chkbox_showVat";
            this.chkbox_showVat.Size = new System.Drawing.Size(46, 17);
            this.chkbox_showVat.TabIndex = 7;
            this.chkbox_showVat.Text = "*Vat";
            this.chkbox_showVat.UseVisualStyleBackColor = true;
            this.chkbox_showVat.CheckedChanged += new System.EventHandler(this.chkbox_showVat_CheckedChanged);
            // 
            // chklst_glassType
            // 
            this.chklst_glassType.FormattingEnabled = true;
            this.chklst_glassType.Location = new System.Drawing.Point(633, 20);
            this.chklst_glassType.Name = "chklst_glassType";
            this.chklst_glassType.ScrollAlwaysVisible = true;
            this.chklst_glassType.Size = new System.Drawing.Size(170, 124);
            this.chklst_glassType.TabIndex = 14;
            // 
            // txt_guVat
            // 
            this.txt_guVat.Location = new System.Drawing.Point(547, 119);
            this.txt_guVat.Name = "txt_guVat";
            this.txt_guVat.Size = new System.Drawing.Size(76, 20);
            this.txt_guVat.TabIndex = 13;
            // 
            // chkbx_guShowVat
            // 
            this.chkbx_guShowVat.AutoSize = true;
            this.chkbx_guShowVat.Location = new System.Drawing.Point(472, 121);
            this.chkbx_guShowVat.Name = "chkbx_guShowVat";
            this.chkbx_guShowVat.Size = new System.Drawing.Size(80, 17);
            this.chkbx_guShowVat.TabIndex = 12;
            this.chkbx_guShowVat.Text = "ShowVat %";
            this.chkbx_guShowVat.UseVisualStyleBackColor = true;
            this.chkbx_guShowVat.CheckedChanged += new System.EventHandler(this.chkbx_guVat_CheckedChanged);
            // 
            // cmb_guNotedBy
            // 
            this.cmb_guNotedBy.FormattingEnabled = true;
            this.cmb_guNotedBy.Location = new System.Drawing.Point(472, 91);
            this.cmb_guNotedBy.Name = "cmb_guNotedBy";
            this.cmb_guNotedBy.Size = new System.Drawing.Size(151, 21);
            this.cmb_guNotedBy.TabIndex = 11;
            // 
            // chkbx_guShowNotedBy
            // 
            this.chkbx_guShowNotedBy.AutoSize = true;
            this.chkbx_guShowNotedBy.Location = new System.Drawing.Point(472, 73);
            this.chkbx_guShowNotedBy.Name = "chkbx_guShowNotedBy";
            this.chkbx_guShowNotedBy.Size = new System.Drawing.Size(100, 17);
            this.chkbx_guShowNotedBy.TabIndex = 10;
            this.chkbx_guShowNotedBy.Text = "Show Noted By";
            this.chkbx_guShowNotedBy.UseVisualStyleBackColor = true;
            this.chkbx_guShowNotedBy.CheckedChanged += new System.EventHandler(this.chkbox_guShowNotedBy_CheckedChanged);
            // 
            // cmb_guReviewedBy
            // 
            this.cmb_guReviewedBy.FormattingEnabled = true;
            this.cmb_guReviewedBy.Location = new System.Drawing.Point(472, 46);
            this.cmb_guReviewedBy.Name = "cmb_guReviewedBy";
            this.cmb_guReviewedBy.Size = new System.Drawing.Size(151, 21);
            this.cmb_guReviewedBy.TabIndex = 9;
            // 
            // chkbx_guShowReviewedBy
            // 
            this.chkbx_guShowReviewedBy.AutoSize = true;
            this.chkbx_guShowReviewedBy.Location = new System.Drawing.Point(472, 27);
            this.chkbx_guShowReviewedBy.Name = "chkbx_guShowReviewedBy";
            this.chkbx_guShowReviewedBy.Size = new System.Drawing.Size(119, 17);
            this.chkbx_guShowReviewedBy.TabIndex = 8;
            this.chkbx_guShowReviewedBy.Text = "Show Reviewed By";
            this.chkbx_guShowReviewedBy.UseVisualStyleBackColor = true;
            this.chkbx_guShowReviewedBy.CheckedChanged += new System.EventHandler(this.chkbx_guShowReviewedBy_CheckedChanged);
            // 
            // cmb_GlassType
            // 
            this.cmb_GlassType.FormattingEnabled = true;
            this.cmb_GlassType.Location = new System.Drawing.Point(145, 95);
            this.cmb_GlassType.Name = "cmb_GlassType";
            this.cmb_GlassType.Size = new System.Drawing.Size(50, 21);
            this.cmb_GlassType.TabIndex = 6;
            this.cmb_GlassType.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(216, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "- Row Limit";
            // 
            // txtbox_rowlimit
            // 
            this.txtbox_rowlimit.Location = new System.Drawing.Point(145, 49);
            this.txtbox_rowlimit.Name = "txtbox_rowlimit";
            this.txtbox_rowlimit.Size = new System.Drawing.Size(69, 20);
            this.txtbox_rowlimit.TabIndex = 4;
            // 
            // chkbox_subtotal
            // 
            this.chkbox_subtotal.AutoSize = true;
            this.chkbox_subtotal.Location = new System.Drawing.Point(145, 26);
            this.chkbox_subtotal.Name = "chkbox_subtotal";
            this.chkbox_subtotal.Size = new System.Drawing.Size(69, 17);
            this.chkbox_subtotal.TabIndex = 3;
            this.chkbox_subtotal.Text = "SubTotal";
            this.chkbox_subtotal.UseVisualStyleBackColor = true;
            this.chkbox_subtotal.CheckedChanged += new System.EventHandler(this.chkbox_subtotal_CheckedChanged);
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
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 20);
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
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(315, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "*Out of Town Expenses";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(684, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Glass Type";
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
            // txtbx_SummaryLessD
            // 
            this.txtbx_SummaryLessD.Location = new System.Drawing.Point(375, 66);
            this.txtbx_SummaryLessD.Multiline = true;
            this.txtbx_SummaryLessD.Name = "txtbx_SummaryLessD";
            this.txtbx_SummaryLessD.Size = new System.Drawing.Size(78, 24);
            this.txtbx_SummaryLessD.TabIndex = 16;
            // 
            // RDLCReportCompilerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 181);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(652, 220);
            this.Name = "RDLCReportCompilerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Compiler";
            this.Load += new System.EventHandler(this.RDLCReportCompilerView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.TextBox txt_oftexpenses;
        private System.Windows.Forms.TextBox txt_SummaryVat;
        private System.Windows.Forms.CheckBox chkbox_showVat;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkbox_subtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbox_rowlimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_GlassType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_guNotedBy;
        private System.Windows.Forms.CheckBox chkbx_guShowNotedBy;
        private System.Windows.Forms.ComboBox cmb_guReviewedBy;
        private System.Windows.Forms.CheckBox chkbx_guShowReviewedBy;
        private System.Windows.Forms.CheckBox chkbx_guShowVat;
        private System.Windows.Forms.TextBox txt_guVat;
        private System.Windows.Forms.CheckedListBox chklst_glassType;
        private System.Windows.Forms.CheckBox chkbx_SummaryLessD;
        private System.Windows.Forms.TextBox txtbx_SummaryLessD;
    }
}