namespace PresentationLayer.Views.UserControls
{
    partial class SP_SpringLoadedUC
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
            this.springLoadedpnl = new System.Windows.Forms.Panel();
            this.springloadedchkbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.springLoadedpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // springLoadedpnl
            // 
            this.springLoadedpnl.Controls.Add(this.springloadedchkbox);
            this.springLoadedpnl.Controls.Add(this.label1);
            this.springLoadedpnl.Location = new System.Drawing.Point(0, 0);
            this.springLoadedpnl.Name = "springLoadedpnl";
            this.springLoadedpnl.Size = new System.Drawing.Size(227, 27);
            this.springLoadedpnl.TabIndex = 0;
            // 
            // springloadedchkbox
            // 
            this.springloadedchkbox.AutoSize = true;
            this.springloadedchkbox.Location = new System.Drawing.Point(89, 8);
            this.springloadedchkbox.Name = "springloadedchkbox";
            this.springloadedchkbox.Size = new System.Drawing.Size(15, 14);
            this.springloadedchkbox.TabIndex = 1;
            this.springloadedchkbox.UseVisualStyleBackColor = true;
            this.springloadedchkbox.CheckedChanged += new System.EventHandler(this.springloadedchkbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spring Loaded";
            // 
            // SP_SpringLoadedUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.springLoadedpnl);
            this.Name = "SP_SpringLoadedUC";
            this.Size = new System.Drawing.Size(227, 30);
            this.Load += new System.EventHandler(this.SP_SpringLoadedUC_Load);
            this.springLoadedpnl.ResumeLayout(false);
            this.springLoadedpnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel springLoadedpnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox springloadedchkbox;
    }
}
