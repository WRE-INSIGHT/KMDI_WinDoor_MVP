namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RotaryPropertyUC
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
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_RotaryArtNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_LockingKit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Article No.";
            // 
            // cmb_RotaryArtNo
            // 
            this.cmb_RotaryArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RotaryArtNo.FormattingEnabled = true;
            this.cmb_RotaryArtNo.Location = new System.Drawing.Point(76, 3);
            this.cmb_RotaryArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_RotaryArtNo.Name = "cmb_RotaryArtNo";
            this.cmb_RotaryArtNo.Size = new System.Drawing.Size(71, 21);
            this.cmb_RotaryArtNo.TabIndex = 30;
            this.cmb_RotaryArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_RotaryArtNo_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoEllipsis = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 29);
            this.label11.TabIndex = 27;
            this.label11.Text = "Locking Kit";
            // 
            // cmb_LockingKit
            // 
            this.cmb_LockingKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LockingKit.FormattingEnabled = true;
            this.cmb_LockingKit.Location = new System.Drawing.Point(76, 30);
            this.cmb_LockingKit.Name = "cmb_LockingKit";
            this.cmb_LockingKit.Size = new System.Drawing.Size(69, 21);
            this.cmb_LockingKit.TabIndex = 28;
            this.cmb_LockingKit.SelectedValueChanged += new System.EventHandler(this.cmb_LockingKit_SelectedValueChanged);
            // 
            // PP_RotaryPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmb_RotaryArtNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmb_LockingKit);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_RotaryPropertyUC";
            this.Size = new System.Drawing.Size(154, 56);
            this.Load += new System.EventHandler(this.PP_RotaryPropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_RotaryArtNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_LockingKit;
    }
}
