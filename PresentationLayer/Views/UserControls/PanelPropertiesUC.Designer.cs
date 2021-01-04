namespace PresentationLayer.Views.UserControls
{
    partial class PanelPropertiesUC
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
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_pnlname
            // 
            this.lbl_pnlname.AutoSize = true;
            this.lbl_pnlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pnlname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pnlname.Location = new System.Drawing.Point(7, 9);
            this.lbl_pnlname.Name = "lbl_pnlname";
            this.lbl_pnlname.Size = new System.Drawing.Size(58, 21);
            this.lbl_pnlname.TabIndex = 0;
            this.lbl_pnlname.Text = "Panel 1";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Type.Location = new System.Drawing.Point(7, 36);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(87, 13);
            this.lbl_Type.TabIndex = 1;
            this.lbl_Type.Text = "Tilt&Turn Panel";
            this.lbl_Type.UseMnemonic = false;
            // 
            // chk_Orientation
            // 
            this.chk_Orientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Orientation.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Orientation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_Orientation.FlatAppearance.BorderSize = 0;
            this.chk_Orientation.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_Orientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Orientation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Orientation.Location = new System.Drawing.Point(100, 32);
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
            this.num_BladeCount.Location = new System.Drawing.Point(100, 32);
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
            this.lbl_Width.Location = new System.Drawing.Point(7, 57);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(39, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // pnum_Width
            // 
            this.pnum_Width.Location = new System.Drawing.Point(7, 75);
            this.pnum_Width.Name = "pnum_Width";
            this.pnum_Width.Size = new System.Drawing.Size(135, 20);
            this.pnum_Width.TabIndex = 5;
            // 
            // pnum_Height
            // 
            this.pnum_Height.Location = new System.Drawing.Point(7, 118);
            this.pnum_Height.Name = "pnum_Height";
            this.pnum_Height.Size = new System.Drawing.Size(135, 20);
            this.pnum_Height.TabIndex = 7;
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(7, 100);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(42, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // PanelPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnum_Height);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.pnum_Width);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_pnlname);
            this.Controls.Add(this.chk_Orientation);
            this.Controls.Add(this.num_BladeCount);
            this.Name = "PanelPropertiesUC";
            this.Size = new System.Drawing.Size(159, 148);
            this.Load += new System.EventHandler(this.PanelPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).EndInit();
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
    }
}
