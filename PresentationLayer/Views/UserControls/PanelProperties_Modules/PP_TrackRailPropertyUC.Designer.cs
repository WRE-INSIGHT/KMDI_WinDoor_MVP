namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_TrackRailPropertyUC
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
            this.cmb_TrackRailArtNo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_TrackRailArtNo
            // 
            this.cmb_TrackRailArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_TrackRailArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TrackRailArtNo.FormattingEnabled = true;
            this.cmb_TrackRailArtNo.Location = new System.Drawing.Point(62, 5);
            this.cmb_TrackRailArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_TrackRailArtNo.Name = "cmb_TrackRailArtNo";
            this.cmb_TrackRailArtNo.Size = new System.Drawing.Size(87, 21);
            this.cmb_TrackRailArtNo.TabIndex = 38;
            this.cmb_TrackRailArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_TrackRailArtNo_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-3, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(79, 31);
            this.label12.TabIndex = 37;
            this.label12.Text = "Track Rail\r\nArt No.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PP_TrackRailPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_TrackRailArtNo);
            this.Controls.Add(this.label12);
            this.Name = "PP_TrackRailPropertyUC";
            this.Size = new System.Drawing.Size(150, 30);
            this.Load += new System.EventHandler(this.PP_TrackRailPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_TrackRailArtNo;
        private System.Windows.Forms.Label label12;
    }
}
