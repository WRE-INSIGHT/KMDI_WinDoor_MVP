namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_ScreenPropertyUC
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
            this.lbl_ScreenType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_Screen = new System.Windows.Forms.CheckBox();
            this.pnl_ScreenHeight = new System.Windows.Forms.Panel();
            this.nud_screenHeight = new System.Windows.Forms.NumericUpDown();
            this.chck_screenHeightOption = new System.Windows.Forms.CheckBox();
            this.pnl_screenHeightPic = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnl_ScreenHeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_screenHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ScreenType.Location = new System.Drawing.Point(4, 7);
            this.lbl_ScreenType.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(101, 20);
            this.lbl_ScreenType.TabIndex = 20;
            this.lbl_ScreenType.Text = "Insect Screen";
            this.lbl_ScreenType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_Screen);
            this.panel1.Controls.Add(this.lbl_ScreenType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 31);
            this.panel1.TabIndex = 21;
            // 
            // chk_Screen
            // 
            this.chk_Screen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Screen.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_Screen.FlatAppearance.BorderSize = 0;
            this.chk_Screen.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_Screen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Screen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Screen.Location = new System.Drawing.Point(143, 2);
            this.chk_Screen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_Screen.Name = "chk_Screen";
            this.chk_Screen.Size = new System.Drawing.Size(63, 26);
            this.chk_Screen.TabIndex = 36;
            this.chk_Screen.Text = "No";
            this.chk_Screen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Screen.UseVisualStyleBackColor = false;
            this.chk_Screen.CheckedChanged += new System.EventHandler(this.chk_Screen_CheckedChanged);
            // 
            // pnl_ScreenHeight
            // 
            this.pnl_ScreenHeight.Controls.Add(this.nud_screenHeight);
            this.pnl_ScreenHeight.Controls.Add(this.chck_screenHeightOption);
            this.pnl_ScreenHeight.Controls.Add(this.pnl_screenHeightPic);
            this.pnl_ScreenHeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ScreenHeight.Location = new System.Drawing.Point(0, 31);
            this.pnl_ScreenHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_ScreenHeight.Name = "pnl_ScreenHeight";
            this.pnl_ScreenHeight.Size = new System.Drawing.Size(209, 32);
            this.pnl_ScreenHeight.TabIndex = 25;
            // 
            // nud_screenHeight
            // 
            this.nud_screenHeight.Location = new System.Drawing.Point(43, 5);
            this.nud_screenHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nud_screenHeight.Name = "nud_screenHeight";
            this.nud_screenHeight.Size = new System.Drawing.Size(136, 22);
            this.nud_screenHeight.TabIndex = 31;
            this.nud_screenHeight.ValueChanged += new System.EventHandler(this.nud_screenHeight_ValueChanged);
            this.nud_screenHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_screenHeight_KeyUp);
            this.nud_screenHeight.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.nud_screenHeight_MouseWheel);
            // 
            // chck_screenHeightOption
            // 
            this.chck_screenHeightOption.AutoSize = true;
            this.chck_screenHeightOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chck_screenHeightOption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chck_screenHeightOption.Location = new System.Drawing.Point(187, 11);
            this.chck_screenHeightOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chck_screenHeightOption.Name = "chck_screenHeightOption";
            this.chck_screenHeightOption.Size = new System.Drawing.Size(14, 13);
            this.chck_screenHeightOption.TabIndex = 30;
            this.chck_screenHeightOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chck_screenHeightOption.UseVisualStyleBackColor = true;
            // 
            // pnl_screenHeightPic
            // 
            this.pnl_screenHeightPic.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_screenHeightPic.BackgroundImage = global::PresentationLayer.Properties.Resources.ExtensionRight1;
            this.pnl_screenHeightPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl_screenHeightPic.Location = new System.Drawing.Point(7, 5);
            this.pnl_screenHeightPic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_screenHeightPic.Name = "pnl_screenHeightPic";
            this.pnl_screenHeightPic.Size = new System.Drawing.Size(28, 26);
            this.pnl_screenHeightPic.TabIndex = 29;
            // 
            // FP_ScreenPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_ScreenHeight);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FP_ScreenPropertyUC";
            this.Size = new System.Drawing.Size(209, 66);
            this.Load += new System.EventHandler(this.FP_ScreenPropertyUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_ScreenHeight.ResumeLayout(false);
            this.pnl_ScreenHeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_screenHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ScreenType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chk_Screen;
        private System.Windows.Forms.Panel pnl_ScreenHeight;
        private System.Windows.Forms.Panel pnl_screenHeightPic;
        private System.Windows.Forms.CheckBox chck_screenHeightOption;
        private System.Windows.Forms.NumericUpDown nud_screenHeight;
    }
}
