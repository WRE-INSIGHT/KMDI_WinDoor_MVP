namespace PresentationLayer.Views.UserControls
{
    partial class Panel_PropertiesUC
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
            this.lbl_pnlname = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.chk_Orientation = new System.Windows.Forms.CheckBox();
            this.num_BladeCount = new System.Windows.Forms.NumericUpDown();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.pnum_Width = new System.Windows.Forms.NumericUpDown();
            this.pnum_Height = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.lbl_PanelGlassID = new System.Windows.Forms.Label();
            this.lbl_pnlSpecs = new System.Windows.Forms.Label();
            this.pnl_panelSpecsBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).BeginInit();
            this.pnl_panelSpecsBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_pnlname
            // 
            this.lbl_pnlname.AutoSize = true;
            this.lbl_pnlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pnlname.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pnlname.Location = new System.Drawing.Point(8, 24);
            this.lbl_pnlname.Name = "lbl_pnlname";
            this.lbl_pnlname.Size = new System.Drawing.Size(90, 15);
            this.lbl_pnlname.TabIndex = 0;
            this.lbl_pnlname.Text = "FixedPanelUC_1";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Type.Location = new System.Drawing.Point(8, 45);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(87, 13);
            this.lbl_Type.TabIndex = 1;
            this.lbl_Type.Text = "Tilt&Turn Panel";
            this.lbl_Type.UseMnemonic = false;
            // 
            // chk_Orientation
            // 
            this.chk_Orientation.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Orientation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_Orientation.FlatAppearance.BorderSize = 0;
            this.chk_Orientation.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_Orientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Orientation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Orientation.Location = new System.Drawing.Point(102, 41);
            this.chk_Orientation.Name = "chk_Orientation";
            this.chk_Orientation.Size = new System.Drawing.Size(50, 21);
            this.chk_Orientation.TabIndex = 2;
            this.chk_Orientation.Text = "Norm";
            this.chk_Orientation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Orientation.UseVisualStyleBackColor = false;
            this.chk_Orientation.CheckedChanged += new System.EventHandler(this.chk_Orientation_CheckedChanged);
            // 
            // num_BladeCount
            // 
            this.num_BladeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_BladeCount.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.num_BladeCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_BladeCount.Location = new System.Drawing.Point(102, 40);
            this.num_BladeCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_BladeCount.Name = "num_BladeCount";
            this.num_BladeCount.Size = new System.Drawing.Size(50, 22);
            this.num_BladeCount.TabIndex = 3;
            this.num_BladeCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_BladeCount.Visible = false;
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Width.Location = new System.Drawing.Point(8, 61);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(39, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // pnum_Width
            // 
            this.pnum_Width.Enabled = false;
            this.pnum_Width.Location = new System.Drawing.Point(7, 78);
            this.pnum_Width.Name = "pnum_Width";
            this.pnum_Width.Size = new System.Drawing.Size(135, 20);
            this.pnum_Width.TabIndex = 5;
            // 
            // pnum_Height
            // 
            this.pnum_Height.Enabled = false;
            this.pnum_Height.Location = new System.Drawing.Point(7, 118);
            this.pnum_Height.Name = "pnum_Height";
            this.pnum_Height.Size = new System.Drawing.Size(135, 20);
            this.pnum_Height.TabIndex = 7;
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(8, 102);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(42, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // lbl_PanelGlassID
            // 
            this.lbl_PanelGlassID.AutoSize = true;
            this.lbl_PanelGlassID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PanelGlassID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PanelGlassID.Location = new System.Drawing.Point(8, 2);
            this.lbl_PanelGlassID.Name = "lbl_PanelGlassID";
            this.lbl_PanelGlassID.Size = new System.Drawing.Size(28, 21);
            this.lbl_PanelGlassID.TabIndex = 9;
            this.lbl_PanelGlassID.Text = "P1";
            // 
            // lbl_pnlSpecs
            // 
            this.lbl_pnlSpecs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_pnlSpecs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pnlSpecs.Location = new System.Drawing.Point(1, 0);
            this.lbl_pnlSpecs.Name = "lbl_pnlSpecs";
            this.lbl_pnlSpecs.Size = new System.Drawing.Size(150, 18);
            this.lbl_pnlSpecs.TabIndex = 8;
            this.lbl_pnlSpecs.Text = "Panel Specification";
            this.lbl_pnlSpecs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_panelSpecsBody
            // 
            this.pnl_panelSpecsBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_panelSpecsBody.AutoSize = true;
            this.pnl_panelSpecsBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_panelSpecsBody.Controls.Add(this.lbl_pnlSpecs);
            this.pnl_panelSpecsBody.Location = new System.Drawing.Point(3, 144);
            this.pnl_panelSpecsBody.Name = "pnl_panelSpecsBody";
            this.pnl_panelSpecsBody.Padding = new System.Windows.Forms.Padding(1, 0, 1, 5);
            this.pnl_panelSpecsBody.Size = new System.Drawing.Size(154, 161);
            this.pnl_panelSpecsBody.TabIndex = 10;
            // 
            // Panel_PropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_PanelGlassID);
            this.Controls.Add(this.pnum_Height);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.pnum_Width);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_pnlname);
            this.Controls.Add(this.chk_Orientation);
            this.Controls.Add(this.num_BladeCount);
            this.Controls.Add(this.pnl_panelSpecsBody);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Panel_PropertiesUC";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Size = new System.Drawing.Size(161, 310);
            this.Load += new System.EventHandler(this.PanelPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).EndInit();
            this.pnl_panelSpecsBody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pnlname;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.CheckBox chk_Orientation;
        private System.Windows.Forms.NumericUpDown num_BladeCount;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown pnum_Width;
        private System.Windows.Forms.NumericUpDown pnum_Height;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.Label lbl_PanelGlassID;
        private System.Windows.Forms.Label lbl_pnlSpecs;
        private System.Windows.Forms.Panel pnl_panelSpecsBody;
    }
}
