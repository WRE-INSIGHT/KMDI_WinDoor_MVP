namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_3dHingePropertyUC
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
            this.num_3dHingeQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_3dHingeQty)).BeginInit();
            this.SuspendLayout();
            // 
            // num_3dHingeQty
            // 
            this.num_3dHingeQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_3dHingeQty.Location = new System.Drawing.Point(74, 4);
            this.num_3dHingeQty.Name = "num_3dHingeQty";
            this.num_3dHingeQty.Size = new System.Drawing.Size(77, 20);
            this.num_3dHingeQty.TabIndex = 39;
            this.num_3dHingeQty.ValueChanged += new System.EventHandler(this.num_3dHingeQty_ValueChanged);
            this.num_3dHingeQty.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.num_3dHingeQty_MouseWheel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "3D Hinge Qty";
            // 
            // PP_3dHingePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.num_3dHingeQty);
            this.Controls.Add(this.label2);
            this.Name = "PP_3dHingePropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_3dHingePropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_3dHingeQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_3dHingeQty;
        private System.Windows.Forms.Label label2;
    }
}
