namespace PresentationLayer.Views
{
    partial class ScreenView
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
            this.lbl_ScreenWidth = new System.Windows.Forms.Label();
            this.lbl_ScreenHeight = new System.Windows.Forms.Label();
            this.nud_Width = new System.Windows.Forms.NumericUpDown();
            this.nud_Height = new System.Windows.Forms.NumericUpDown();
            this.cmb_ScreenType = new System.Windows.Forms.ComboBox();
            this.lbl_ScreenType = new System.Windows.Forms.Label();
            this.nud_ScreenPriceWoodgrain = new System.Windows.Forms.NumericUpDown();
            this.nud_ScreenPriceWhite = new System.Windows.Forms.NumericUpDown();
            this.lbl_woodgrainPrice = new System.Windows.Forms.Label();
            this.lbl_whitePrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_addOns = new System.Windows.Forms.Panel();
            this.lbl_addOns = new System.Windows.Forms.Label();
            this.nud_Sets = new System.Windows.Forms.NumericUpDown();
            this.lbl_sets = new System.Windows.Forms.Label();
            this.nud_Factor = new System.Windows.Forms.NumericUpDown();
            this.lbl_Factor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ScreenPriceWoodgrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ScreenPriceWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Factor)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ScreenWidth
            // 
            this.lbl_ScreenWidth.AutoSize = true;
            this.lbl_ScreenWidth.Location = new System.Drawing.Point(13, 85);
            this.lbl_ScreenWidth.Name = "lbl_ScreenWidth";
            this.lbl_ScreenWidth.Size = new System.Drawing.Size(39, 13);
            this.lbl_ScreenWidth.TabIndex = 0;
            this.lbl_ScreenWidth.Text = "Width";
            // 
            // lbl_ScreenHeight
            // 
            this.lbl_ScreenHeight.AutoSize = true;
            this.lbl_ScreenHeight.Location = new System.Drawing.Point(13, 113);
            this.lbl_ScreenHeight.Name = "lbl_ScreenHeight";
            this.lbl_ScreenHeight.Size = new System.Drawing.Size(42, 13);
            this.lbl_ScreenHeight.TabIndex = 1;
            this.lbl_ScreenHeight.Text = "Height";
            // 
            // nud_Width
            // 
            this.nud_Width.Location = new System.Drawing.Point(88, 83);
            this.nud_Width.Name = "nud_Width";
            this.nud_Width.Size = new System.Drawing.Size(103, 22);
            this.nud_Width.TabIndex = 2;
            this.nud_Width.ValueChanged += new System.EventHandler(this.nud_Width_ValueChanged);
            // 
            // nud_Height
            // 
            this.nud_Height.Location = new System.Drawing.Point(88, 111);
            this.nud_Height.Name = "nud_Height";
            this.nud_Height.Size = new System.Drawing.Size(103, 22);
            this.nud_Height.TabIndex = 3;
            this.nud_Height.ValueChanged += new System.EventHandler(this.nud_Height_ValueChanged);
            // 
            // cmb_ScreenType
            // 
            this.cmb_ScreenType.FormattingEnabled = true;
            this.cmb_ScreenType.Location = new System.Drawing.Point(88, 12);
            this.cmb_ScreenType.Name = "cmb_ScreenType";
            this.cmb_ScreenType.Size = new System.Drawing.Size(103, 21);
            this.cmb_ScreenType.TabIndex = 4;
            this.cmb_ScreenType.SelectedValueChanged += new System.EventHandler(this.cmb_ScreenType_SelectedValueChanged);
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Location = new System.Drawing.Point(12, 15);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(67, 13);
            this.lbl_ScreenType.TabIndex = 5;
            this.lbl_ScreenType.Text = "Screen Type";
            // 
            // nud_ScreenPriceWoodgrain
            // 
            this.nud_ScreenPriceWoodgrain.Enabled = false;
            this.nud_ScreenPriceWoodgrain.Location = new System.Drawing.Point(88, 207);
            this.nud_ScreenPriceWoodgrain.Name = "nud_ScreenPriceWoodgrain";
            this.nud_ScreenPriceWoodgrain.Size = new System.Drawing.Size(103, 22);
            this.nud_ScreenPriceWoodgrain.TabIndex = 9;
            // 
            // nud_ScreenPriceWhite
            // 
            this.nud_ScreenPriceWhite.Enabled = false;
            this.nud_ScreenPriceWhite.Location = new System.Drawing.Point(88, 179);
            this.nud_ScreenPriceWhite.Name = "nud_ScreenPriceWhite";
            this.nud_ScreenPriceWhite.Size = new System.Drawing.Size(103, 22);
            this.nud_ScreenPriceWhite.TabIndex = 8;
            // 
            // lbl_woodgrainPrice
            // 
            this.lbl_woodgrainPrice.AutoSize = true;
            this.lbl_woodgrainPrice.Location = new System.Drawing.Point(13, 209);
            this.lbl_woodgrainPrice.Name = "lbl_woodgrainPrice";
            this.lbl_woodgrainPrice.Size = new System.Drawing.Size(66, 13);
            this.lbl_woodgrainPrice.TabIndex = 7;
            this.lbl_woodgrainPrice.Text = "Woodgrain";
            // 
            // lbl_whitePrice
            // 
            this.lbl_whitePrice.AutoSize = true;
            this.lbl_whitePrice.Location = new System.Drawing.Point(13, 181);
            this.lbl_whitePrice.Name = "lbl_whitePrice";
            this.lbl_whitePrice.Size = new System.Drawing.Size(72, 13);
            this.lbl_whitePrice.TabIndex = 6;
            this.lbl_whitePrice.Text = "White / Ivory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "_______________________________________";
            // 
            // pnl_addOns
            // 
            this.pnl_addOns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_addOns.Location = new System.Drawing.Point(0, 270);
            this.pnl_addOns.Name = "pnl_addOns";
            this.pnl_addOns.Size = new System.Drawing.Size(205, 86);
            this.pnl_addOns.TabIndex = 11;
            // 
            // lbl_addOns
            // 
            this.lbl_addOns.AutoSize = true;
            this.lbl_addOns.Location = new System.Drawing.Point(5, 254);
            this.lbl_addOns.Name = "lbl_addOns";
            this.lbl_addOns.Size = new System.Drawing.Size(50, 13);
            this.lbl_addOns.TabIndex = 8;
            this.lbl_addOns.Text = "Add ons";
            // 
            // nud_Sets
            // 
            this.nud_Sets.Location = new System.Drawing.Point(88, 39);
            this.nud_Sets.Name = "nud_Sets";
            this.nud_Sets.Size = new System.Drawing.Size(103, 22);
            this.nud_Sets.TabIndex = 13;
            // 
            // lbl_sets
            // 
            this.lbl_sets.AutoSize = true;
            this.lbl_sets.Location = new System.Drawing.Point(16, 41);
            this.lbl_sets.Name = "lbl_sets";
            this.lbl_sets.Size = new System.Drawing.Size(49, 13);
            this.lbl_sets.TabIndex = 12;
            this.lbl_sets.Text = "No. Sets";
            // 
            // nud_Factor
            // 
            this.nud_Factor.Location = new System.Drawing.Point(88, 139);
            this.nud_Factor.Name = "nud_Factor";
            this.nud_Factor.Size = new System.Drawing.Size(103, 22);
            this.nud_Factor.TabIndex = 15;
            this.nud_Factor.ValueChanged += new System.EventHandler(this.nud_Factor_ValueChanged);
            // 
            // lbl_Factor
            // 
            this.lbl_Factor.AutoSize = true;
            this.lbl_Factor.Location = new System.Drawing.Point(13, 141);
            this.lbl_Factor.Name = "lbl_Factor";
            this.lbl_Factor.Size = new System.Drawing.Size(39, 13);
            this.lbl_Factor.TabIndex = 14;
            this.lbl_Factor.Text = "Factor";
            // 
            // ScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 356);
            this.Controls.Add(this.lbl_addOns);
            this.Controls.Add(this.nud_Factor);
            this.Controls.Add(this.lbl_Factor);
            this.Controls.Add(this.nud_Sets);
            this.Controls.Add(this.lbl_sets);
            this.Controls.Add(this.pnl_addOns);
            this.Controls.Add(this.nud_ScreenPriceWoodgrain);
            this.Controls.Add(this.nud_ScreenPriceWhite);
            this.Controls.Add(this.lbl_woodgrainPrice);
            this.Controls.Add(this.lbl_whitePrice);
            this.Controls.Add(this.lbl_ScreenType);
            this.Controls.Add(this.cmb_ScreenType);
            this.Controls.Add(this.nud_Height);
            this.Controls.Add(this.nud_Width);
            this.Controls.Add(this.lbl_ScreenHeight);
            this.Controls.Add(this.lbl_ScreenWidth);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScreenView";
            this.Text = "Screen";
            this.Load += new System.EventHandler(this.ScreenView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ScreenPriceWoodgrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ScreenPriceWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Factor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ScreenWidth;
        private System.Windows.Forms.Label lbl_ScreenHeight;
        private System.Windows.Forms.NumericUpDown nud_Width;
        private System.Windows.Forms.NumericUpDown nud_Height;
        private System.Windows.Forms.ComboBox cmb_ScreenType;
        private System.Windows.Forms.Label lbl_ScreenType;
        private System.Windows.Forms.NumericUpDown nud_ScreenPriceWoodgrain;
        private System.Windows.Forms.NumericUpDown nud_ScreenPriceWhite;
        private System.Windows.Forms.Label lbl_woodgrainPrice;
        private System.Windows.Forms.Label lbl_whitePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_addOns;
        private System.Windows.Forms.Label lbl_addOns;
        private System.Windows.Forms.NumericUpDown nud_Sets;
        private System.Windows.Forms.Label lbl_sets;
        private System.Windows.Forms.NumericUpDown nud_Factor;
        private System.Windows.Forms.Label lbl_Factor;
    }
}