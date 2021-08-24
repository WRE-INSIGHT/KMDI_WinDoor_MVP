namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    partial class DP_CladdingBracketPropertyUC
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
            this.label3 = new System.Windows.Forms.Label();
            this.nudBracketForConcrete = new System.Windows.Forms.NumericUpDown();
            this.nudBracketForUPVC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBracketForConcrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBracketForUPVC)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Brackets";
            // 
            // nudBracketForConcrete
            // 
            this.nudBracketForConcrete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBracketForConcrete.Location = new System.Drawing.Point(68, 48);
            this.nudBracketForConcrete.Name = "nudBracketForConcrete";
            this.nudBracketForConcrete.Size = new System.Drawing.Size(85, 22);
            this.nudBracketForConcrete.TabIndex = 29;
            this.nudBracketForConcrete.ValueChanged += new System.EventHandler(this.nudBracketForConcrete_ValueChanged);
            // 
            // nudBracketForUPVC
            // 
            this.nudBracketForUPVC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBracketForUPVC.Location = new System.Drawing.Point(68, 19);
            this.nudBracketForUPVC.Name = "nudBracketForUPVC";
            this.nudBracketForUPVC.Size = new System.Drawing.Size(85, 22);
            this.nudBracketForUPVC.TabIndex = 28;
            this.nudBracketForUPVC.ValueChanged += new System.EventHandler(this.nudBracketForUPVC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "For UPVC";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(-1, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "For Concrete";
            // 
            // DP_CladdingBracketPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudBracketForConcrete);
            this.Controls.Add(this.nudBracketForUPVC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DP_CladdingBracketPropertyUC";
            this.Size = new System.Drawing.Size(150, 72);
            this.Load += new System.EventHandler(this.DP_CladdingBracketPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBracketForConcrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBracketForUPVC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBracketForConcrete;
        private System.Windows.Forms.NumericUpDown nudBracketForUPVC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
