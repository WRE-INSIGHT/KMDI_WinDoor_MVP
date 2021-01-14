namespace PresentationLayer.Tests
{
    partial class frmDividerTesting
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_frame = new System.Windows.Forms.Panel();
            this.pnl_inner = new System.Windows.Forms.Panel();
            this.pnl_frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_frame
            // 
            this.pnl_frame.Controls.Add(this.pnl_inner);
            this.pnl_frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_frame.Location = new System.Drawing.Point(30, 30);
            this.pnl_frame.Name = "pnl_frame";
            this.pnl_frame.Padding = new System.Windows.Forms.Padding(26);
            this.pnl_frame.Size = new System.Drawing.Size(224, 201);
            this.pnl_frame.TabIndex = 0;
            this.pnl_frame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_frame_Paint);
            // 
            // pnl_inner
            // 
            this.pnl_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_inner.Location = new System.Drawing.Point(26, 26);
            this.pnl_inner.Name = "pnl_inner";
            this.pnl_inner.Size = new System.Drawing.Size(172, 149);
            this.pnl_inner.TabIndex = 0;
            this.pnl_inner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_inner_Paint);
            // 
            // frmDividerTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnl_frame);
            this.Name = "frmDividerTesting";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "frmDividerTesting";
            this.SizeChanged += new System.EventHandler(this.frmDividerTesting_SizeChanged);
            this.pnl_frame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_frame;
        private System.Windows.Forms.Panel pnl_inner;
    }
}