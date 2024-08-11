namespace PresentationLayer.Views
{
    partial class ChangeItemColorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeItemColorView));
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_baseColor = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnl_WoodecAdditional = new System.Windows.Forms.Panel();
            this.nud_WoodecAdditional = new System.Windows.Forms.NumericUpDown();
            this.lbl_WoodecAdditional = new System.Windows.Forms.Label();
            this.cmb_ColorAppliedTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_InOutColor = new System.Windows.Forms.Panel();
            this.cmb_outsideColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_InsideColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_PowderCoatType = new System.Windows.Forms.Panel();
            this.cmb_PowderCoatType = new System.Windows.Forms.ComboBox();
            this.lbl_PowderCoatType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_WoodecAdditional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WoodecAdditional)).BeginInit();
            this.pnl_InOutColor.SuspendLayout();
            this.pnl_PowderCoatType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Color";
            // 
            // cmb_baseColor
            // 
            this.cmb_baseColor.CausesValidation = false;
            this.cmb_baseColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_baseColor.FormattingEnabled = true;
            this.cmb_baseColor.Location = new System.Drawing.Point(151, 43);
            this.cmb_baseColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_baseColor.Name = "cmb_baseColor";
            this.cmb_baseColor.Size = new System.Drawing.Size(125, 31);
            this.cmb_baseColor.TabIndex = 1;
            this.cmb_baseColor.SelectedValueChanged += new System.EventHandler(this.cmb_baseColor_SelectedValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(189, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnl_WoodecAdditional
            // 
            this.pnl_WoodecAdditional.Controls.Add(this.nud_WoodecAdditional);
            this.pnl_WoodecAdditional.Controls.Add(this.lbl_WoodecAdditional);
            this.pnl_WoodecAdditional.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_WoodecAdditional.Location = new System.Drawing.Point(0, 143);
            this.pnl_WoodecAdditional.Name = "pnl_WoodecAdditional";
            this.pnl_WoodecAdditional.Size = new System.Drawing.Size(278, 33);
            this.pnl_WoodecAdditional.TabIndex = 7;
            // 
            // nud_WoodecAdditional
            // 
            this.nud_WoodecAdditional.Location = new System.Drawing.Point(151, 4);
            this.nud_WoodecAdditional.Name = "nud_WoodecAdditional";
            this.nud_WoodecAdditional.Size = new System.Drawing.Size(125, 30);
            this.nud_WoodecAdditional.TabIndex = 7;
            this.nud_WoodecAdditional.ValueChanged += new System.EventHandler(this.nud_WoodecAdditional_ValueChanged);
            // 
            // lbl_WoodecAdditional
            // 
            this.lbl_WoodecAdditional.AutoSize = true;
            this.lbl_WoodecAdditional.Location = new System.Drawing.Point(8, 7);
            this.lbl_WoodecAdditional.Name = "lbl_WoodecAdditional";
            this.lbl_WoodecAdditional.Size = new System.Drawing.Size(135, 23);
            this.lbl_WoodecAdditional.TabIndex = 6;
            this.lbl_WoodecAdditional.Text = "Woodec Add’l %";
            this.lbl_WoodecAdditional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_ColorAppliedTo
            // 
            this.cmb_ColorAppliedTo.CausesValidation = false;
            this.cmb_ColorAppliedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ColorAppliedTo.FormattingEnabled = true;
            this.cmb_ColorAppliedTo.Location = new System.Drawing.Point(151, 12);
            this.cmb_ColorAppliedTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_ColorAppliedTo.Name = "cmb_ColorAppliedTo";
            this.cmb_ColorAppliedTo.Size = new System.Drawing.Size(125, 31);
            this.cmb_ColorAppliedTo.TabIndex = 9;
            this.cmb_ColorAppliedTo.SelectedValueChanged += new System.EventHandler(this.cmb_ColorAppliedTo_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Applied To";
            // 
            // pnl_InOutColor
            // 
            this.pnl_InOutColor.Controls.Add(this.cmb_outsideColor);
            this.pnl_InOutColor.Controls.Add(this.label3);
            this.pnl_InOutColor.Controls.Add(this.cmb_InsideColor);
            this.pnl_InOutColor.Controls.Add(this.label2);
            this.pnl_InOutColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_InOutColor.Location = new System.Drawing.Point(0, 75);
            this.pnl_InOutColor.Name = "pnl_InOutColor";
            this.pnl_InOutColor.Size = new System.Drawing.Size(278, 68);
            this.pnl_InOutColor.TabIndex = 10;
            // 
            // cmb_outsideColor
            // 
            this.cmb_outsideColor.CausesValidation = false;
            this.cmb_outsideColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_outsideColor.FormattingEnabled = true;
            this.cmb_outsideColor.Location = new System.Drawing.Point(151, 35);
            this.cmb_outsideColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_outsideColor.Name = "cmb_outsideColor";
            this.cmb_outsideColor.Size = new System.Drawing.Size(125, 31);
            this.cmb_outsideColor.TabIndex = 9;
            this.cmb_outsideColor.SelectedValueChanged += new System.EventHandler(this.cmb_outsideColor_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ouside Color";
            // 
            // cmb_InsideColor
            // 
            this.cmb_InsideColor.CausesValidation = false;
            this.cmb_InsideColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_InsideColor.FormattingEnabled = true;
            this.cmb_InsideColor.Location = new System.Drawing.Point(151, 2);
            this.cmb_InsideColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_InsideColor.Name = "cmb_InsideColor";
            this.cmb_InsideColor.Size = new System.Drawing.Size(125, 31);
            this.cmb_InsideColor.TabIndex = 7;
            this.cmb_InsideColor.SelectedValueChanged += new System.EventHandler(this.cmb_InsideColor_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Inside Color";
            // 
            // pnl_PowderCoatType
            // 
            this.pnl_PowderCoatType.Controls.Add(this.cmb_PowderCoatType);
            this.pnl_PowderCoatType.Controls.Add(this.lbl_PowderCoatType);
            this.pnl_PowderCoatType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_PowderCoatType.Location = new System.Drawing.Point(0, 176);
            this.pnl_PowderCoatType.Name = "pnl_PowderCoatType";
            this.pnl_PowderCoatType.Size = new System.Drawing.Size(278, 33);
            this.pnl_PowderCoatType.TabIndex = 11;
            // 
            // cmb_PowderCoatType
            // 
            this.cmb_PowderCoatType.CausesValidation = false;
            this.cmb_PowderCoatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PowderCoatType.FormattingEnabled = true;
            this.cmb_PowderCoatType.Location = new System.Drawing.Point(151, 1);
            this.cmb_PowderCoatType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_PowderCoatType.Name = "cmb_PowderCoatType";
            this.cmb_PowderCoatType.Size = new System.Drawing.Size(121, 31);
            this.cmb_PowderCoatType.TabIndex = 3;
            this.cmb_PowderCoatType.SelectedValueChanged += new System.EventHandler(this.cmb_PowderCoatType_SelectedValueChanged);
            // 
            // lbl_PowderCoatType
            // 
            this.lbl_PowderCoatType.AutoSize = true;
            this.lbl_PowderCoatType.Location = new System.Drawing.Point(4, 4);
            this.lbl_PowderCoatType.Name = "lbl_PowderCoatType";
            this.lbl_PowderCoatType.Size = new System.Drawing.Size(147, 23);
            this.lbl_PowderCoatType.TabIndex = 2;
            this.lbl_PowderCoatType.Text = "Powder Coat Type";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_baseColor);
            this.panel1.Controls.Add(this.cmb_ColorAppliedTo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 75);
            this.panel1.TabIndex = 12;
            // 
            // ChangeItemColorView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 258);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnl_PowderCoatType);
            this.Controls.Add(this.pnl_WoodecAdditional);
            this.Controls.Add(this.pnl_InOutColor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeItemColorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Item Color";
            this.Load += new System.EventHandler(this.ChangeItemColorView_Load);
            this.pnl_WoodecAdditional.ResumeLayout(false);
            this.pnl_WoodecAdditional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WoodecAdditional)).EndInit();
            this.pnl_InOutColor.ResumeLayout(false);
            this.pnl_InOutColor.PerformLayout();
            this.pnl_PowderCoatType.ResumeLayout(false);
            this.pnl_PowderCoatType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_baseColor;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnl_WoodecAdditional;
        private System.Windows.Forms.NumericUpDown nud_WoodecAdditional;
        private System.Windows.Forms.Label lbl_WoodecAdditional;
        private System.Windows.Forms.ComboBox cmb_ColorAppliedTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_InOutColor;
        private System.Windows.Forms.ComboBox cmb_outsideColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_InsideColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_PowderCoatType;
        private System.Windows.Forms.ComboBox cmb_PowderCoatType;
        private System.Windows.Forms.Label lbl_PowderCoatType;
        private System.Windows.Forms.Panel panel1;
    }
}