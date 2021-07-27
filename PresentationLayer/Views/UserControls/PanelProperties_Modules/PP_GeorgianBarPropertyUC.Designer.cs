namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_GeorgianBarPropertyUC
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
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGBArtNum = new System.Windows.Forms.ComboBox();
            this.nudHorizontal = new System.Windows.Forms.NumericUpDown();
            this.nudVertical = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Article No.";
            // 
            // cmbGBArtNum
            // 
            this.cmbGBArtNum.Items.AddRange(new object[] {
            "0724",
            "0726"});
            this.cmbGBArtNum.Location = new System.Drawing.Point(115, 18);
            this.cmbGBArtNum.Name = "cmbGBArtNum";
            this.cmbGBArtNum.Size = new System.Drawing.Size(59, 23);
            this.cmbGBArtNum.TabIndex = 18;
            // 
            // nudHorizontal
            // 
            this.nudHorizontal.Location = new System.Drawing.Point(115, 66);
            this.nudHorizontal.Name = "nudHorizontal";
            this.nudHorizontal.Size = new System.Drawing.Size(59, 23);
            this.nudHorizontal.TabIndex = 17;
            this.nudHorizontal.ValueChanged += new System.EventHandler(this.nudHorizontal_ValueChanged);
            // 
            // nudVertical
            // 
            this.nudVertical.Location = new System.Drawing.Point(115, 42);
            this.nudVertical.Name = "nudVertical";
            this.nudVertical.Size = new System.Drawing.Size(59, 23);
            this.nudVertical.TabIndex = 16;
            this.nudVertical.ValueChanged += new System.EventHandler(this.nudVertical_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Vertical Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Horizontal Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Georgian Bar";
            // 
            // PP_GeorgianBarPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbGBArtNum);
            this.Controls.Add(this.nudHorizontal);
            this.Controls.Add(this.nudVertical);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PP_GeorgianBarPropertyUC";
            this.Size = new System.Drawing.Size(180, 93);
            this.Load += new System.EventHandler(this.PP_GeorgianBarPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGBArtNum;
        private System.Windows.Forms.NumericUpDown nudHorizontal;
        private System.Windows.Forms.NumericUpDown nudVertical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
