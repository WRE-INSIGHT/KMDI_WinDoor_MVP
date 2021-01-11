namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class MultiPanelMullionUC
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
            this.flp_Multi = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_Multi
            // 
            this.flp_Multi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Multi.Location = new System.Drawing.Point(0, 0);
            this.flp_Multi.Name = "flp_Multi";
            this.flp_Multi.Size = new System.Drawing.Size(150, 150);
            this.flp_Multi.TabIndex = 0;
            this.flp_Multi.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_Multi_Paint);
            // 
            // MultiPanelMullionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.flp_Multi);
            this.Name = "MultiPanelMullionUC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_Multi;
    }
}
