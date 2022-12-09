﻿namespace PresentationLayer.Views
{
    partial class SetMultipleGlassThicknessView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.setGlssThckNssDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_GlassType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.setGlssThckNssDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // setGlssThckNssDGV
            // 
            this.setGlssThckNssDGV.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver;
            this.setGlssThckNssDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.setGlssThckNssDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setGlssThckNssDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.setGlssThckNssDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.setGlssThckNssDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.setGlssThckNssDGV.Location = new System.Drawing.Point(3, 49);
            this.setGlssThckNssDGV.Name = "setGlssThckNssDGV";
            this.setGlssThckNssDGV.ReadOnly = true;
            this.setGlssThckNssDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.setGlssThckNssDGV.Size = new System.Drawing.Size(655, 309);
            this.setGlssThckNssDGV.TabIndex = 0;
            this.setGlssThckNssDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.setGlssThckNssDGV_RowPostPaint);
            this.setGlssThckNssDGV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setGlssThckNssDGV_MouseDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Glass Type";
            // 
            // cmb_GlassType
            // 
            this.cmb_GlassType.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_GlassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlassType.DropDownWidth = 100;
            this.cmb_GlassType.FormattingEnabled = true;
            this.cmb_GlassType.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Triple"});
            this.cmb_GlassType.Location = new System.Drawing.Point(80, 9);
            this.cmb_GlassType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_GlassType.Name = "cmb_GlassType";
            this.cmb_GlassType.Size = new System.Drawing.Size(123, 21);
            this.cmb_GlassType.TabIndex = 34;
            // 
            // SetMultipleGlassThicknessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 362);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_GlassType);
            this.Controls.Add(this.setGlssThckNssDGV);
            this.Name = "SetMultipleGlassThicknessView";
            this.Text = "Set Glass";
            this.Load += new System.EventHandler(this.SetMultipleGlassThicknessView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setGlssThckNssDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView setGlssThckNssDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_GlassType;
    }
}