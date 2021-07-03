namespace PresentationLayer.Views
{
    partial class CreateNewGlassSpacerView
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
            this.lblGlassSpacer = new System.Windows.Forms.Label();
            this.tboxGlassSpacer = new System.Windows.Forms.TextBox();
            this.btnAddGlassSpacer = new System.Windows.Forms.Button();
            this.dgvGlassSpacerList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassSpacerList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGlassSpacer
            // 
            this.lblGlassSpacer.AutoSize = true;
            this.lblGlassSpacer.Location = new System.Drawing.Point(14, 296);
            this.lblGlassSpacer.Name = "lblGlassSpacer";
            this.lblGlassSpacer.Size = new System.Drawing.Size(41, 13);
            this.lblGlassSpacer.TabIndex = 7;
            this.lblGlassSpacer.Text = "Spacer";
            // 
            // tboxGlassSpacer
            // 
            this.tboxGlassSpacer.Location = new System.Drawing.Point(61, 293);
            this.tboxGlassSpacer.Name = "tboxGlassSpacer";
            this.tboxGlassSpacer.Size = new System.Drawing.Size(181, 20);
            this.tboxGlassSpacer.TabIndex = 6;
            // 
            // btnAddGlassSpacer
            // 
            this.btnAddGlassSpacer.Location = new System.Drawing.Point(243, 293);
            this.btnAddGlassSpacer.Name = "btnAddGlassSpacer";
            this.btnAddGlassSpacer.Size = new System.Drawing.Size(68, 21);
            this.btnAddGlassSpacer.TabIndex = 5;
            this.btnAddGlassSpacer.Text = "Add";
            this.btnAddGlassSpacer.UseVisualStyleBackColor = true;
            this.btnAddGlassSpacer.Click += new System.EventHandler(this.btnAddGlassSpacer_Click);
            // 
            // dgvGlassSpacerList
            // 
            this.dgvGlassSpacerList.AllowUserToAddRows = false;
            this.dgvGlassSpacerList.AllowUserToDeleteRows = false;
            this.dgvGlassSpacerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGlassSpacerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlassSpacerList.Location = new System.Drawing.Point(12, 12);
            this.dgvGlassSpacerList.Name = "dgvGlassSpacerList";
            this.dgvGlassSpacerList.ReadOnly = true;
            this.dgvGlassSpacerList.Size = new System.Drawing.Size(299, 275);
            this.dgvGlassSpacerList.TabIndex = 4;
            this.dgvGlassSpacerList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGlassSpacerList_RowPostPaint);
            // 
            // CreateNewGlassSpacerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 319);
            this.Controls.Add(this.lblGlassSpacer);
            this.Controls.Add(this.tboxGlassSpacer);
            this.Controls.Add(this.btnAddGlassSpacer);
            this.Controls.Add(this.dgvGlassSpacerList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewGlassSpacerView";
            this.Text = "Spacer";
            this.Load += new System.EventHandler(this.CreateNewGlassSpacerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlassSpacerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGlassSpacer;
        private System.Windows.Forms.TextBox tboxGlassSpacer;
        private System.Windows.Forms.Button btnAddGlassSpacer;
        private System.Windows.Forms.DataGridView dgvGlassSpacerList;
    }
}