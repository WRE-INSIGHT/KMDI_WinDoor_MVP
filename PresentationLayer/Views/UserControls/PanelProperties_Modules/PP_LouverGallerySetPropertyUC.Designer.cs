namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_LouverGallerySetPropertyUC
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
            this.pnl_body = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_addLouver = new System.Windows.Forms.Button();
            this.btn_SaveGallerySet = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmb_GalleryColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_HandleLocation = new System.Windows.Forms.ComboBox();
            this.lbl_HandleLocation = new System.Windows.Forms.Label();
            this.cmb_HandleType = new System.Windows.Forms.ComboBox();
            this.lbl_HandleType = new System.Windows.Forms.Label();
            this.nud_NoOfBladePerSet = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_BladeHeight = new System.Windows.Forms.ComboBox();
            this.lbl_BladeHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_body.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NoOfBladePerSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_body
            // 
            this.pnl_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_body.Controls.Add(this.panel4);
            this.pnl_body.Controls.Add(this.panel2);
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 0);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(150, 178);
            this.pnl_body.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_addLouver);
            this.panel4.Controls.Add(this.btn_SaveGallerySet);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 149);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 27);
            this.panel4.TabIndex = 71;
            // 
            // btn_addLouver
            // 
            this.btn_addLouver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addLouver.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_addLouver.Location = new System.Drawing.Point(5, 3);
            this.btn_addLouver.Name = "btn_addLouver";
            this.btn_addLouver.Size = new System.Drawing.Size(62, 23);
            this.btn_addLouver.TabIndex = 63;
            this.btn_addLouver.Text = "Add Set";
            this.btn_addLouver.UseVisualStyleBackColor = true;
            this.btn_addLouver.Click += new System.EventHandler(this.btn_addLouver_Click);
            // 
            // btn_SaveGallerySet
            // 
            this.btn_SaveGallerySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveGallerySet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveGallerySet.Location = new System.Drawing.Point(84, 3);
            this.btn_SaveGallerySet.Name = "btn_SaveGallerySet";
            this.btn_SaveGallerySet.Size = new System.Drawing.Size(63, 21);
            this.btn_SaveGallerySet.TabIndex = 61;
            this.btn_SaveGallerySet.Text = "Save";
            this.btn_SaveGallerySet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SaveGallerySet.UseVisualStyleBackColor = true;
            this.btn_SaveGallerySet.Click += new System.EventHandler(this.btn_SaveGallerySet_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmb_GalleryColor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmb_HandleLocation);
            this.panel2.Controls.Add(this.lbl_HandleLocation);
            this.panel2.Controls.Add(this.cmb_HandleType);
            this.panel2.Controls.Add(this.lbl_HandleType);
            this.panel2.Controls.Add(this.nud_NoOfBladePerSet);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_BladeHeight);
            this.panel2.Controls.Add(this.lbl_BladeHeight);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 149);
            this.panel2.TabIndex = 68;
            // 
            // cmb_GalleryColor
            // 
            this.cmb_GalleryColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_GalleryColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GalleryColor.FormattingEnabled = true;
            this.cmb_GalleryColor.Location = new System.Drawing.Point(75, 124);
            this.cmb_GalleryColor.Name = "cmb_GalleryColor";
            this.cmb_GalleryColor.Size = new System.Drawing.Size(70, 21);
            this.cmb_GalleryColor.TabIndex = 62;
            this.cmb_GalleryColor.SelectedValueChanged += new System.EventHandler(this.cmb_GalleryColor_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Color";
            // 
            // cmb_HandleLocation
            // 
            this.cmb_HandleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_HandleLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleLocation.FormattingEnabled = true;
            this.cmb_HandleLocation.Location = new System.Drawing.Point(75, 98);
            this.cmb_HandleLocation.Name = "cmb_HandleLocation";
            this.cmb_HandleLocation.Size = new System.Drawing.Size(70, 21);
            this.cmb_HandleLocation.TabIndex = 60;
            this.cmb_HandleLocation.SelectedValueChanged += new System.EventHandler(this.cmb_HandleLocation_SelectedValueChanged);
            // 
            // lbl_HandleLocation
            // 
            this.lbl_HandleLocation.AutoSize = true;
            this.lbl_HandleLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HandleLocation.Location = new System.Drawing.Point(3, 102);
            this.lbl_HandleLocation.Name = "lbl_HandleLocation";
            this.lbl_HandleLocation.Size = new System.Drawing.Size(64, 13);
            this.lbl_HandleLocation.TabIndex = 59;
            this.lbl_HandleLocation.Text = "Handle Loc";
            // 
            // cmb_HandleType
            // 
            this.cmb_HandleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_HandleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleType.FormattingEnabled = true;
            this.cmb_HandleType.Location = new System.Drawing.Point(75, 72);
            this.cmb_HandleType.Name = "cmb_HandleType";
            this.cmb_HandleType.Size = new System.Drawing.Size(70, 21);
            this.cmb_HandleType.TabIndex = 58;
            this.cmb_HandleType.SelectedValueChanged += new System.EventHandler(this.cmb_HandleType_SelectedValueChanged);
            // 
            // lbl_HandleType
            // 
            this.lbl_HandleType.AutoSize = true;
            this.lbl_HandleType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HandleType.Location = new System.Drawing.Point(3, 76);
            this.lbl_HandleType.Name = "lbl_HandleType";
            this.lbl_HandleType.Size = new System.Drawing.Size(70, 13);
            this.lbl_HandleType.TabIndex = 57;
            this.lbl_HandleType.Text = "Handle Type";
            // 
            // nud_NoOfBladePerSet
            // 
            this.nud_NoOfBladePerSet.Location = new System.Drawing.Point(75, 47);
            this.nud_NoOfBladePerSet.Name = "nud_NoOfBladePerSet";
            this.nud_NoOfBladePerSet.Size = new System.Drawing.Size(72, 20);
            this.nud_NoOfBladePerSet.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "No. of Blades";
            // 
            // cmb_BladeHeight
            // 
            this.cmb_BladeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_BladeHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BladeHeight.FormattingEnabled = true;
            this.cmb_BladeHeight.Location = new System.Drawing.Point(75, 21);
            this.cmb_BladeHeight.Name = "cmb_BladeHeight";
            this.cmb_BladeHeight.Size = new System.Drawing.Size(70, 21);
            this.cmb_BladeHeight.TabIndex = 54;
            this.cmb_BladeHeight.SelectedValueChanged += new System.EventHandler(this.cmb_BladeHeight_SelectedValueChanged);
            // 
            // lbl_BladeHeight
            // 
            this.lbl_BladeHeight.AutoSize = true;
            this.lbl_BladeHeight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BladeHeight.Location = new System.Drawing.Point(4, 24);
            this.lbl_BladeHeight.Name = "lbl_BladeHeight";
            this.lbl_BladeHeight.Size = new System.Drawing.Size(73, 13);
            this.lbl_BladeHeight.TabIndex = 53;
            this.lbl_BladeHeight.Text = "Blade Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Gallery Set";
            // 
            // PP_LouverGallerySetPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_body);
            this.Name = "PP_LouverGallerySetPropertyUC";
            this.Size = new System.Drawing.Size(150, 178);
            this.Load += new System.EventHandler(this.PP_LouverGallerySetPropertyUC_Load);
            this.pnl_body.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NoOfBladePerSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_addLouver;
        private System.Windows.Forms.Button btn_SaveGallerySet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_GalleryColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_HandleLocation;
        private System.Windows.Forms.Label lbl_HandleLocation;
        private System.Windows.Forms.ComboBox cmb_HandleType;
        private System.Windows.Forms.Label lbl_HandleType;
        private System.Windows.Forms.NumericUpDown nud_NoOfBladePerSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_BladeHeight;
        private System.Windows.Forms.Label lbl_BladeHeight;
    }
}
