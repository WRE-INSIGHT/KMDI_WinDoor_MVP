namespace PresentationLayer.Views
{
    partial class GlassThicknessListView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlassThicknessListView));
            this.dgv_GlassThicknessList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_search = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GlassThicknessList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_GlassThicknessList
            // 
            this.dgv_GlassThicknessList.AllowUserToAddRows = false;
            this.dgv_GlassThicknessList.AllowUserToDeleteRows = false;
            this.dgv_GlassThicknessList.AllowUserToResizeColumns = false;
            this.dgv_GlassThicknessList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgv_GlassThicknessList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_GlassThicknessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GlassThicknessList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_GlassThicknessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GlassThicknessList.Location = new System.Drawing.Point(0, 31);
            this.dgv_GlassThicknessList.MultiSelect = false;
            this.dgv_GlassThicknessList.Name = "dgv_GlassThicknessList";
            this.dgv_GlassThicknessList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GlassThicknessList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_GlassThicknessList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GlassThicknessList.Size = new System.Drawing.Size(690, 409);
            this.dgv_GlassThicknessList.TabIndex = 1;
            this.dgv_GlassThicknessList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GlassThicknessList_CellDoubleClick);
            this.dgv_GlassThicknessList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_GlassThicknessList_CellFormatting);
            this.dgv_GlassThicknessList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_GlassThicknessList_RowPostPaint);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(690, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double-click the item to select glass thickness.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbox_search
            // 
            this.txtbox_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_search.Location = new System.Drawing.Point(38, 3);
            this.txtbox_search.Multiline = true;
            this.txtbox_search.Name = "txtbox_search";
            this.txtbox_search.Size = new System.Drawing.Size(143, 25);
            this.txtbox_search.TabIndex = 3;
            this.txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbox_search.TextChanged += new System.EventHandler(this.txtbox_search_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtbox_search);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 31);
            this.panel1.TabIndex = 5;
            // 
            // GlassThicknessListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 465);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_GlassThicknessList);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlassThicknessListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glass Thickness List";
            this.Load += new System.EventHandler(this.GlassThicknessList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GlassThicknessList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_GlassThicknessList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_search;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}