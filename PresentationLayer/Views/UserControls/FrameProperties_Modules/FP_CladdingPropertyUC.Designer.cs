namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_CladdingQtyPropertyUC
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
            this.nud_CladdingQty = new System.Windows.Forms.NumericUpDown();
            this.lbl_Cladding = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CladdingQty)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_CladdingQty
            // 
            this.nud_CladdingQty.Location = new System.Drawing.Point(83, 3);
            this.nud_CladdingQty.Name = "nud_CladdingQty";
            this.nud_CladdingQty.Size = new System.Drawing.Size(65, 20);
            this.nud_CladdingQty.TabIndex = 45;
            this.nud_CladdingQty.ValueChanged += new System.EventHandler(this.nud_CladdingQty_ValueChanged);
            this.nud_CladdingQty.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.nud_CladdingQty_MouseWheel);
            // 
            // lbl_Cladding
            // 
            this.lbl_Cladding.AutoSize = true;
            this.lbl_Cladding.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cladding.Location = new System.Drawing.Point(3, 6);
            this.lbl_Cladding.Name = "lbl_Cladding";
            this.lbl_Cladding.Size = new System.Drawing.Size(74, 13);
            this.lbl_Cladding.TabIndex = 44;
            this.lbl_Cladding.Text = "Cladding Qty";
            // 
            // FP_CladdingQtyPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nud_CladdingQty);
            this.Controls.Add(this.lbl_Cladding);
            this.Name = "FP_CladdingQtyPropertyUC";
            this.Size = new System.Drawing.Size(148, 28);
            this.Load += new System.EventHandler(this.FP_CladdingQtyPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_CladdingQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_CladdingQty;
        private System.Windows.Forms.Label lbl_Cladding;
    }
}
