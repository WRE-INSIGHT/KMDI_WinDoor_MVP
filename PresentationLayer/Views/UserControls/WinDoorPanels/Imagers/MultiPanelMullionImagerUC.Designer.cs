namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    partial class MultiPanelMullionImagerUC
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
            this.flp_MultiMullionImager = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_MultiMullionImager
            // 
            this.flp_MultiMullionImager.AllowDrop = true;
            this.flp_MultiMullionImager.BackColor = System.Drawing.SystemColors.Control;
            this.flp_MultiMullionImager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_MultiMullionImager.Location = new System.Drawing.Point(0, 0);
            this.flp_MultiMullionImager.Margin = new System.Windows.Forms.Padding(0);
            this.flp_MultiMullionImager.Name = "flp_MultiMullionImager";
            this.flp_MultiMullionImager.Size = new System.Drawing.Size(300, 300);
            this.flp_MultiMullionImager.TabIndex = 1;
            // 
            // MultiPanelMullionImagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flp_MultiMullionImager);
            this.Name = "MultiPanelMullionImagerUC";
            this.Size = new System.Drawing.Size(300, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MultiPanelMullionImagerUC_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_MultiMullionImager;
    }
}
