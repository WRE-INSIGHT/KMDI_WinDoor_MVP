namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_CenterHingePropertyUC
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
            this.cmb_CenterHinge = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_CenterHinge
            // 
            this.cmb_CenterHinge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CenterHinge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CenterHinge.DropDownWidth = 69;
            this.cmb_CenterHinge.FormattingEnabled = true;
            this.cmb_CenterHinge.Location = new System.Drawing.Point(69, 5);
            this.cmb_CenterHinge.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_CenterHinge.Name = "cmb_CenterHinge";
            this.cmb_CenterHinge.Size = new System.Drawing.Size(84, 21);
            this.cmb_CenterHinge.TabIndex = 37;
            this.cmb_CenterHinge.SelectedValueChanged += new System.EventHandler(this.cmb_CenterHinge_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Center Hinge";
            // 
            // PP_CenterHingePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_CenterHinge);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_CenterHingePropertyUC";
            this.Size = new System.Drawing.Size(154, 30);
            this.Load += new System.EventHandler(this.PP_CenterHingePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_CenterHinge;
        private System.Windows.Forms.Label label1;
    }
}
