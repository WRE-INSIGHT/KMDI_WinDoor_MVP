namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_GlassPropertyUC
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_GlassType = new System.Windows.Forms.ComboBox();
            this.lbl_glassthick = new System.Windows.Forms.Label();
            this.btn_SelectGlassthickness = new System.Windows.Forms.Button();
            this.lbl_GlassThicknessDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_GlazingArtNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_FilmType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Glass Type";
            // 
            // cmb_GlassType
            // 
            this.cmb_GlassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlassType.DropDownWidth = 100;
            this.cmb_GlassType.FormattingEnabled = true;
            this.cmb_GlassType.Location = new System.Drawing.Point(76, 3);
            this.cmb_GlassType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_GlassType.Name = "cmb_GlassType";
            this.cmb_GlassType.Size = new System.Drawing.Size(72, 21);
            this.cmb_GlassType.TabIndex = 32;
            this.cmb_GlassType.SelectedValueChanged += new System.EventHandler(this.cmb_GlassType_SelectedValueChanged);
            // 
            // lbl_glassthick
            // 
            this.lbl_glassthick.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_glassthick.Location = new System.Drawing.Point(2, 30);
            this.lbl_glassthick.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_glassthick.Name = "lbl_glassthick";
            this.lbl_glassthick.Size = new System.Drawing.Size(66, 13);
            this.lbl_glassthick.TabIndex = 26;
            this.lbl_glassthick.Text = "Glass Thick";
            // 
            // btn_SelectGlassthickness
            // 
            this.btn_SelectGlassthickness.Location = new System.Drawing.Point(74, 27);
            this.btn_SelectGlassthickness.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_SelectGlassthickness.Name = "btn_SelectGlassthickness";
            this.btn_SelectGlassthickness.Size = new System.Drawing.Size(74, 23);
            this.btn_SelectGlassthickness.TabIndex = 33;
            this.btn_SelectGlassthickness.Text = "select";
            this.btn_SelectGlassthickness.UseVisualStyleBackColor = true;
            this.btn_SelectGlassthickness.Click += new System.EventHandler(this.btn_SelectGlassthickness_Click);
            // 
            // lbl_GlassThicknessDesc
            // 
            this.lbl_GlassThicknessDesc.AutoEllipsis = true;
            this.lbl_GlassThicknessDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GlassThicknessDesc.Location = new System.Drawing.Point(2, 56);
            this.lbl_GlassThicknessDesc.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_GlassThicknessDesc.Name = "lbl_GlassThicknessDesc";
            this.lbl_GlassThicknessDesc.Size = new System.Drawing.Size(138, 13);
            this.lbl_GlassThicknessDesc.TabIndex = 34;
            this.lbl_GlassThicknessDesc.Text = "Glass thickness";
            this.lbl_GlassThicknessDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Glazing Art.No";
            // 
            // cmb_GlazingArtNo
            // 
            this.cmb_GlazingArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlazingArtNo.FormattingEnabled = true;
            this.cmb_GlazingArtNo.Items.AddRange(new object[] {
            "6-8mm",
            "10mm",
            "10.76-14mm",
            "16mm",
            "18mm",
            "20mm",
            "22mm",
            "25mm"});
            this.cmb_GlazingArtNo.Location = new System.Drawing.Point(74, 75);
            this.cmb_GlazingArtNo.Name = "cmb_GlazingArtNo";
            this.cmb_GlazingArtNo.Size = new System.Drawing.Size(73, 21);
            this.cmb_GlazingArtNo.TabIndex = 28;
            this.cmb_GlazingArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_GlazingArtNo_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Film type";
            // 
            // cmb_FilmType
            // 
            this.cmb_FilmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FilmType.DropDownWidth = 100;
            this.cmb_FilmType.FormattingEnabled = true;
            this.cmb_FilmType.Location = new System.Drawing.Point(74, 104);
            this.cmb_FilmType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_FilmType.Name = "cmb_FilmType";
            this.cmb_FilmType.Size = new System.Drawing.Size(73, 21);
            this.cmb_FilmType.TabIndex = 30;
            this.cmb_FilmType.SelectedValueChanged += new System.EventHandler(this.cmb_FilmType_SelectedValueChanged);
            // 
            // PP_GlassPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_GlassType);
            this.Controls.Add(this.lbl_glassthick);
            this.Controls.Add(this.btn_SelectGlassthickness);
            this.Controls.Add(this.lbl_GlassThicknessDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_GlazingArtNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_FilmType);
            this.Name = "PP_GlassPropertyUC";
            this.Size = new System.Drawing.Size(154, 130);
            this.Load += new System.EventHandler(this.PP_GlassPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_GlassType;
        private System.Windows.Forms.Label lbl_glassthick;
        private System.Windows.Forms.Button btn_SelectGlassthickness;
        private System.Windows.Forms.Label lbl_GlassThicknessDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_GlazingArtNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_FilmType;
    }
}
