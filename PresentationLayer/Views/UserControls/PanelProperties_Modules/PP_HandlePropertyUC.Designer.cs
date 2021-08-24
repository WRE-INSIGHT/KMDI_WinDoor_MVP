namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_HandlePropertyUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_HandleType = new System.Windows.Forms.ComboBox();
            this.pnl_HandleTypeOptions = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmb_HandleType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 48);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "*Incompatibility";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Handle Type";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_HandleType
            // 
            this.cmb_HandleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_HandleType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_HandleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleType.FormattingEnabled = true;
            this.cmb_HandleType.Location = new System.Drawing.Point(72, 21);
            this.cmb_HandleType.Name = "cmb_HandleType";
            this.cmb_HandleType.Size = new System.Drawing.Size(78, 21);
            this.cmb_HandleType.TabIndex = 16;
            this.cmb_HandleType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_HandleType_DrawItem);
            this.cmb_HandleType.SelectedValueChanged += new System.EventHandler(this.cmb_HandleType_SelectedValueChanged);
            // 
            // pnl_HandleTypeOptions
            // 
            this.pnl_HandleTypeOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_HandleTypeOptions.Location = new System.Drawing.Point(0, 48);
            this.pnl_HandleTypeOptions.Name = "pnl_HandleTypeOptions";
            this.pnl_HandleTypeOptions.Size = new System.Drawing.Size(154, 0);
            this.pnl_HandleTypeOptions.TabIndex = 1;
            // 
            // PP_HandlePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_HandleTypeOptions);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_HandlePropertyUC";
            this.Size = new System.Drawing.Size(154, 48);
            this.Load += new System.EventHandler(this.PP_HandlePropertyUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_HandleType;
        private System.Windows.Forms.Panel pnl_HandleTypeOptions;
        private System.Windows.Forms.Label label1;
    }
}
