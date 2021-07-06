namespace PresentationLayer.Views
{
    partial class CreateNewGlassColorView
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
            this.dgvGlassColorList = new System.Windows.Forms.DataGridView();
            this.lblGlassColor = new System.Windows.Forms.Label();
            this.tboxGlassColor = new System.Windows.Forms.TextBox();
            this.btnAddGlassColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassColorList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGlassColorList
            // 
            this.dgvGlassColorList.AllowUserToAddRows = false;
            this.dgvGlassColorList.AllowUserToDeleteRows = false;
            this.dgvGlassColorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlassColorList.Location = new System.Drawing.Point(10, 10);
            this.dgvGlassColorList.Name = "dgvGlassColorList";
            this.dgvGlassColorList.ReadOnly = true;
            this.dgvGlassColorList.Size = new System.Drawing.Size(299, 275);
            this.dgvGlassColorList.TabIndex = 0;
            this.dgvGlassColorList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGlassColorList_RowPostPaint);
            // 
            // lblGlassColor
            // 
            this.lblGlassColor.AutoSize = true;
            this.lblGlassColor.Location = new System.Drawing.Point(13, 294);
            this.lblGlassColor.Name = "lblGlassColor";
            this.lblGlassColor.Size = new System.Drawing.Size(31, 13);
            this.lblGlassColor.TabIndex = 6;
            this.lblGlassColor.Text = "Color";
            // 
            // tboxGlassColor
            // 
            this.tboxGlassColor.Location = new System.Drawing.Point(50, 291);
            this.tboxGlassColor.Name = "tboxGlassColor";
            this.tboxGlassColor.Size = new System.Drawing.Size(191, 20);
            this.tboxGlassColor.TabIndex = 5;
            this.tboxGlassColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxGlassColor_KeyDown);
            // 
            // btnAddGlassColor
            // 
            this.btnAddGlassColor.Location = new System.Drawing.Point(242, 291);
            this.btnAddGlassColor.Name = "btnAddGlassColor";
            this.btnAddGlassColor.Size = new System.Drawing.Size(68, 21);
            this.btnAddGlassColor.TabIndex = 4;
            this.btnAddGlassColor.Text = "Add";
            this.btnAddGlassColor.UseVisualStyleBackColor = true;
            this.btnAddGlassColor.Click += new System.EventHandler(this.btnAddGlassColor_Click);
            // 
            // CreateNewGlassColorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 319);
            this.Controls.Add(this.lblGlassColor);
            this.Controls.Add(this.tboxGlassColor);
            this.Controls.Add(this.btnAddGlassColor);
            this.Controls.Add(this.dgvGlassColorList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewGlassColorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color";
            this.Load += new System.EventHandler(this.CreateNewGlassColorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassColorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGlassColorList;
        private System.Windows.Forms.Label lblGlassColor;
        private System.Windows.Forms.TextBox tboxGlassColor;
        private System.Windows.Forms.Button btnAddGlassColor;
    }
}