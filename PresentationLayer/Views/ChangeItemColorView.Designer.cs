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
            this.cmb_InsideColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_outsideColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Color";
            // 
            // cmb_baseColor
            // 
            this.cmb_baseColor.CausesValidation = false;
            this.cmb_baseColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_baseColor.FormattingEnabled = true;
            this.cmb_baseColor.Location = new System.Drawing.Point(107, 22);
            this.cmb_baseColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_baseColor.Name = "cmb_baseColor";
            this.cmb_baseColor.Size = new System.Drawing.Size(125, 25);
            this.cmb_baseColor.TabIndex = 1;
            this.cmb_baseColor.SelectedValueChanged += new System.EventHandler(this.cmb_baseColor_SelectedValueChanged);
            // 
            // cmb_InsideColor
            // 
            this.cmb_InsideColor.CausesValidation = false;
            this.cmb_InsideColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_InsideColor.FormattingEnabled = true;
            this.cmb_InsideColor.Location = new System.Drawing.Point(107, 55);
            this.cmb_InsideColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_InsideColor.Name = "cmb_InsideColor";
            this.cmb_InsideColor.Size = new System.Drawing.Size(125, 25);
            this.cmb_InsideColor.TabIndex = 3;
            this.cmb_InsideColor.SelectedValueChanged += new System.EventHandler(this.cmb_InsideColor_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inside Color";
            // 
            // cmb_outsideColor
            // 
            this.cmb_outsideColor.CausesValidation = false;
            this.cmb_outsideColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_outsideColor.FormattingEnabled = true;
            this.cmb_outsideColor.Location = new System.Drawing.Point(107, 88);
            this.cmb_outsideColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_outsideColor.Name = "cmb_outsideColor";
            this.cmb_outsideColor.Size = new System.Drawing.Size(125, 25);
            this.cmb_outsideColor.TabIndex = 5;
            this.cmb_outsideColor.SelectedValueChanged += new System.EventHandler(this.cmb_outsideColor_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ouside Color";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(157, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ChangeItemColorView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 156);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmb_outsideColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_InsideColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_baseColor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeItemColorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Item Color";
            this.Load += new System.EventHandler(this.ChangeItemColorView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_baseColor;
        private System.Windows.Forms.ComboBox cmb_InsideColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_outsideColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
    }
}