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
            this.pnl_divArtNo = new System.Windows.Forms.Panel();
            this.cmb_divReinf = new System.Windows.Forms.ComboBox();
            this.lbl_divReinf = new System.Windows.Forms.Label();
            this.cmb_divArtNo = new System.Windows.Forms.ComboBox();
            this.lbl_divArtNo = new System.Windows.Forms.Label();
            this.lbl_divSpecs = new System.Windows.Forms.Label();
            this.pnl_dividerBody = new System.Windows.Forms.Panel();
            this.pnl_AddCladding = new System.Windows.Forms.Panel();
            this.btn_AddCladding = new System.Windows.Forms.Button();
            this.pnl_divName = new System.Windows.Forms.Panel();
            this.pnl_divWd = new System.Windows.Forms.Panel();
            this.pnl_divHt = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_divHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_divWidth)).BeginInit();
            this.pnl_divArtNo.SuspendLayout();
            this.pnl_dividerBody.SuspendLayout();
            this.pnl_AddCladding.SuspendLayout();
            this.pnl_divName.SuspendLayout();
            this.pnl_divWd.SuspendLayout();
            this.pnl_divHt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_divname
            // 
            this.lbl_divname.AutoSize = true;
            this.lbl_divname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_divname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divname.Location = new System.Drawing.Point(5, 5);
            this.lbl_divname.Name = "lbl_divname";
            this.lbl_divname.Size = new System.Drawing.Size(68, 21);
            this.lbl_divname.TabIndex = 1;
            this.lbl_divname.Text = "Divider 1";
            // 
            // num_divHeight
            // 
            this.num_divHeight.BackColor = System.Drawing.Color.White;
            this.num_divHeight.Enabled = false;
            this.num_divHeight.Location = new System.Drawing.Point(6, 17);
            this.num_divHeight.Name = "num_divHeight";
            this.num_divHeight.ReadOnly = true;
            this.num_divHeight.Size = new System.Drawing.Size(135, 20);
            this.num_divHeight.TabIndex = 11;
            // 
            // lbl_Height
            // 
            this.lbl_Height.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(2, 2);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(150, 13);
            this.lbl_Height.TabIndex = 10;
            this.lbl_Height.Text = "Height";
            // 
            // num_divWidth
            // 
            this.num_divWidth.BackColor = System.Drawing.Color.White;
            this.num_divWidth.Enabled = false;
            this.num_divWidth.Location = new System.Drawing.Point(6, 17);
            this.num_divWidth.Name = "num_divWidth";
            this.num_divWidth.ReadOnly = true;
            this.num_divWidth.Size = new System.Drawing.Size(135, 20);
            this.num_divWidth.TabIndex = 9;
            // 
            // lbl_Width
            // 
            this.lbl_Width.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Width.Location = new System.Drawing.Point(2, 2);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(150, 13);
            this.lbl_Width.TabIndex = 8;
            this.lbl_Width.Text = "Width";
            // 
            // pnl_divArtNo
            // 
            this.pnl_divArtNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_divArtNo.Controls.Add(this.cmb_divReinf);
            this.pnl_divArtNo.Controls.Add(this.lbl_divReinf);
            this.pnl_divArtNo.Controls.Add(this.cmb_divArtNo);
            this.pnl_divArtNo.Controls.Add(this.lbl_divArtNo);
            this.pnl_divArtNo.Controls.Add(this.lbl_divSpecs);
            this.pnl_divArtNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_divArtNo.Location = new System.Drawing.Point(0, 0);
            this.pnl_divArtNo.Name = "pnl_divArtNo";
            this.pnl_divArtNo.Size = new System.Drawing.Size(158, 90);
            this.pnl_divArtNo.TabIndex = 12;
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
            this.cmb_divReinf.Location = new System.Drawing.Point(67, 56);
            this.cmb_divReinf.Name = "cmb_divReinf";
            this.cmb_divReinf.Size = new System.Drawing.Size(87, 21);
            this.cmb_divReinf.TabIndex = 11;
            // 
            // lbl_divReinf
            // 
            this.lbl_divReinf.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divReinf.Location = new System.Drawing.Point(6, 56);
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
            this.cmb_divArtNo.Location = new System.Drawing.Point(67, 22);
            this.cmb_divArtNo.Name = "cmb_divArtNo";
            this.cmb_divArtNo.Size = new System.Drawing.Size(87, 21);
            this.cmb_divArtNo.TabIndex = 9;
            this.cmb_divArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_divArtNo_SelectedValueChanged);
            // 
            // lbl_divArtNo
            // 
            this.lbl_divArtNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_divArtNo.Location = new System.Drawing.Point(7, 22);
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
            // pnl_dividerBody
            // 
            this.pnl_dividerBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_dividerBody.Controls.Add(this.pnl_AddCladding);
            this.pnl_dividerBody.Controls.Add(this.pnl_divArtNo);
            this.pnl_dividerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_dividerBody.Location = new System.Drawing.Point(0, 108);
            this.pnl_dividerBody.Name = "pnl_dividerBody";
            this.pnl_dividerBody.Size = new System.Drawing.Size(160, 120);
            this.pnl_dividerBody.TabIndex = 13;
            // 
            // pnl_AddCladding
            // 
            this.pnl_AddCladding.Controls.Add(this.btn_Save);
            this.pnl_AddCladding.Controls.Add(this.btn_AddCladding);
            this.pnl_AddCladding.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_AddCladding.Location = new System.Drawing.Point(0, 90);
            this.pnl_AddCladding.Name = "pnl_AddCladding";
            this.pnl_AddCladding.Size = new System.Drawing.Size(158, 27);
            this.pnl_AddCladding.TabIndex = 13;
            // 
            // btn_AddCladding
            // 
            this.btn_AddCladding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddCladding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddCladding.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_AddCladding.Location = new System.Drawing.Point(3, 2);
            this.btn_AddCladding.Name = "btn_AddCladding";
            this.btn_AddCladding.Size = new System.Drawing.Size(90, 23);
            this.btn_AddCladding.TabIndex = 0;
            this.btn_AddCladding.Text = "Add cladding";
            this.btn_AddCladding.UseVisualStyleBackColor = true;
            this.btn_AddCladding.Click += new System.EventHandler(this.btn_AddCladding_Click);
            // 
            // pnl_divName
            // 
            this.pnl_divName.Controls.Add(this.lbl_divname);
            this.pnl_divName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_divName.Location = new System.Drawing.Point(0, 0);
            this.pnl_divName.Name = "pnl_divName";
            this.pnl_divName.Size = new System.Drawing.Size(160, 28);
            this.pnl_divName.TabIndex = 14;
            // 
            // pnl_divWd
            // 
            this.pnl_divWd.Controls.Add(this.lbl_Width);
            this.pnl_divWd.Controls.Add(this.num_divWidth);
            this.pnl_divWd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_divWd.Location = new System.Drawing.Point(0, 28);
            this.pnl_divWd.Name = "pnl_divWd";
            this.pnl_divWd.Size = new System.Drawing.Size(160, 40);
            this.pnl_divWd.TabIndex = 15;
            // 
            // pnl_divHt
            // 
            this.pnl_divHt.Controls.Add(this.lbl_Height);
            this.pnl_divHt.Controls.Add(this.num_divHeight);
            this.pnl_divHt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_divHt.Location = new System.Drawing.Point(0, 68);
            this.pnl_divHt.Name = "pnl_divHt";
            this.pnl_divHt.Size = new System.Drawing.Size(160, 40);
            this.pnl_divHt.TabIndex = 16;
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Save.Location = new System.Drawing.Point(101, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(54, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // DividerPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_dividerBody);
            this.Controls.Add(this.pnl_divHt);
            this.Controls.Add(this.pnl_divWd);
            this.Controls.Add(this.pnl_divName);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DividerPropertiesUC";
            this.Size = new System.Drawing.Size(160, 228);
            this.Load += new System.EventHandler(this.DividerPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_divHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_divWidth)).EndInit();
            this.pnl_divArtNo.ResumeLayout(false);
            this.pnl_divArtNo.PerformLayout();
            this.pnl_dividerBody.ResumeLayout(false);
            this.pnl_AddCladding.ResumeLayout(false);
            this.pnl_divName.ResumeLayout(false);
            this.pnl_divName.PerformLayout();
            this.pnl_divWd.ResumeLayout(false);
            this.pnl_divHt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_divname;
        private System.Windows.Forms.NumericUpDown num_divHeight;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_divWidth;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.Panel pnl_divArtNo;
        private System.Windows.Forms.ComboBox cmb_divReinf;
        private System.Windows.Forms.Label lbl_divReinf;
        private System.Windows.Forms.ComboBox cmb_divArtNo;
        private System.Windows.Forms.Label lbl_divArtNo;
        private System.Windows.Forms.Label lbl_divSpecs;
        private System.Windows.Forms.Panel pnl_dividerBody;
        private System.Windows.Forms.Panel pnl_divName;
        private System.Windows.Forms.Panel pnl_divWd;
        private System.Windows.Forms.Panel pnl_divHt;
        private System.Windows.Forms.Panel pnl_AddCladding;
        private System.Windows.Forms.Button btn_AddCladding;
        private System.Windows.Forms.Button btn_Save;
    }
}
