namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_2dHingePropertyUC
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
            this.num_2dHingeQtyNonMotorized = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_2dHingeQtyNonMotorized)).BeginInit();
            this.SuspendLayout();
            // 
            // num_2dHingeQtyNonMotorized
            // 
            this.num_2dHingeQtyNonMotorized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_2dHingeQtyNonMotorized.Location = new System.Drawing.Point(75, 4);
            this.num_2dHingeQtyNonMotorized.Name = "num_2dHingeQtyNonMotorized";
            this.num_2dHingeQtyNonMotorized.Size = new System.Drawing.Size(75, 20);
            this.num_2dHingeQtyNonMotorized.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "2D Hinge Qty";
            // 
            // PP_2dHingePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.num_2dHingeQtyNonMotorized);
            this.Controls.Add(this.label2);
            this.Name = "PP_2dHingePropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_2dHingePropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_2dHingeQtyNonMotorized)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_2dHingeQtyNonMotorized;
        private System.Windows.Forms.Label label2;
    }
}
