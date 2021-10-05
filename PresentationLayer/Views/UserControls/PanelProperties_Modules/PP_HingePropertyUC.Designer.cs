namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_HingePropertyUC
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
            this.cmb_Hinge = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_2dHingeQtyNonMotorized = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_2dHingeQtyNonMotorized)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Hinge
            // 
            this.cmb_Hinge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Hinge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Hinge.DropDownWidth = 69;
            this.cmb_Hinge.FormattingEnabled = true;
            this.cmb_Hinge.Location = new System.Drawing.Point(73, 2);
            this.cmb_Hinge.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_Hinge.Name = "cmb_Hinge";
            this.cmb_Hinge.Size = new System.Drawing.Size(77, 21);
            this.cmb_Hinge.TabIndex = 35;
            this.cmb_Hinge.SelectedValueChanged += new System.EventHandler(this.cmb_Hinge_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Hinge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "2D Hinge Qty";
            // 
            // num_2dHingeQtyNonMotorized
            // 
            this.num_2dHingeQtyNonMotorized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_2dHingeQtyNonMotorized.Location = new System.Drawing.Point(73, 28);
            this.num_2dHingeQtyNonMotorized.Name = "num_2dHingeQtyNonMotorized";
            this.num_2dHingeQtyNonMotorized.Size = new System.Drawing.Size(77, 22);
            this.num_2dHingeQtyNonMotorized.TabIndex = 37;
            // 
            // PP_HingePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.num_2dHingeQtyNonMotorized);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Hinge);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_HingePropertyUC";
            this.Size = new System.Drawing.Size(152, 52);
            this.Load += new System.EventHandler(this.PP_HingePropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_2dHingeQtyNonMotorized)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Hinge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_2dHingeQtyNonMotorized;
    }
}
