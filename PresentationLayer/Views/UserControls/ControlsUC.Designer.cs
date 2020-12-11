namespace PresentationLayer.Views.UserControls
{
    partial class ControlsUC
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
            this.lblControlText = new System.Windows.Forms.Label();
            this.pnl_WinDoorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblControlText
            // 
            this.lblControlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblControlText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlText.Location = new System.Drawing.Point(0, 0);
            this.lblControlText.Name = "lblControlText";
            this.lblControlText.Size = new System.Drawing.Size(63, 63);
            this.lblControlText.TabIndex = 3;
            this.lblControlText.Text = "Fixed";
            this.lblControlText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_WinDoorPanel
            // 
            this.pnl_WinDoorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_WinDoorPanel.Location = new System.Drawing.Point(63, 0);
            this.pnl_WinDoorPanel.Name = "pnl_WinDoorPanel";
            this.pnl_WinDoorPanel.Size = new System.Drawing.Size(65, 63);
            this.pnl_WinDoorPanel.TabIndex = 4;
            // 
            // ControlsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblControlText);
            this.Controls.Add(this.pnl_WinDoorPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ControlsUC";
            this.Size = new System.Drawing.Size(128, 63);
            this.Load += new System.EventHandler(this.ControlsUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblControlText;
        private System.Windows.Forms.Panel pnl_WinDoorPanel;
    }
}
