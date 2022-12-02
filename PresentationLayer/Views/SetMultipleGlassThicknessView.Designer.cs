namespace PresentationLayer.Views
{
    partial class SetMultipleGlassThicknessView
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
            this.setGlssThckNssDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_GlassType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.setGlssThckNssDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // setGlssThckNssDGV
            // 
            this.setGlssThckNssDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.setGlssThckNssDGV.Location = new System.Drawing.Point(3, 49);
            this.setGlssThckNssDGV.Name = "setGlssThckNssDGV";
            this.setGlssThckNssDGV.Size = new System.Drawing.Size(559, 309);
            this.setGlssThckNssDGV.TabIndex = 0;
            this.setGlssThckNssDGV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setGlssThckNssDGV_MouseClick);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Glass Type";
            // 
            // cmb_GlassType
            // 
            this.cmb_GlassType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_GlassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlassType.DropDownWidth = 100;
            this.cmb_GlassType.FormattingEnabled = true;
            this.cmb_GlassType.Location = new System.Drawing.Point(12, 9);
            this.cmb_GlassType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_GlassType.Name = "cmb_GlassType";
            this.cmb_GlassType.Size = new System.Drawing.Size(72, 21);
            this.cmb_GlassType.TabIndex = 34;
            this.cmb_GlassType.SelectedValueChanged += new System.EventHandler(this.cmb_GlassType_SelectedValueChanged);
            // 
            // SetMultipleGlassThicknessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 362);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_GlassType);
            this.Controls.Add(this.setGlssThckNssDGV);
            this.Name = "SetMultipleGlassThicknessView";
            this.Text = "SetMultipleGlassThicknessView";
            this.Load += new System.EventHandler(this.SetMultipleGlassThicknessView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setGlssThckNssDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView setGlssThckNssDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_GlassType;
    }
}