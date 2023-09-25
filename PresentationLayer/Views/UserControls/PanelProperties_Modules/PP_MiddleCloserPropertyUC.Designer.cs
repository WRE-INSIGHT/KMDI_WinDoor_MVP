namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_MiddleCloserPropertyUC
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
            this.cmb_MiddleCLoser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_MCPairQty = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_MCPairQty)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_MiddleCLoser
            // 
            this.cmb_MiddleCLoser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_MiddleCLoser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MiddleCLoser.DropDownWidth = 69;
            this.cmb_MiddleCLoser.FormattingEnabled = true;
            this.cmb_MiddleCLoser.Location = new System.Drawing.Point(78, 2);
            this.cmb_MiddleCLoser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_MiddleCLoser.Name = "cmb_MiddleCLoser";
            this.cmb_MiddleCLoser.Size = new System.Drawing.Size(75, 21);
            this.cmb_MiddleCLoser.TabIndex = 39;
            this.cmb_MiddleCLoser.SelectedValueChanged += new System.EventHandler(this.cmb_MiddleCLoser_SelectedValueChanged);
            this.cmb_MiddleCLoser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_MiddleCLoser_KeyPress);
            this.cmb_MiddleCLoser.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_MiddleCLoser_MouseWheel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Middle Closer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "MC Pair Qty";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // num_MCPairQty
            // 
            this.num_MCPairQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_MCPairQty.Location = new System.Drawing.Point(79, 26);
            this.num_MCPairQty.Name = "num_MCPairQty";
            this.num_MCPairQty.Size = new System.Drawing.Size(75, 22);
            this.num_MCPairQty.TabIndex = 41;
            this.num_MCPairQty.ValueChanged += new System.EventHandler(this.num_MCPairQty_ValueChanged);
            this.num_MCPairQty.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.num_MCPairQty_MouseWheel);
            // 
            // PP_MiddleCloserPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.num_MCPairQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_MiddleCLoser);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PP_MiddleCloserPropertyUC";
            this.Size = new System.Drawing.Size(154, 50);
            this.Load += new System.EventHandler(this.PP_MiddleCloserPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_MCPairQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_MiddleCLoser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_MCPairQty;
    }
}
