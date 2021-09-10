namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    partial class DP_LeverEspagnolettePropertyUC
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
            this.cmb_LeverEspag = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_LeverEspag
            // 
            this.cmb_LeverEspag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_LeverEspag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LeverEspag.DropDownWidth = 69;
            this.cmb_LeverEspag.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_LeverEspag.FormattingEnabled = true;
            this.cmb_LeverEspag.Location = new System.Drawing.Point(67, 2);
            this.cmb_LeverEspag.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_LeverEspag.Name = "cmb_LeverEspag";
            this.cmb_LeverEspag.Size = new System.Drawing.Size(84, 21);
            this.cmb_LeverEspag.TabIndex = 39;
            this.cmb_LeverEspag.SelectedValueChanged += new System.EventHandler(this.cmb_LeverEspag_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Lever Espagnolette";
            // 
            // DP_LeverEspagnolettePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_LeverEspag);
            this.Controls.Add(this.label1);
            this.Name = "DP_LeverEspagnolettePropertyUC";
            this.Size = new System.Drawing.Size(152, 28);
            this.Load += new System.EventHandler(this.DP_LeverEspagnolettePropertyUC_Load);
            this.VisibleChanged += new System.EventHandler(this.DP_LeverEspagnolettePropertyUC_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_LeverEspag;
        private System.Windows.Forms.Label label1;
    }
}
