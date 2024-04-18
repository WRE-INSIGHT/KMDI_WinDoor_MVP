
namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_InversionClipPropertyUC
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
            this.lbl_InversionClip = new System.Windows.Forms.Label();
            this.chk_InversionClip = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_InversionClip
            // 
            this.lbl_InversionClip.Location = new System.Drawing.Point(3, 1);
            this.lbl_InversionClip.Name = "lbl_InversionClip";
            this.lbl_InversionClip.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lbl_InversionClip.Size = new System.Drawing.Size(91, 24);
            this.lbl_InversionClip.TabIndex = 36;
            this.lbl_InversionClip.Text = "Inversion Clip";
            this.lbl_InversionClip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chk_InversionClip
            // 
            this.chk_InversionClip.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_InversionClip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_InversionClip.FlatAppearance.BorderSize = 0;
            this.chk_InversionClip.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_InversionClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_InversionClip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_InversionClip.Location = new System.Drawing.Point(98, 4);
            this.chk_InversionClip.Name = "chk_InversionClip";
            this.chk_InversionClip.Size = new System.Drawing.Size(50, 21);
            this.chk_InversionClip.TabIndex = 37;
            this.chk_InversionClip.Text = "No";
            this.chk_InversionClip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_InversionClip.UseVisualStyleBackColor = false;
            this.chk_InversionClip.CheckedChanged += new System.EventHandler(this.chk_InversionClip_CheckedChanged);
            // 
            // FP_InversionClipPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_InversionClip);
            this.Controls.Add(this.chk_InversionClip);
            this.Name = "FP_InversionClipPropertyUC";
            this.Size = new System.Drawing.Size(150, 27);
            this.Load += new System.EventHandler(this.FP_InversionClipPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_InversionClip;
        private System.Windows.Forms.CheckBox chk_InversionClip;
    }
}
