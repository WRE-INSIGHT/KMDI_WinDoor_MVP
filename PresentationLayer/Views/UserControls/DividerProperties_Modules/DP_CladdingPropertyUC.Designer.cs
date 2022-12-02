namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    partial class DP_CladdingPropertyUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.num_CladdingSize = new System.Windows.Forms.NumericUpDown();
            this.lbl_CladdingSize = new System.Windows.Forms.Label();
            this.btn_DeleteCladding = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_CladdingSize)).BeginInit();
            this.SuspendLayout();
            // 
            // num_CladdingSize
            // 
            this.num_CladdingSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CladdingSize.Location = new System.Drawing.Point(60, 2);
            this.num_CladdingSize.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.num_CladdingSize.Name = "num_CladdingSize";
            this.num_CladdingSize.Size = new System.Drawing.Size(64, 23);
            this.num_CladdingSize.TabIndex = 18;
            this.num_CladdingSize.ValueChanged += new System.EventHandler(this.num_CladdingSize_ValueChanged);
            // 
            // lbl_CladdingSize
            // 
            this.lbl_CladdingSize.AutoSize = true;
            this.lbl_CladdingSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CladdingSize.Location = new System.Drawing.Point(4, 6);
            this.lbl_CladdingSize.Name = "lbl_CladdingSize";
            this.lbl_CladdingSize.Size = new System.Drawing.Size(43, 15);
            this.lbl_CladdingSize.TabIndex = 17;
            this.lbl_CladdingSize.Text = "Height";
            // 
            // btn_DeleteCladding
            // 
            this.btn_DeleteCladding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteCladding.FlatAppearance.BorderSize = 0;
            this.btn_DeleteCladding.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_DeleteCladding.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_DeleteCladding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteCladding.Location = new System.Drawing.Point(127, 2);
            this.btn_DeleteCladding.Name = "btn_DeleteCladding";
            this.btn_DeleteCladding.Size = new System.Drawing.Size(23, 23);
            this.btn_DeleteCladding.TabIndex = 19;
            this.btn_DeleteCladding.Text = "X";
            this.btn_DeleteCladding.UseVisualStyleBackColor = true;
            this.btn_DeleteCladding.Click += new System.EventHandler(this.btn_DeleteCladding_Click);
            // 
            // DP_CladdingPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_DeleteCladding);
            this.Controls.Add(this.num_CladdingSize);
            this.Controls.Add(this.lbl_CladdingSize);
            this.Name = "DP_CladdingPropertyUC";
            this.Size = new System.Drawing.Size(152, 28);
            this.Load += new System.EventHandler(this.DP_CladdingPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CladdingSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_CladdingSize;
        private System.Windows.Forms.Label lbl_CladdingSize;
        private System.Windows.Forms.Button btn_DeleteCladding;
    }
}
