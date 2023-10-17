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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_BaseColorOption = new System.Windows.Forms.ComboBox();
            this.cmb_SystemOption = new System.Windows.Forms.ComboBox();
            this.pnl_FrameQty = new System.Windows.Forms.Panel();
            this.lbl_FrameQty = new System.Windows.Forms.Label();
            this.nud_FrameQty = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_FrameQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FrameQty)).BeginInit();
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
            this.numWidth.Enter += new System.EventHandler(this.numWidth_Enter);
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
            this.numHeight.Enter += new System.EventHandler(this.numHeight_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.numWidth);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numHeight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 100);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_BaseColorOption);
            this.panel2.Controls.Add(this.cmb_SystemOption);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 65);
            this.panel2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Base Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "System Type";
            // 
            // cmb_BaseColorOption
            // 
            this.cmb_BaseColorOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BaseColorOption.FormattingEnabled = true;
            this.cmb_BaseColorOption.Location = new System.Drawing.Point(87, 34);
            this.cmb_BaseColorOption.Name = "cmb_BaseColorOption";
            this.cmb_BaseColorOption.Size = new System.Drawing.Size(80, 25);
            this.cmb_BaseColorOption.TabIndex = 3;
            this.cmb_BaseColorOption.SelectedValueChanged += new System.EventHandler(this.cmb_BaseColorOption_SelectedValueChanged);
            // 
            // cmb_SystemOption
            // 
            this.cmb_SystemOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SystemOption.FormattingEnabled = true;
            this.cmb_SystemOption.Location = new System.Drawing.Point(88, 3);
            this.cmb_SystemOption.Name = "cmb_SystemOption";
            this.cmb_SystemOption.Size = new System.Drawing.Size(80, 25);
            this.cmb_SystemOption.TabIndex = 2;
            this.cmb_SystemOption.SelectedValueChanged += new System.EventHandler(this.cmb_SystemOption_SelectedValueChanged);
            // 
            // pnl_FrameQty
            // 
            this.pnl_FrameQty.Controls.Add(this.lbl_FrameQty);
            this.pnl_FrameQty.Controls.Add(this.nud_FrameQty);
            this.pnl_FrameQty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_FrameQty.Location = new System.Drawing.Point(0, 67);
            this.pnl_FrameQty.Name = "pnl_FrameQty";
            this.pnl_FrameQty.Size = new System.Drawing.Size(172, 32);
            this.pnl_FrameQty.TabIndex = 10;
            // 
            // lbl_FrameQty
            // 
            this.lbl_FrameQty.AutoSize = true;
            this.lbl_FrameQty.Location = new System.Drawing.Point(4, 5);
            this.lbl_FrameQty.Name = "lbl_FrameQty";
            this.lbl_FrameQty.Size = new System.Drawing.Size(77, 19);
            this.lbl_FrameQty.TabIndex = 2;
            this.lbl_FrameQty.Text = "Frame Qty:";
            // 
            // nud_FrameQty
            // 
            this.nud_FrameQty.Location = new System.Drawing.Point(87, 2);
            this.nud_FrameQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_FrameQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_FrameQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FrameQty.Name = "nud_FrameQty";
            this.nud_FrameQty.Size = new System.Drawing.Size(81, 25);
            this.nud_FrameQty.TabIndex = 3;
            this.nud_FrameQty.ThousandsSeparator = true;
            this.nud_FrameQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FrameQty.ValueChanged += new System.EventHandler(this.nud_FrameQty_ValueChanged);
            // 
            // frmDimensionView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(172, 199);
            this.Controls.Add(this.pnl_FrameQty);
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
            this.pnl_FrameQty.ResumeLayout(false);
            this.pnl_FrameQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FrameQty)).EndInit();
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
        private System.Windows.Forms.ComboBox cmb_SystemOption;
        private System.Windows.Forms.ComboBox cmb_BaseColorOption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_FrameQty;
        private System.Windows.Forms.Label lbl_FrameQty;
        public System.Windows.Forms.NumericUpDown nud_FrameQty;
    }
}