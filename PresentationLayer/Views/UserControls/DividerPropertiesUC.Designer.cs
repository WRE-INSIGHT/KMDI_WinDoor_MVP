namespace PresentationLayer.Views.UserControls
{
    partial class DividerPropertiesUC
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
            this.lbl_divname = new System.Windows.Forms.Label();
            this.num_divHeight = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_divWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_divReinf = new System.Windows.Forms.ComboBox();
            this.lbl_divReinf = new System.Windows.Forms.Label();
            this.cmb_divArtNo = new System.Windows.Forms.ComboBox();
            this.lbl_divArtNo = new System.Windows.Forms.Label();
            this.lbl_divSpecs = new System.Windows.Forms.Label();
            this.flp_divProp = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.num_divHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_divWidth)).BeginInit();
            this.panel1.SuspendLayout();
            this.flp_divProp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_divname
            // 
            this.lbl_divname.AutoSize = true;
            this.lbl_divname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_divname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divname.Location = new System.Drawing.Point(6, 5);
            this.lbl_divname.Name = "lbl_divname";
            this.lbl_divname.Size = new System.Drawing.Size(68, 21);
            this.lbl_divname.TabIndex = 1;
            this.lbl_divname.Text = "Divider 1";
            // 
            // num_divHeight
            // 
            this.num_divHeight.BackColor = System.Drawing.Color.White;
            this.num_divHeight.Enabled = false;
            this.num_divHeight.Location = new System.Drawing.Point(6, 81);
            this.num_divHeight.Name = "num_divHeight";
            this.num_divHeight.ReadOnly = true;
            this.num_divHeight.Size = new System.Drawing.Size(135, 20);
            this.num_divHeight.TabIndex = 11;
            // 
            // lbl_Height
            // 
            this.lbl_Height.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(6, 65);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(150, 13);
            this.lbl_Height.TabIndex = 10;
            this.lbl_Height.Text = "Height";
            // 
            // num_divWidth
            // 
            this.num_divWidth.BackColor = System.Drawing.Color.White;
            this.num_divWidth.Enabled = false;
            this.num_divWidth.Location = new System.Drawing.Point(6, 42);
            this.num_divWidth.Name = "num_divWidth";
            this.num_divWidth.ReadOnly = true;
            this.num_divWidth.Size = new System.Drawing.Size(135, 20);
            this.num_divWidth.TabIndex = 9;
            // 
            // lbl_Width
            // 
            this.lbl_Width.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Width.Location = new System.Drawing.Point(6, 26);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(150, 13);
            this.lbl_Width.TabIndex = 8;
            this.lbl_Width.Text = "Width";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_divReinf);
            this.panel1.Controls.Add(this.lbl_divReinf);
            this.panel1.Controls.Add(this.cmb_divArtNo);
            this.panel1.Controls.Add(this.lbl_divArtNo);
            this.panel1.Controls.Add(this.lbl_divSpecs);
            this.panel1.Location = new System.Drawing.Point(6, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 94);
            this.panel1.TabIndex = 12;
            // 
            // cmb_divReinf
            // 
            this.cmb_divReinf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_divReinf.FormattingEnabled = true;
            this.cmb_divReinf.Items.AddRange(new object[] {
            "6-8mm",
            "10mm",
            "10.76-14mm",
            "16mm",
            "18mm",
            "20mm",
            "22mm",
            "25mm"});
            this.cmb_divReinf.Location = new System.Drawing.Point(65, 56);
            this.cmb_divReinf.Name = "cmb_divReinf";
            this.cmb_divReinf.Size = new System.Drawing.Size(72, 21);
            this.cmb_divReinf.TabIndex = 11;
            // 
            // lbl_divReinf
            // 
            this.lbl_divReinf.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divReinf.Location = new System.Drawing.Point(4, 56);
            this.lbl_divReinf.Name = "lbl_divReinf";
            this.lbl_divReinf.Size = new System.Drawing.Size(55, 31);
            this.lbl_divReinf.TabIndex = 10;
            this.lbl_divReinf.Text = "Mullion Reinf";
            // 
            // cmb_divArtNo
            // 
            this.cmb_divArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_divArtNo.FormattingEnabled = true;
            this.cmb_divArtNo.Items.AddRange(new object[] {
            "6-8mm",
            "10mm",
            "10.76-14mm",
            "16mm",
            "18mm",
            "20mm",
            "22mm",
            "25mm"});
            this.cmb_divArtNo.Location = new System.Drawing.Point(65, 22);
            this.cmb_divArtNo.Name = "cmb_divArtNo";
            this.cmb_divArtNo.Size = new System.Drawing.Size(72, 21);
            this.cmb_divArtNo.TabIndex = 9;
            this.cmb_divArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_divArtNo_SelectedValueChanged);
            // 
            // lbl_divArtNo
            // 
            this.lbl_divArtNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divArtNo.Location = new System.Drawing.Point(5, 22);
            this.lbl_divArtNo.Name = "lbl_divArtNo";
            this.lbl_divArtNo.Size = new System.Drawing.Size(52, 28);
            this.lbl_divArtNo.TabIndex = 8;
            this.lbl_divArtNo.Text = "Mullion Art No";
            // 
            // lbl_divSpecs
            // 
            this.lbl_divSpecs.AutoSize = true;
            this.lbl_divSpecs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divSpecs.Location = new System.Drawing.Point(-1, 4);
            this.lbl_divSpecs.Name = "lbl_divSpecs";
            this.lbl_divSpecs.Size = new System.Drawing.Size(66, 15);
            this.lbl_divSpecs.TabIndex = 7;
            this.lbl_divSpecs.Text = "Article No.";
            // 
            // flp_divProp
            // 
            this.flp_divProp.BackColor = System.Drawing.Color.White;
            this.flp_divProp.Controls.Add(this.lbl_divname);
            this.flp_divProp.Controls.Add(this.lbl_Width);
            this.flp_divProp.Controls.Add(this.num_divWidth);
            this.flp_divProp.Controls.Add(this.lbl_Height);
            this.flp_divProp.Controls.Add(this.num_divHeight);
            this.flp_divProp.Controls.Add(this.panel1);
            this.flp_divProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_divProp.Location = new System.Drawing.Point(0, 0);
            this.flp_divProp.Name = "flp_divProp";
            this.flp_divProp.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.flp_divProp.Size = new System.Drawing.Size(157, 173);
            this.flp_divProp.TabIndex = 13;
            // 
            // DividerPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flp_divProp);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DividerPropertiesUC";
            this.Size = new System.Drawing.Size(157, 173);
            this.Load += new System.EventHandler(this.DividerPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_divHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_divWidth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flp_divProp.ResumeLayout(false);
            this.flp_divProp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_divname;
        private System.Windows.Forms.NumericUpDown num_divHeight;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_divWidth;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_divReinf;
        private System.Windows.Forms.Label lbl_divReinf;
        private System.Windows.Forms.ComboBox cmb_divArtNo;
        private System.Windows.Forms.Label lbl_divArtNo;
        private System.Windows.Forms.Label lbl_divSpecs;
        private System.Windows.Forms.FlowLayoutPanel flp_divProp;
    }
}
