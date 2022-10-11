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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_Screen = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nud_Quantity = new System.Windows.Forms.NumericUpDown();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.txt_windoorID = new System.Windows.Forms.TextBox();
            this.lbl_WindoorID = new System.Windows.Forms.Label();
            this.nud_Sets = new System.Windows.Forms.NumericUpDown();
            this.lbl_sets = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_color = new System.Windows.Forms.Label();
            this.cmb_baseColor = new System.Windows.Forms.ComboBox();
            this.lbl_addOns = new System.Windows.Forms.Label();
            this.nud_Factor = new System.Windows.Forms.NumericUpDown();
            this.lbl_Factor = new System.Windows.Forms.Label();
            this.pnl_addOns = new System.Windows.Forms.Panel();
            this.nud_TotalPrice = new System.Windows.Forms.NumericUpDown();
            this.lbl_whitePrice = new System.Windows.Forms.Label();
            this.lbl_ScreenType = new System.Windows.Forms.Label();
            this.cmb_ScreenType = new System.Windows.Forms.ComboBox();
            this.nud_Height = new System.Windows.Forms.NumericUpDown();
            this.nud_Width = new System.Windows.Forms.NumericUpDown();
            this.lbl_ScreenHeight = new System.Windows.Forms.Label();
            this.lbl_ScreenWidth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tsScreen = new System.Windows.Forms.ToolStrip();
            this.tsBtnPrintScreen = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Screen)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Factor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).BeginInit();
            this.tsScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.tsScreen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 356);
            this.panel2.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_Screen);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(219, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(483, 329);
            this.panel4.TabIndex = 41;
            // 
            // dgv_Screen
            // 
            this.dgv_Screen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Screen.Location = new System.Drawing.Point(0, 37);
            this.dgv_Screen.Name = "dgv_Screen";
            this.dgv_Screen.Size = new System.Drawing.Size(483, 292);
            this.dgv_Screen.TabIndex = 30;
            this.dgv_Screen.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Screen_RowPostPaint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nud_Quantity);
            this.panel3.Controls.Add(this.lbl_Quantity);
            this.panel3.Controls.Add(this.txt_windoorID);
            this.panel3.Controls.Add(this.lbl_WindoorID);
            this.panel3.Controls.Add(this.nud_Sets);
            this.panel3.Controls.Add(this.lbl_sets);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(483, 37);
            this.panel3.TabIndex = 29;
            // 
            // nud_Quantity
            // 
            this.nud_Quantity.Location = new System.Drawing.Point(391, 7);
            this.nud_Quantity.Name = "nud_Quantity";
            this.nud_Quantity.Size = new System.Drawing.Size(50, 22);
            this.nud_Quantity.TabIndex = 9;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(334, 12);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(51, 13);
            this.lbl_Quantity.TabIndex = 38;
            this.lbl_Quantity.Text = "Quantity";
            // 
            // txt_windoorID
            // 
            this.txt_windoorID.Location = new System.Drawing.Point(218, 6);
            this.txt_windoorID.Name = "txt_windoorID";
            this.txt_windoorID.Size = new System.Drawing.Size(100, 22);
            this.txt_windoorID.TabIndex = 8;
            // 
            // lbl_WindoorID
            // 
            this.lbl_WindoorID.AutoSize = true;
            this.lbl_WindoorID.Location = new System.Drawing.Point(145, 11);
            this.lbl_WindoorID.Name = "lbl_WindoorID";
            this.lbl_WindoorID.Size = new System.Drawing.Size(67, 13);
            this.lbl_WindoorID.TabIndex = 35;
            this.lbl_WindoorID.Text = "Windoor ID";
            // 
            // nud_Sets
            // 
            this.nud_Sets.Location = new System.Drawing.Point(78, 6);
            this.nud_Sets.Name = "nud_Sets";
            this.nud_Sets.Size = new System.Drawing.Size(50, 22);
            this.nud_Sets.TabIndex = 7;
            // 
            // lbl_sets
            // 
            this.lbl_sets.AutoSize = true;
            this.lbl_sets.Location = new System.Drawing.Point(23, 11);
            this.lbl_sets.Name = "lbl_sets";
            this.lbl_sets.Size = new System.Drawing.Size(49, 13);
            this.lbl_sets.TabIndex = 29;
            this.lbl_sets.Text = "No. Sets";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.lbl_color);
            this.panel1.Controls.Add(this.cmb_baseColor);
            this.panel1.Controls.Add(this.lbl_addOns);
            this.panel1.Controls.Add(this.nud_Factor);
            this.panel1.Controls.Add(this.lbl_Factor);
            this.panel1.Controls.Add(this.pnl_addOns);
            this.panel1.Controls.Add(this.nud_TotalPrice);
            this.panel1.Controls.Add(this.lbl_whitePrice);
            this.panel1.Controls.Add(this.lbl_ScreenType);
            this.panel1.Controls.Add(this.cmb_ScreenType);
            this.panel1.Controls.Add(this.nud_Height);
            this.panel1.Controls.Add(this.nud_Width);
            this.panel1.Controls.Add(this.lbl_ScreenHeight);
            this.panel1.Controls.Add(this.lbl_ScreenWidth);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 329);
            this.panel1.TabIndex = 31;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(56, 214);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(98, 26);
            this.btn_add.TabIndex = 35;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_color
            // 
            this.lbl_color.AutoSize = true;
            this.lbl_color.Location = new System.Drawing.Point(8, 36);
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(61, 13);
            this.lbl_color.TabIndex = 34;
            this.lbl_color.Text = "Base Color";
            // 
            // cmb_baseColor
            // 
            this.cmb_baseColor.FormattingEnabled = true;
            this.cmb_baseColor.Location = new System.Drawing.Point(84, 33);
            this.cmb_baseColor.Name = "cmb_baseColor";
            this.cmb_baseColor.Size = new System.Drawing.Size(117, 21);
            this.cmb_baseColor.TabIndex = 2;
            this.cmb_baseColor.SelectedValueChanged += new System.EventHandler(this.cmb_baseColor_SelectedValueChanged);
            // 
            // lbl_addOns
            // 
            this.lbl_addOns.AutoSize = true;
            this.lbl_addOns.Location = new System.Drawing.Point(1, 248);
            this.lbl_addOns.Name = "lbl_addOns";
            this.lbl_addOns.Size = new System.Drawing.Size(50, 13);
            this.lbl_addOns.TabIndex = 26;
            this.lbl_addOns.Text = "Add ons";
            // 
            // nud_Factor
            // 
            this.nud_Factor.Location = new System.Drawing.Point(86, 133);
            this.nud_Factor.Name = "nud_Factor";
            this.nud_Factor.Size = new System.Drawing.Size(117, 22);
            this.nud_Factor.TabIndex = 6;
            this.nud_Factor.ValueChanged += new System.EventHandler(this.nud_Factor_ValueChanged);
            // 
            // lbl_Factor
            // 
            this.lbl_Factor.AutoSize = true;
            this.lbl_Factor.Location = new System.Drawing.Point(11, 135);
            this.lbl_Factor.Name = "lbl_Factor";
            this.lbl_Factor.Size = new System.Drawing.Size(39, 13);
            this.lbl_Factor.TabIndex = 31;
            this.lbl_Factor.Text = "Factor";
            // 
            // pnl_addOns
            // 
            this.pnl_addOns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_addOns.Location = new System.Drawing.Point(0, 243);
            this.pnl_addOns.Name = "pnl_addOns";
            this.pnl_addOns.Size = new System.Drawing.Size(219, 86);
            this.pnl_addOns.TabIndex = 28;
            // 
            // nud_TotalPrice
            // 
            this.nud_TotalPrice.Enabled = false;
            this.nud_TotalPrice.Location = new System.Drawing.Point(86, 173);
            this.nud_TotalPrice.Name = "nud_TotalPrice";
            this.nud_TotalPrice.Size = new System.Drawing.Size(117, 22);
            this.nud_TotalPrice.TabIndex = 25;
            // 
            // lbl_whitePrice
            // 
            this.lbl_whitePrice.AutoSize = true;
            this.lbl_whitePrice.Location = new System.Drawing.Point(11, 175);
            this.lbl_whitePrice.Name = "lbl_whitePrice";
            this.lbl_whitePrice.Size = new System.Drawing.Size(32, 13);
            this.lbl_whitePrice.TabIndex = 24;
            this.lbl_whitePrice.Text = "Total";
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Location = new System.Drawing.Point(8, 9);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(67, 13);
            this.lbl_ScreenType.TabIndex = 23;
            this.lbl_ScreenType.Text = "Screen Type";
            // 
            // cmb_ScreenType
            // 
            this.cmb_ScreenType.FormattingEnabled = true;
            this.cmb_ScreenType.Location = new System.Drawing.Point(84, 6);
            this.cmb_ScreenType.Name = "cmb_ScreenType";
            this.cmb_ScreenType.Size = new System.Drawing.Size(117, 21);
            this.cmb_ScreenType.TabIndex = 1;
            // 
            // nud_Height
            // 
            this.nud_Height.Location = new System.Drawing.Point(86, 105);
            this.nud_Height.Name = "nud_Height";
            this.nud_Height.Size = new System.Drawing.Size(117, 22);
            this.nud_Height.TabIndex = 5;
            this.nud_Height.ValueChanged += new System.EventHandler(this.nud_Height_ValueChanged);
            // 
            // nud_Width
            // 
            this.nud_Width.Location = new System.Drawing.Point(86, 77);
            this.nud_Width.Name = "nud_Width";
            this.nud_Width.Size = new System.Drawing.Size(117, 22);
            this.nud_Width.TabIndex = 4;
            this.nud_Width.ValueChanged += new System.EventHandler(this.nud_Width_ValueChanged);
            // 
            // lbl_ScreenHeight
            // 
            this.lbl_ScreenHeight.AutoSize = true;
            this.lbl_ScreenHeight.Location = new System.Drawing.Point(11, 107);
            this.lbl_ScreenHeight.Name = "lbl_ScreenHeight";
            this.lbl_ScreenHeight.Size = new System.Drawing.Size(42, 13);
            this.lbl_ScreenHeight.TabIndex = 19;
            this.lbl_ScreenHeight.Text = "Height";
            // 
            // lbl_ScreenWidth
            // 
            this.lbl_ScreenWidth.AutoSize = true;
            this.lbl_ScreenWidth.Location = new System.Drawing.Point(11, 79);
            this.lbl_ScreenWidth.Name = "lbl_ScreenWidth";
            this.lbl_ScreenWidth.Size = new System.Drawing.Size(39, 13);
            this.lbl_ScreenWidth.TabIndex = 18;
            this.lbl_ScreenWidth.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "__________________________________________";
            // 
            // tsScreen
            // 
            this.tsScreen.AutoSize = false;
            this.tsScreen.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsScreen.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsScreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnPrintScreen});
            this.tsScreen.Location = new System.Drawing.Point(0, 0);
            this.tsScreen.Name = "tsScreen";
            this.tsScreen.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsScreen.Size = new System.Drawing.Size(702, 27);
            this.tsScreen.TabIndex = 40;
            this.tsScreen.Text = "toolStrip1";
            // 
            // tsBtnPrintScreen
            // 
            this.tsBtnPrintScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrintScreen.Enabled = false;
            this.tsBtnPrintScreen.Image = global::PresentationLayer.Properties.Resources.print;
            this.tsBtnPrintScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrintScreen.Name = "tsBtnPrintScreen";
            this.tsBtnPrintScreen.Size = new System.Drawing.Size(24, 24);
            this.tsBtnPrintScreen.Text = "Print Screen";
            // 
            // ScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 356);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScreenView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen";
            this.Load += new System.EventHandler(this.ScreenView_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Screen)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Factor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).EndInit();
            this.tsScreen.ResumeLayout(false);
            this.tsScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_Screen;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nud_Quantity;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.TextBox txt_windoorID;
        private System.Windows.Forms.Label lbl_WindoorID;
        private System.Windows.Forms.NumericUpDown nud_Sets;
        private System.Windows.Forms.Label lbl_sets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_color;
        private System.Windows.Forms.ComboBox cmb_baseColor;
        private System.Windows.Forms.Label lbl_addOns;
        private System.Windows.Forms.NumericUpDown nud_Factor;
        private System.Windows.Forms.Label lbl_Factor;
        private System.Windows.Forms.Panel pnl_addOns;
        private System.Windows.Forms.NumericUpDown nud_TotalPrice;
        private System.Windows.Forms.Label lbl_whitePrice;
        private System.Windows.Forms.Label lbl_ScreenType;
        private System.Windows.Forms.ComboBox cmb_ScreenType;
        private System.Windows.Forms.NumericUpDown nud_Height;
        private System.Windows.Forms.NumericUpDown nud_Width;
        private System.Windows.Forms.Label lbl_ScreenHeight;
        private System.Windows.Forms.Label lbl_ScreenWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip tsScreen;
        private System.Windows.Forms.ToolStripButton tsBtnPrintScreen;
    }
}