namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_MagnumScreenTypeUC
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
            this.magnumScreenPanel = new System.Windows.Forms.Panel();
            this.screenTypeLabel = new System.Windows.Forms.Label();
            this.reinforcedChkBx = new System.Windows.Forms.CheckBox();
            this.magnumScreenTypeCmb = new System.Windows.Forms.ComboBox();
            this.magnumScreenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // magnumScreenPanel
            // 
            this.magnumScreenPanel.Controls.Add(this.screenTypeLabel);
            this.magnumScreenPanel.Controls.Add(this.reinforcedChkBx);
            this.magnumScreenPanel.Controls.Add(this.magnumScreenTypeCmb);
            this.magnumScreenPanel.Location = new System.Drawing.Point(0, 3);
            this.magnumScreenPanel.Name = "magnumScreenPanel";
            this.magnumScreenPanel.Size = new System.Drawing.Size(224, 80);
            this.magnumScreenPanel.TabIndex = 0;
            // 
            // screenTypeLabel
            // 
            this.screenTypeLabel.AutoSize = true;
            this.screenTypeLabel.Location = new System.Drawing.Point(5, 9);
            this.screenTypeLabel.Name = "screenTypeLabel";
            this.screenTypeLabel.Size = new System.Drawing.Size(68, 13);
            this.screenTypeLabel.TabIndex = 2;
            this.screenTypeLabel.Text = "Screen Type";
            // 
            // reinforcedChkBx
            // 
            this.reinforcedChkBx.AutoSize = true;
            this.reinforcedChkBx.Location = new System.Drawing.Point(8, 55);
            this.reinforcedChkBx.Name = "reinforcedChkBx";
            this.reinforcedChkBx.Size = new System.Drawing.Size(78, 17);
            this.reinforcedChkBx.TabIndex = 1;
            this.reinforcedChkBx.Text = "Reinforced";
            this.reinforcedChkBx.UseVisualStyleBackColor = true;
            this.reinforcedChkBx.CheckedChanged += new System.EventHandler(this.reinforcedChkBx_CheckedChanged);
            // 
            // magnumScreenTypeCmb
            // 
            this.magnumScreenTypeCmb.FormattingEnabled = true;
            this.magnumScreenTypeCmb.Location = new System.Drawing.Point(8, 28);
            this.magnumScreenTypeCmb.Name = "magnumScreenTypeCmb";
            this.magnumScreenTypeCmb.Size = new System.Drawing.Size(174, 21);
            this.magnumScreenTypeCmb.TabIndex = 0;
            this.magnumScreenTypeCmb.SelectedValueChanged += new System.EventHandler(this.magnumScreenTypeCmb_SelectedValueChanged);
            // 
            // SP_MagnumScreenTypeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.magnumScreenPanel);
            this.Name = "SP_MagnumScreenTypeUC";
            this.Size = new System.Drawing.Size(227, 86);
            this.Load += new System.EventHandler(this.SP_MagnumScreenTypeUC_Load);
            this.magnumScreenPanel.ResumeLayout(false);
            this.magnumScreenPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel magnumScreenPanel;
        private System.Windows.Forms.Label screenTypeLabel;
        private System.Windows.Forms.CheckBox reinforcedChkBx;
        private System.Windows.Forms.ComboBox magnumScreenTypeCmb;
    }
}
