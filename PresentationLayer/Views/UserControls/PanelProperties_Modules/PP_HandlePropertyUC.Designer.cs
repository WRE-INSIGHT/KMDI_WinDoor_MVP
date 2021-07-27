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
            this.flp_HandleTypeOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_HandleType = new System.Windows.Forms.ComboBox();
            this.flp_HandleTypeOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_HandleTypeOptions
            // 
            this.flp_HandleTypeOptions.Controls.Add(this.panel1);
            this.flp_HandleTypeOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_HandleTypeOptions.Location = new System.Drawing.Point(0, 0);
            this.flp_HandleTypeOptions.Name = "flp_HandleTypeOptions";
            this.flp_HandleTypeOptions.Size = new System.Drawing.Size(154, 35);
            this.flp_HandleTypeOptions.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmb_HandleType);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 36);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 36);
            this.label7.TabIndex = 15;
            this.label7.Text = "Handle Type";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_HandleType
            // 
            this.cmb_HandleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleType.FormattingEnabled = true;
            this.cmb_HandleType.Location = new System.Drawing.Point(52, 7);
            this.cmb_HandleType.Name = "cmb_HandleType";
            this.cmb_HandleType.Size = new System.Drawing.Size(98, 21);
            this.cmb_HandleType.TabIndex = 16;
            this.cmb_HandleType.SelectedValueChanged += new System.EventHandler(this.cmb_HandleType_SelectedValueChanged);
            // 
            // PP_HandlePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flp_HandleTypeOptions);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_HandlePropertyUC";
            this.Size = new System.Drawing.Size(154, 35);
            this.Load += new System.EventHandler(this.PP_HandlePropertyUC_Load);
            this.flp_HandleTypeOptions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_HandleTypeOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_HandleType;
    }
}
