namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_EspagnolettePropertyUC
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
            this.cmb_Espagnolette = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_Espagnolette
            // 
            this.cmb_Espagnolette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Espagnolette.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Espagnolette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Espagnolette.FormattingEnabled = true;
            this.cmb_Espagnolette.Location = new System.Drawing.Point(67, 3);
            this.cmb_Espagnolette.Name = "cmb_Espagnolette";
            this.cmb_Espagnolette.Size = new System.Drawing.Size(84, 21);
            this.cmb_Espagnolette.TabIndex = 30;
            this.cmb_Espagnolette.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Espagnolette_DrawItem);
            this.cmb_Espagnolette.SelectedValueChanged += new System.EventHandler(this.cmb_Espagnolette_SelectedValueChanged);
            this.cmb_Espagnolette.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Espagnolette_KeyPress);
            this.cmb_Espagnolette.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_Espagnolette_MouseWheel);
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Espagnolette";
            // 
            // PP_EspagnolettePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_Espagnolette);
            this.Name = "PP_EspagnolettePropertyUC";
            this.Size = new System.Drawing.Size(154, 28);
            this.Load += new System.EventHandler(this.PP_EspagnolettePropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Espagnolette;
        private System.Windows.Forms.Label label8;
    }
}
