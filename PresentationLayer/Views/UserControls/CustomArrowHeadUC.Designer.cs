namespace PresentationLayer.Views.UserControls
{
    partial class CustomArrowHeadUC
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
            this.lbl_ArrowHead = new System.Windows.Forms.Label();
            this.nud_ArrowSize = new System.Windows.Forms.NumericUpDown();
            this.btn_DeleteArrowHead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ArrowSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ArrowHead
            // 
            this.lbl_ArrowHead.AutoSize = true;
            this.lbl_ArrowHead.Location = new System.Drawing.Point(3, 5);
            this.lbl_ArrowHead.Name = "lbl_ArrowHead";
            this.lbl_ArrowHead.Size = new System.Drawing.Size(35, 13);
            this.lbl_ArrowHead.TabIndex = 0;
            this.lbl_ArrowHead.Text = "Width";
            // 
            // nud_ArrowSize
            // 
            this.nud_ArrowSize.Location = new System.Drawing.Point(44, 2);
            this.nud_ArrowSize.Name = "nud_ArrowSize";
            this.nud_ArrowSize.Size = new System.Drawing.Size(76, 20);
            this.nud_ArrowSize.TabIndex = 1;
            this.nud_ArrowSize.ValueChanged += new System.EventHandler(this.nud_ArrowSize_ValueChanged);
            // 
            // btn_DeleteArrowHead
            // 
            this.btn_DeleteArrowHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DeleteArrowHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteArrowHead.FlatAppearance.BorderSize = 0;
            this.btn_DeleteArrowHead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_DeleteArrowHead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_DeleteArrowHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteArrowHead.Location = new System.Drawing.Point(123, 0);
            this.btn_DeleteArrowHead.Name = "btn_DeleteArrowHead";
            this.btn_DeleteArrowHead.Size = new System.Drawing.Size(23, 23);
            this.btn_DeleteArrowHead.TabIndex = 20;
            this.btn_DeleteArrowHead.Text = "X";
            this.btn_DeleteArrowHead.UseVisualStyleBackColor = true;
            this.btn_DeleteArrowHead.Click += new System.EventHandler(this.btn_DeleteArrowHead_Click);
            // 
            // CustomArrowHeadUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_DeleteArrowHead);
            this.Controls.Add(this.nud_ArrowSize);
            this.Controls.Add(this.lbl_ArrowHead);
            this.Name = "CustomArrowHeadUC";
            this.Size = new System.Drawing.Size(150, 25);
            ((System.ComponentModel.ISupportInitialize)(this.nud_ArrowSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ArrowHead;
        private System.Windows.Forms.NumericUpDown nud_ArrowSize;
        private System.Windows.Forms.Button btn_DeleteArrowHead;
    }
}
