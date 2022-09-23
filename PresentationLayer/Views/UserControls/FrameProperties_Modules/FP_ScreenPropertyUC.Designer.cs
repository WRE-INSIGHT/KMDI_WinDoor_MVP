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
            this.cmb_ScreenType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_ScreenType.Location = new System.Drawing.Point(1, 7);
            this.lbl_ScreenType.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(69, 15);
            this.lbl_ScreenType.TabIndex = 20;
            this.lbl_ScreenType.Text = "Screen Type";
            this.lbl_ScreenType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_ScreenType
            // 
            this.cmb_ScreenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ScreenType.FormattingEnabled = true;
            this.cmb_ScreenType.Location = new System.Drawing.Point(73, 5);
            this.cmb_ScreenType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_ScreenType.Name = "cmb_ScreenType";
            this.cmb_ScreenType.Size = new System.Drawing.Size(83, 21);
            this.cmb_ScreenType.TabIndex = 19;
            this.cmb_ScreenType.SelectedValueChanged += new System.EventHandler(this.cmb_ScreenType_SelectedValueChanged);
            // 
            // FP_ScreenPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ScreenType);
            this.Controls.Add(this.cmb_ScreenType);
            this.Name = "FP_ScreenPropertyUC";
            this.Size = new System.Drawing.Size(159, 30);
            this.Load += new System.EventHandler(this.FP_ScreenPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ScreenType;
        private System.Windows.Forms.ComboBox cmb_ScreenType;
    }
}
