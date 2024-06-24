namespace PresentationLayer.Views
{
    partial class PDFCompilerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFCompilerView));
            this.toolstrip_compiler = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeSyncDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_CompileReports = new System.Windows.Forms.Button();
            this.btn_CompilePDF = new System.Windows.Forms.Button();
            this.partialAdjustment_chkbx = new System.Windows.Forms.CheckBox();
            this.wthAnnex_chkbx = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolstrip_compiler.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolstrip_compiler
            // 
            this.toolstrip_compiler.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolstrip_compiler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolstrip_compiler.Location = new System.Drawing.Point(0, 0);
            this.toolstrip_compiler.Name = "toolstrip_compiler";
            this.toolstrip_compiler.Size = new System.Drawing.Size(366, 27);
            this.toolstrip_compiler.TabIndex = 0;
            this.toolstrip_compiler.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSyncDirToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "Settings";
            // 
            // changeSyncDirToolStripMenuItem
            // 
            this.changeSyncDirToolStripMenuItem.Name = "changeSyncDirToolStripMenuItem";
            this.changeSyncDirToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.changeSyncDirToolStripMenuItem.Text = "Change Sync Dir";
            this.changeSyncDirToolStripMenuItem.Click += new System.EventHandler(this.changeSyncDirToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 81);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.Controls.Add(this.btn_CompileReports, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_CompilePDF, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.partialAdjustment_chkbx, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wthAnnex_chkbx, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_CompileReports
            // 
            this.btn_CompileReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CompileReports.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_CompileReports.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CompileReports.Location = new System.Drawing.Point(3, 36);
            this.btn_CompileReports.Name = "btn_CompileReports";
            this.btn_CompileReports.Size = new System.Drawing.Size(224, 42);
            this.btn_CompileReports.TabIndex = 0;
            this.btn_CompileReports.TabStop = false;
            this.btn_CompileReports.Text = "Compile Quotation,Screen And Summary.";
            this.btn_CompileReports.UseVisualStyleBackColor = true;
            this.btn_CompileReports.Click += new System.EventHandler(this.btn_CompileReports_Click);
            // 
            // btn_CompilePDF
            // 
            this.btn_CompilePDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CompilePDF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_CompilePDF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            this.btn_CompilePDF.Location = new System.Drawing.Point(241, 36);
            this.btn_CompilePDF.Name = "btn_CompilePDF";
            this.btn_CompilePDF.Size = new System.Drawing.Size(122, 42);
            this.btn_CompilePDF.TabIndex = 1;
            this.btn_CompilePDF.TabStop = false;
            this.btn_CompilePDF.Text = "Compile PDF Files";
            this.btn_CompilePDF.UseVisualStyleBackColor = true;
            this.btn_CompilePDF.Click += new System.EventHandler(this.btn_CompilePDF_Click);
            // 
            // partialAdjustment_chkbx
            // 
            this.partialAdjustment_chkbx.AutoSize = true;
            this.partialAdjustment_chkbx.Location = new System.Drawing.Point(3, 3);
            this.partialAdjustment_chkbx.Name = "partialAdjustment_chkbx";
            this.partialAdjustment_chkbx.Size = new System.Drawing.Size(144, 21);
            this.partialAdjustment_chkbx.TabIndex = 2;
            this.partialAdjustment_chkbx.Text = "Partial Adjustment";
            this.partialAdjustment_chkbx.UseVisualStyleBackColor = true;
            // 
            // wthAnnex_chkbx
            // 
            this.wthAnnex_chkbx.AutoSize = true;
            this.wthAnnex_chkbx.Checked = true;
            this.wthAnnex_chkbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wthAnnex_chkbx.Location = new System.Drawing.Point(241, 3);
            this.wthAnnex_chkbx.Name = "wthAnnex_chkbx";
            this.wthAnnex_chkbx.Size = new System.Drawing.Size(97, 21);
            this.wthAnnex_chkbx.TabIndex = 3;
            this.wthAnnex_chkbx.Text = "with Annex";
            this.wthAnnex_chkbx.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Pdf Files|*.pdf";
            this.openFileDialog1.Multiselect = true;
            // 
            // PDFCompilerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 108);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolstrip_compiler);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PDFCompilerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFCompiler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PDFCompilerView_FormClosed);
            this.toolstrip_compiler.ResumeLayout(false);
            this.toolstrip_compiler.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstrip_compiler;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_CompileReports;
        private System.Windows.Forms.Button btn_CompilePDF;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem changeSyncDirToolStripMenuItem;
        private System.Windows.Forms.CheckBox partialAdjustment_chkbx;
        private System.Windows.Forms.CheckBox wthAnnex_chkbx;
    }
}