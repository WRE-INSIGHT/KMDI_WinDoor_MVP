﻿namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class FixedPanelUC
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
            this.lbl_Fixed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Fixed
            // 
            this.lbl_Fixed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Fixed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Fixed.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fixed.Location = new System.Drawing.Point(5, 5);
            this.lbl_Fixed.Name = "lbl_Fixed";
            this.lbl_Fixed.Size = new System.Drawing.Size(138, 138);
            this.lbl_Fixed.TabIndex = 0;
            this.lbl_Fixed.Text = "F";
            this.lbl_Fixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FixedPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_Fixed);
            this.Name = "FixedPanelUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Fixed;
    }
}
