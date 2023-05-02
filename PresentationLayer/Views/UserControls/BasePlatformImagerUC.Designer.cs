namespace PresentationLayer.Views.UserControls
{
    partial class BasePlatformImagerUC
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
            this.flp_frameDragDrop = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_frameDragDrop
            // 
            this.flp_frameDragDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_frameDragDrop.Location = new System.Drawing.Point(70, 35);
            this.flp_frameDragDrop.Name = "flp_frameDragDrop";
            this.flp_frameDragDrop.Size = new System.Drawing.Size(300, 230);
            this.flp_frameDragDrop.TabIndex = 1;
            this.flp_frameDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_frameDragDrop_Paint);
            // 
            // BasePlatformImagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flp_frameDragDrop);
            this.Location = new System.Drawing.Point(161, 97);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BasePlatformImagerUC";
            this.Padding = new System.Windows.Forms.Padding(70, 35, 0, 70);
            this.Size = new System.Drawing.Size(370, 335);
            this.Load += new System.EventHandler(this.BasePlatformImagerUC_Load);
            this.SizeChanged += new System.EventHandler(this.BasePlatformImagerUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BasePlatformImagerUC_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BasePlatformImagerUC_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_frameDragDrop;
    }
}
