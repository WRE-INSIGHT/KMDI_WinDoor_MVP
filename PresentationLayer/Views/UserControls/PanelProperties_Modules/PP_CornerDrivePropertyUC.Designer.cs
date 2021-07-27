namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_CornerDrivePropertyUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_CornerDrive = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Corner Drive";
            // 
            // cmb_CornerDrive
            // 
            this.cmb_CornerDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CornerDrive.DropDownWidth = 69;
            this.cmb_CornerDrive.FormattingEnabled = true;
            this.cmb_CornerDrive.Location = new System.Drawing.Point(68, 4);
            this.cmb_CornerDrive.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_CornerDrive.Name = "cmb_CornerDrive";
            this.cmb_CornerDrive.Size = new System.Drawing.Size(84, 21);
            this.cmb_CornerDrive.TabIndex = 33;
            this.cmb_CornerDrive.SelectedValueChanged += new System.EventHandler(this.cmb_CornerDrive_SelectedValueChanged);
            // 
            // PP_CornerDrivePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_CornerDrive);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_CornerDrivePropertyUC";
            this.Size = new System.Drawing.Size(154, 30);
            this.Load += new System.EventHandler(this.PP_CornerDrivePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_CornerDrive;
    }
}
