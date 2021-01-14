namespace PresentationLayer.Views
{
    partial class frmDimensionView
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rad_PremiLine = new System.Windows.Forms.RadioButton();
            this.rad_c70 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width (mm)";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(91, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(88, 3);
            this.numWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(81, 25);
            this.numWidth.TabIndex = 1;
            this.numWidth.ThousandsSeparator = true;
            this.numWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(5, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height (mm)";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(88, 36);
            this.numHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(81, 25);
            this.numHeight.TabIndex = 3;
            this.numHeight.ThousandsSeparator = true;
            this.numHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.numWidth);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numHeight);
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 100);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rad_PremiLine);
            this.panel2.Controls.Add(this.rad_c70);
            this.panel2.Location = new System.Drawing.Point(6, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 30);
            this.panel2.TabIndex = 9;
            // 
            // rad_PremiLine
            // 
            this.rad_PremiLine.AutoSize = true;
            this.rad_PremiLine.Location = new System.Drawing.Point(77, 3);
            this.rad_PremiLine.Name = "rad_PremiLine";
            this.rad_PremiLine.Size = new System.Drawing.Size(87, 23);
            this.rad_PremiLine.TabIndex = 1;
            this.rad_PremiLine.TabStop = true;
            this.rad_PremiLine.Text = "PremiLine";
            this.rad_PremiLine.UseVisualStyleBackColor = true;
            this.rad_PremiLine.CheckedChanged += new System.EventHandler(this.radbtn_CheckedChanged);
            // 
            // rad_c70
            // 
            this.rad_c70.AutoSize = true;
            this.rad_c70.Checked = true;
            this.rad_c70.Location = new System.Drawing.Point(12, 3);
            this.rad_c70.Name = "rad_c70";
            this.rad_c70.Size = new System.Drawing.Size(52, 23);
            this.rad_c70.TabIndex = 0;
            this.rad_c70.TabStop = true;
            this.rad_c70.Text = "C70";
            this.rad_c70.UseVisualStyleBackColor = true;
            this.rad_c70.CheckedChanged += new System.EventHandler(this.radbtn_CheckedChanged);
            // 
            // frmDimensionView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(184, 152);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDimensionView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dimensions";
            this.Load += new System.EventHandler(this.frmDimensionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RadioButton rad_PremiLine;
        public System.Windows.Forms.RadioButton rad_c70;
    }
}