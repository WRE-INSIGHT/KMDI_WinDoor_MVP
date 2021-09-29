namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_MiddleCloserPropertyUC
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
            this.cmb_MiddleCLoser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_MiddleCLoser
            // 
            this.cmb_MiddleCLoser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_MiddleCLoser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MiddleCLoser.DropDownWidth = 69;
            this.cmb_MiddleCLoser.FormattingEnabled = true;
            this.cmb_MiddleCLoser.Location = new System.Drawing.Point(71, 5);
            this.cmb_MiddleCLoser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_MiddleCLoser.Name = "cmb_MiddleCLoser";
            this.cmb_MiddleCLoser.Size = new System.Drawing.Size(82, 21);
            this.cmb_MiddleCLoser.TabIndex = 39;
            this.cmb_MiddleCLoser.SelectedValueChanged += new System.EventHandler(this.cmb_MiddleCLoser_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 26);
            this.label1.TabIndex = 38;
            this.label1.Text = "Middle\r\nCloser";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PP_MiddleCloserPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_MiddleCLoser);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_MiddleCloserPropertyUC";
            this.Size = new System.Drawing.Size(154, 30);
            this.Load += new System.EventHandler(this.PP_MiddleCloserPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_MiddleCLoser;
        private System.Windows.Forms.Label label1;
    }
}
