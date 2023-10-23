namespace PresentationLayer.Views.UserControls
{
    partial class PartialAdjustmenItemDisabledUC
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
            this.lbl_doneEditing = new System.Windows.Forms.Label();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.pnl_BtnHolder = new System.Windows.Forms.Panel();
            this.pnl_BtnHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_doneEditing
            // 
            this.lbl_doneEditing.AutoSize = true;
            this.lbl_doneEditing.Location = new System.Drawing.Point(49, 18);
            this.lbl_doneEditing.Name = "lbl_doneEditing";
            this.lbl_doneEditing.Size = new System.Drawing.Size(74, 13);
            this.lbl_doneEditing.TabIndex = 0;
            this.lbl_doneEditing.Text = "Done Editing?";
            // 
            // btn_Yes
            // 
            this.btn_Yes.Location = new System.Drawing.Point(13, 42);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(65, 23);
            this.btn_Yes.TabIndex = 1;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(85, 42);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(65, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // pnl_BtnHolder
            // 
            this.pnl_BtnHolder.Controls.Add(this.lbl_doneEditing);
            this.pnl_BtnHolder.Controls.Add(this.btn_Cancel);
            this.pnl_BtnHolder.Controls.Add(this.btn_Yes);
            this.pnl_BtnHolder.Location = new System.Drawing.Point(0, 64);
            this.pnl_BtnHolder.Name = "pnl_BtnHolder";
            this.pnl_BtnHolder.Size = new System.Drawing.Size(166, 85);
            this.pnl_BtnHolder.TabIndex = 3;
            // 
            // PartialAdjustmenItemDisabledUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnl_BtnHolder);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "PartialAdjustmenItemDisabledUC";
            this.Size = new System.Drawing.Size(166, 200);
            this.Load += new System.EventHandler(this.PartialAdjustmenItemDisabledUC_Load);
            this.Resize += new System.EventHandler(this.PartialAdjustmenItemDisabledUC_Resize);
            this.pnl_BtnHolder.ResumeLayout(false);
            this.pnl_BtnHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_doneEditing;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Panel pnl_BtnHolder;
    }
}
