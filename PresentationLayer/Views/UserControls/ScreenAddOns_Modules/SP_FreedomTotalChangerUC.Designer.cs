namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_FreedomTotalChangerUC
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
            this.chkbox_totalChanger = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkbox_totalChanger
            // 
            this.chkbox_totalChanger.AutoSize = true;
            this.chkbox_totalChanger.Location = new System.Drawing.Point(3, 23);
            this.chkbox_totalChanger.Name = "chkbox_totalChanger";
            this.chkbox_totalChanger.Size = new System.Drawing.Size(153, 17);
            this.chkbox_totalChanger.TabIndex = 0;
            this.chkbox_totalChanger.Text = "Use @Net 45 Computation";
            this.chkbox_totalChanger.UseVisualStyleBackColor = true;
            this.chkbox_totalChanger.CheckedChanged += new System.EventHandler(this.chkbox_totalChanger_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Applicable in Revisions";
            this.label1.Visible = false;
            // 
            // SP_FreedomTotalChangerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbox_totalChanger);
            this.Name = "SP_FreedomTotalChangerUC";
            this.Size = new System.Drawing.Size(173, 46);
            this.Load += new System.EventHandler(this.SP_FreedomTotalChangerUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbox_totalChanger;
        private System.Windows.Forms.Label label1;
    }
}
