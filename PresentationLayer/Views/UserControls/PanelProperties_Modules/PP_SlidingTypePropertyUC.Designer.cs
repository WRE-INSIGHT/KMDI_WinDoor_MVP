namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_SlidingTypePropertyUC
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
            this.cmb_SlidingType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_SlidingType
            // 
            this.cmb_SlidingType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_SlidingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SlidingType.DropDownWidth = 69;
            this.cmb_SlidingType.FormattingEnabled = true;
            this.cmb_SlidingType.Location = new System.Drawing.Point(71, 4);
            this.cmb_SlidingType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_SlidingType.Name = "cmb_SlidingType";
            this.cmb_SlidingType.Size = new System.Drawing.Size(77, 21);
            this.cmb_SlidingType.TabIndex = 37;
            this.cmb_SlidingType.SelectedValueChanged += new System.EventHandler(this.cmb_SlidingType_SelectedValueChanged);
            this.cmb_SlidingType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_SlidingType_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Sliding Type";
            // 
            // PP_SlidingTypePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_SlidingType);
            this.Controls.Add(this.label1);
            this.Name = "PP_SlidingTypePropertyUC";
            this.Size = new System.Drawing.Size(152, 28);
            this.Load += new System.EventHandler(this.PP_SlidingTypePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_SlidingType;
        private System.Windows.Forms.Label label1;
    }
}
