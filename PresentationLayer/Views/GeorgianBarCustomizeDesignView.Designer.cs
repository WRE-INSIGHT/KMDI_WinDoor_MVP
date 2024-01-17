namespace PresentationLayer.Views
{
    partial class GeorgianBarCustomizeDesignView
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
            this.components = new System.ComponentModel.Container();
            this.FormTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FormTimer
            // 
            this.FormTimer.Enabled = true;
            this.FormTimer.Interval = 20;
            this.FormTimer.Tick += new System.EventHandler(this.FormTimerTickEvent);
            // 
            // GeorgianBarCustomizeDesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(824, 437);
            this.DoubleBuffered = true;
            this.Name = "GeorgianBarCustomizeDesignView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Georgian Bar";
            this.Load += new System.EventHandler(this.GeorgianBarCustomizeDesignView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GeorgianBarCustomizeDesignView_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GeorgianBarCustomizeDesignView_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeorgianBarCustomizeDesignView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GeorgianBarCustomizeDesignView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeorgianBarCustomizeDesignView_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer FormTimer;
    }
}