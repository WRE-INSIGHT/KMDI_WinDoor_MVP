namespace PresentationLayer.Views
{
    partial class CreateNewGlassTypeView
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
            this.dgvGlassTypeList = new System.Windows.Forms.DataGridView();
            this.btnAddGlassType = new System.Windows.Forms.Button();
            this.tboxGlassType = new System.Windows.Forms.TextBox();
            this.lblGlassType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGlassTypeList
            // 
            this.dgvGlassTypeList.AllowUserToAddRows = false;
            this.dgvGlassTypeList.AllowUserToDeleteRows = false;
            this.dgvGlassTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGlassTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlassTypeList.Location = new System.Drawing.Point(12, 12);
            this.dgvGlassTypeList.Name = "dgvGlassTypeList";
            this.dgvGlassTypeList.ReadOnly = true;
            this.dgvGlassTypeList.Size = new System.Drawing.Size(299, 275);
            this.dgvGlassTypeList.TabIndex = 0;
            this.dgvGlassTypeList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGlassTypeList_RowPostPaint);
            // 
            // btnAddGlassType
            // 
            this.btnAddGlassType.Location = new System.Drawing.Point(243, 293);
            this.btnAddGlassType.Name = "btnAddGlassType";
            this.btnAddGlassType.Size = new System.Drawing.Size(68, 21);
            this.btnAddGlassType.TabIndex = 1;
            this.btnAddGlassType.Text = "Add";
            this.btnAddGlassType.UseVisualStyleBackColor = true;
            this.btnAddGlassType.Click += new System.EventHandler(this.btnAddGlassType_Click);
            // 
            // tboxGlassType
            // 
            this.tboxGlassType.Location = new System.Drawing.Point(80, 293);
            this.tboxGlassType.Name = "tboxGlassType";
            this.tboxGlassType.Size = new System.Drawing.Size(162, 20);
            this.tboxGlassType.TabIndex = 2;
            // 
            // lblGlassType
            // 
            this.lblGlassType.AutoSize = true;
            this.lblGlassType.Location = new System.Drawing.Point(14, 296);
            this.lblGlassType.Name = "lblGlassType";
            this.lblGlassType.Size = new System.Drawing.Size(60, 13);
            this.lblGlassType.TabIndex = 3;
            this.lblGlassType.Text = "Glass Type";
            // 
            // CreateNewGlassTypeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 319);
            this.Controls.Add(this.lblGlassType);
            this.Controls.Add(this.tboxGlassType);
            this.Controls.Add(this.btnAddGlassType);
            this.Controls.Add(this.dgvGlassTypeList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewGlassTypeView";
            this.Text = "Glass Type";
            this.Load += new System.EventHandler(this.CreateNewGlassTypeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassTypeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGlassTypeList;
        private System.Windows.Forms.Button btnAddGlassType;
        private System.Windows.Forms.TextBox tboxGlassType;
        private System.Windows.Forms.Label lblGlassType;
    }
}