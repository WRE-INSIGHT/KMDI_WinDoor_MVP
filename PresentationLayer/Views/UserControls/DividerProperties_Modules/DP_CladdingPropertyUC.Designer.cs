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
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_CladdingSize)).BeginInit();
            this.SuspendLayout();
            // 
            // num_CladdingSize
            // 
            this.num_CladdingSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CladdingSize.Location = new System.Drawing.Point(53, 2);
            this.num_CladdingSize.Name = "num_CladdingSize";
            this.num_CladdingSize.Size = new System.Drawing.Size(95, 23);
            this.num_CladdingSize.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Height";
            // 
            // DP_CladdingPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.num_CladdingSize);
            this.Controls.Add(this.label2);
            this.Name = "DP_CladdingPropertyUC";
            this.Size = new System.Drawing.Size(152, 28);
            this.Load += new System.EventHandler(this.DP_CladdingPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CladdingSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_CladdingSize;
        private System.Windows.Forms.Label label2;
    }
}
