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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_Screen = new System.Windows.Forms.DataGridView();
            this.cmsScreen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nud_Quantity = new System.Windows.Forms.NumericUpDown();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.txt_windoorID = new System.Windows.Forms.TextBox();
            this.lbl_WindoorID = new System.Windows.Forms.Label();
            this.nud_Sets = new System.Windows.Forms.NumericUpDown();
            this.lbl_sets = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_addOns = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Plissé = new System.Windows.Forms.Label();
            this.cmb_PlisséType = new System.Windows.Forms.ComboBox();
            this.rdBtn_Door = new System.Windows.Forms.RadioButton();
            this.rdBtn_Window = new System.Windows.Forms.RadioButton();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_color = new System.Windows.Forms.Label();
            this.cmb_baseColor = new System.Windows.Forms.ComboBox();
            this.nud_Factor = new System.Windows.Forms.NumericUpDown();
            this.lbl_Factor = new System.Windows.Forms.Label();
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
            this.tsBtnExchangeRate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrintScreen = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Screen)).BeginInit();
            this.cmsScreen.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(702, 458);
            this.panel2.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_Screen);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(227, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(475, 431);
            this.panel4.TabIndex = 41;
            // 
            // dgv_Screen
            // 
            this.dgv_Screen.AllowUserToAddRows = false;
            this.dgv_Screen.AllowUserToDeleteRows = false;
            this.dgv_Screen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Screen.ContextMenuStrip = this.cmsScreen;
            this.dgv_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Screen.Location = new System.Drawing.Point(0, 37);
            this.dgv_Screen.Name = "dgv_Screen";
            this.dgv_Screen.ReadOnly = true;
            this.dgv_Screen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Screen.Size = new System.Drawing.Size(475, 394);
            this.dgv_Screen.TabIndex = 30;
            this.dgv_Screen.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Screen_RowPostPaint);
            // 
            // cmsScreen
            // 
            this.cmsScreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsScreen.Name = "cmsScreen";
            this.cmsScreen.Size = new System.Drawing.Size(107, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.panel3.Size = new System.Drawing.Size(475, 37);
            this.panel3.TabIndex = 29;
            // 
            // nud_Quantity
            // 
            this.nud_Quantity.Location = new System.Drawing.Point(391, 7);
            this.nud_Quantity.Name = "nud_Quantity";
            this.nud_Quantity.Size = new System.Drawing.Size(50, 22);
            this.nud_Quantity.TabIndex = 8;
            this.nud_Quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Quantity.ValueChanged += new System.EventHandler(this.nud_Quantity_ValueChanged);
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
            this.txt_windoorID.TabIndex = 7;
            this.txt_windoorID.TextChanged += new System.EventHandler(this.txt_windoorID_TextChanged);
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
            this.nud_Sets.TabIndex = 6;
            this.nud_Sets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Sets.ValueChanged += new System.EventHandler(this.nud_Sets_ValueChanged);
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
            this.panel1.Controls.Add(this.pnl_addOns);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 431);
            this.panel1.TabIndex = 31;
            // 
            // pnl_addOns
            // 
            this.pnl_addOns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_addOns.Location = new System.Drawing.Point(0, 296);
            this.pnl_addOns.Name = "pnl_addOns";
            this.pnl_addOns.Size = new System.Drawing.Size(227, 135);
            this.pnl_addOns.TabIndex = 28;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_Plissé);
            this.panel5.Controls.Add(this.cmb_PlisséType);
            this.panel5.Controls.Add(this.rdBtn_Door);
            this.panel5.Controls.Add(this.rdBtn_Window);
            this.panel5.Controls.Add(this.btn_add);
            this.panel5.Controls.Add(this.lbl_color);
            this.panel5.Controls.Add(this.cmb_baseColor);
            this.panel5.Controls.Add(this.nud_Factor);
            this.panel5.Controls.Add(this.lbl_Factor);
            this.panel5.Controls.Add(this.nud_TotalPrice);
            this.panel5.Controls.Add(this.lbl_whitePrice);
            this.panel5.Controls.Add(this.lbl_ScreenType);
            this.panel5.Controls.Add(this.cmb_ScreenType);
            this.panel5.Controls.Add(this.nud_Height);
            this.panel5.Controls.Add(this.nud_Width);
            this.panel5.Controls.Add(this.lbl_ScreenHeight);
            this.panel5.Controls.Add(this.lbl_ScreenWidth);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(227, 296);
            this.panel5.TabIndex = 67;
            // 
            // lbl_Plissé
            // 
            this.lbl_Plissé.AutoSize = true;
            this.lbl_Plissé.Location = new System.Drawing.Point(11, 82);
            this.lbl_Plissé.Name = "lbl_Plissé";
            this.lbl_Plissé.Size = new System.Drawing.Size(61, 13);
            this.lbl_Plissé.TabIndex = 84;
            this.lbl_Plissé.Text = "Plissé Type";
            // 
            // cmb_PlisséType
            // 
            this.cmb_PlisséType.FormattingEnabled = true;
            this.cmb_PlisséType.Location = new System.Drawing.Point(87, 79);
            this.cmb_PlisséType.Name = "cmb_PlisséType";
            this.cmb_PlisséType.Size = new System.Drawing.Size(130, 21);
            this.cmb_PlisséType.TabIndex = 83;
            this.cmb_PlisséType.SelectedIndexChanged += new System.EventHandler(this.cmb_PlisséType_SelectedIndexChanged);
            // 
            // rdBtn_Door
            // 
            this.rdBtn_Door.AutoSize = true;
            this.rdBtn_Door.Location = new System.Drawing.Point(122, 4);
            this.rdBtn_Door.Name = "rdBtn_Door";
            this.rdBtn_Door.Size = new System.Drawing.Size(51, 17);
            this.rdBtn_Door.TabIndex = 82;
            this.rdBtn_Door.TabStop = true;
            this.rdBtn_Door.Text = "Door";
            this.rdBtn_Door.UseVisualStyleBackColor = true;
            this.rdBtn_Door.CheckedChanged += new System.EventHandler(this.rdBtn_Door_CheckedChanged);
            // 
            // rdBtn_Window
            // 
            this.rdBtn_Window.AutoSize = true;
            this.rdBtn_Window.Location = new System.Drawing.Point(12, 3);
            this.rdBtn_Window.Name = "rdBtn_Window";
            this.rdBtn_Window.Size = new System.Drawing.Size(69, 17);
            this.rdBtn_Window.TabIndex = 81;
            this.rdBtn_Window.TabStop = true;
            this.rdBtn_Window.Text = "Window";
            this.rdBtn_Window.UseVisualStyleBackColor = true;
            this.rdBtn_Window.CheckedChanged += new System.EventHandler(this.rdBtn_Window_CheckedChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(57, 261);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(98, 26);
            this.btn_add.TabIndex = 80;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_color
            // 
            this.lbl_color.AutoSize = true;
            this.lbl_color.Location = new System.Drawing.Point(11, 30);
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(61, 13);
            this.lbl_color.TabIndex = 79;
            this.lbl_color.Text = "Base Color";
            // 
            // cmb_baseColor
            // 
            this.cmb_baseColor.FormattingEnabled = true;
            this.cmb_baseColor.Location = new System.Drawing.Point(87, 27);
            this.cmb_baseColor.Name = "cmb_baseColor";
            this.cmb_baseColor.Size = new System.Drawing.Size(130, 21);
            this.cmb_baseColor.TabIndex = 68;
            this.cmb_baseColor.SelectedValueChanged += new System.EventHandler(this.cmb_baseColor_SelectedValueChanged);
            // 
            // nud_Factor
            // 
            this.nud_Factor.Location = new System.Drawing.Point(87, 180);
            this.nud_Factor.Name = "nud_Factor";
            this.nud_Factor.Size = new System.Drawing.Size(130, 22);
            this.nud_Factor.TabIndex = 71;
            this.nud_Factor.ValueChanged += new System.EventHandler(this.nud_Factor_ValueChanged);
            // 
            // lbl_Factor
            // 
            this.lbl_Factor.AutoSize = true;
            this.lbl_Factor.Location = new System.Drawing.Point(12, 182);
            this.lbl_Factor.Name = "lbl_Factor";
            this.lbl_Factor.Size = new System.Drawing.Size(39, 13);
            this.lbl_Factor.TabIndex = 78;
            this.lbl_Factor.Text = "Factor";
            // 
            // nud_TotalPrice
            // 
            this.nud_TotalPrice.Enabled = false;
            this.nud_TotalPrice.Location = new System.Drawing.Point(87, 220);
            this.nud_TotalPrice.Name = "nud_TotalPrice";
            this.nud_TotalPrice.Size = new System.Drawing.Size(130, 22);
            this.nud_TotalPrice.TabIndex = 76;
            // 
            // lbl_whitePrice
            // 
            this.lbl_whitePrice.AutoSize = true;
            this.lbl_whitePrice.Location = new System.Drawing.Point(12, 222);
            this.lbl_whitePrice.Name = "lbl_whitePrice";
            this.lbl_whitePrice.Size = new System.Drawing.Size(32, 13);
            this.lbl_whitePrice.TabIndex = 75;
            this.lbl_whitePrice.Text = "Total";
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Location = new System.Drawing.Point(11, 55);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(67, 13);
            this.lbl_ScreenType.TabIndex = 74;
            this.lbl_ScreenType.Text = "Screen Type";
            // 
            // cmb_ScreenType
            // 
            this.cmb_ScreenType.FormattingEnabled = true;
            this.cmb_ScreenType.Location = new System.Drawing.Point(87, 52);
            this.cmb_ScreenType.Name = "cmb_ScreenType";
            this.cmb_ScreenType.Size = new System.Drawing.Size(130, 21);
            this.cmb_ScreenType.TabIndex = 67;
            this.cmb_ScreenType.SelectedValueChanged += new System.EventHandler(this.cmb_ScreenType_SelectedValueChanged);
            // 
            // nud_Height
            // 
            this.nud_Height.Location = new System.Drawing.Point(87, 152);
            this.nud_Height.Name = "nud_Height";
            this.nud_Height.Size = new System.Drawing.Size(130, 22);
            this.nud_Height.TabIndex = 70;
            this.nud_Height.ValueChanged += new System.EventHandler(this.nud_Height_ValueChanged);
            // 
            // nud_Width
            // 
            this.nud_Width.Location = new System.Drawing.Point(87, 124);
            this.nud_Width.Name = "nud_Width";
            this.nud_Width.Size = new System.Drawing.Size(130, 22);
            this.nud_Width.TabIndex = 69;
            this.nud_Width.ValueChanged += new System.EventHandler(this.nud_Width_ValueChanged);
            // 
            // lbl_ScreenHeight
            // 
            this.lbl_ScreenHeight.AutoSize = true;
            this.lbl_ScreenHeight.Location = new System.Drawing.Point(12, 154);
            this.lbl_ScreenHeight.Name = "lbl_ScreenHeight";
            this.lbl_ScreenHeight.Size = new System.Drawing.Size(42, 13);
            this.lbl_ScreenHeight.TabIndex = 73;
            this.lbl_ScreenHeight.Text = "Height";
            // 
            // lbl_ScreenWidth
            // 
            this.lbl_ScreenWidth.AutoSize = true;
            this.lbl_ScreenWidth.Location = new System.Drawing.Point(12, 126);
            this.lbl_ScreenWidth.Name = "lbl_ScreenWidth";
            this.lbl_ScreenWidth.Size = new System.Drawing.Size(39, 13);
            this.lbl_ScreenWidth.TabIndex = 72;
            this.lbl_ScreenWidth.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "___________________________________________";
            // 
            // tsScreen
            // 
            this.tsScreen.AutoSize = false;
            this.tsScreen.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsScreen.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsScreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnExchangeRate,
            this.tsBtnPrintScreen});
            this.tsScreen.Location = new System.Drawing.Point(0, 0);
            this.tsScreen.Name = "tsScreen";
            this.tsScreen.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsScreen.Size = new System.Drawing.Size(702, 27);
            this.tsScreen.TabIndex = 40;
            this.tsScreen.Text = "toolStrip1";
            // 
            // tsBtnExchangeRate
            // 
            this.tsBtnExchangeRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExchangeRate.Image = global::PresentationLayer.Properties.Resources.exchange;
            this.tsBtnExchangeRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExchangeRate.Name = "tsBtnExchangeRate";
            this.tsBtnExchangeRate.Size = new System.Drawing.Size(24, 24);
            this.tsBtnExchangeRate.Text = "Exchange Rate";
            this.tsBtnExchangeRate.Click += new System.EventHandler(this.tsBtnExchangeRate_Click);
            // 
            // tsBtnPrintScreen
            // 
            this.tsBtnPrintScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrintScreen.Image = global::PresentationLayer.Properties.Resources.print;
            this.tsBtnPrintScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrintScreen.Name = "tsBtnPrintScreen";
            this.tsBtnPrintScreen.Size = new System.Drawing.Size(24, 24);
            this.tsBtnPrintScreen.Text = "Print Screen";
            this.tsBtnPrintScreen.Click += new System.EventHandler(this.tsBtnPrintScreen_Click);
            // 
            // ScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 458);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScreenView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScreenView_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Screen)).EndInit();
            this.cmsScreen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Panel pnl_addOns;
        private System.Windows.Forms.ToolStrip tsScreen;
        private System.Windows.Forms.ToolStripButton tsBtnPrintScreen;
        private System.Windows.Forms.ContextMenuStrip cmsScreen;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_color;
        private System.Windows.Forms.ComboBox cmb_baseColor;
        private System.Windows.Forms.NumericUpDown nud_Factor;
        private System.Windows.Forms.Label lbl_Factor;
        private System.Windows.Forms.NumericUpDown nud_TotalPrice;
        private System.Windows.Forms.Label lbl_whitePrice;
        private System.Windows.Forms.Label lbl_ScreenType;
        private System.Windows.Forms.ComboBox cmb_ScreenType;
        private System.Windows.Forms.NumericUpDown nud_Height;
        private System.Windows.Forms.NumericUpDown nud_Width;
        private System.Windows.Forms.Label lbl_ScreenHeight;
        private System.Windows.Forms.Label lbl_ScreenWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdBtn_Door;
        private System.Windows.Forms.RadioButton rdBtn_Window;
        private System.Windows.Forms.Label lbl_Plissé;
        private System.Windows.Forms.ComboBox cmb_PlisséType;
        private System.Windows.Forms.ToolStripButton tsBtnExchangeRate;
    }
}