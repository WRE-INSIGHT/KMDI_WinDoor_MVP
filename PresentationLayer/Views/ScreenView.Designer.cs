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
            this.txt_ItemNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Discount = new System.Windows.Forms.NumericUpDown();
            this.nud_Quantity = new System.Windows.Forms.NumericUpDown();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.txt_windoorID = new System.Windows.Forms.TextBox();
            this.lbl_WindoorID = new System.Windows.Forms.Label();
            this.nud_Sets = new System.Windows.Forms.NumericUpDown();
            this.lbl_sets = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_addOns = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmb_freedomSize = new System.Windows.Forms.ComboBox();
            this.lbl_plissedRd = new System.Windows.Forms.Label();
            this.nud_plissedRd = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_plissedRd)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(1033, 574);
            this.panel2.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_Screen);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(235, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 547);
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
            this.dgv_Screen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Screen.Size = new System.Drawing.Size(798, 510);
            this.dgv_Screen.TabIndex = 30;
            this.dgv_Screen.TabStop = false;
            this.dgv_Screen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Screen_CellClick);
            this.dgv_Screen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Screen_CellDoubleClick);
            this.dgv_Screen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Screen_CellEndEdit);
            this.dgv_Screen.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Screen_ColumnHeaderMouseClick);
            this.dgv_Screen.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Screen_ColumnHeaderMouseDoubleClick);
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
            this.panel3.Controls.Add(this.txt_ItemNum);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.nud_Discount);
            this.panel3.Controls.Add(this.nud_Quantity);
            this.panel3.Controls.Add(this.lbl_Quantity);
            this.panel3.Controls.Add(this.txt_windoorID);
            this.panel3.Controls.Add(this.lbl_WindoorID);
            this.panel3.Controls.Add(this.nud_Sets);
            this.panel3.Controls.Add(this.lbl_sets);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 37);
            this.panel3.TabIndex = 2;
            // 
            // txt_ItemNum
            // 
            this.txt_ItemNum.Location = new System.Drawing.Point(62, 8);
            this.txt_ItemNum.Name = "txt_ItemNum";
            this.txt_ItemNum.Size = new System.Drawing.Size(38, 22);
            this.txt_ItemNum.TabIndex = 0;
            this.txt_ItemNum.TextChanged += new System.EventHandler(this.txt_ItemNum_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Item No.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Discount %";
            // 
            // nud_Discount
            // 
            this.nud_Discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Discount.Location = new System.Drawing.Point(727, 8);
            this.nud_Discount.Name = "nud_Discount";
            this.nud_Discount.Size = new System.Drawing.Size(59, 22);
            this.nud_Discount.TabIndex = 4;
            this.nud_Discount.ValueChanged += new System.EventHandler(this.nud_Discount_ValueChanged);
            this.nud_Discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_Discount_KeyPress);
            // 
            // nud_Quantity
            // 
            this.nud_Quantity.Location = new System.Drawing.Point(509, 8);
            this.nud_Quantity.Name = "nud_Quantity";
            this.nud_Quantity.Size = new System.Drawing.Size(50, 22);
            this.nud_Quantity.TabIndex = 3;
            this.nud_Quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Quantity.ValueChanged += new System.EventHandler(this.nud_Quantity_ValueChanged);
            this.nud_Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_Quantity_KeyPress);
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(452, 12);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(51, 13);
            this.lbl_Quantity.TabIndex = 38;
            this.lbl_Quantity.Text = "Quantity";
            // 
            // txt_windoorID
            // 
            this.txt_windoorID.Location = new System.Drawing.Point(218, 8);
            this.txt_windoorID.Name = "txt_windoorID";
            this.txt_windoorID.Size = new System.Drawing.Size(100, 22);
            this.txt_windoorID.TabIndex = 1;
            this.txt_windoorID.TextChanged += new System.EventHandler(this.txt_windoorID_TextChanged);
            // 
            // lbl_WindoorID
            // 
            this.lbl_WindoorID.AutoSize = true;
            this.lbl_WindoorID.Location = new System.Drawing.Point(117, 12);
            this.lbl_WindoorID.Name = "lbl_WindoorID";
            this.lbl_WindoorID.Size = new System.Drawing.Size(95, 13);
            this.lbl_WindoorID.TabIndex = 35;
            this.lbl_WindoorID.Text = "Window/Door ID";
            // 
            // nud_Sets
            // 
            this.nud_Sets.Location = new System.Drawing.Point(385, 8);
            this.nud_Sets.Name = "nud_Sets";
            this.nud_Sets.Size = new System.Drawing.Size(50, 22);
            this.nud_Sets.TabIndex = 2;
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
            this.lbl_sets.Location = new System.Drawing.Point(330, 12);
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
            this.panel1.Size = new System.Drawing.Size(235, 547);
            this.panel1.TabIndex = 31;
            // 
            // pnl_addOns
            // 
            this.pnl_addOns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_addOns.BackColor = System.Drawing.Color.Silver;
            this.pnl_addOns.Location = new System.Drawing.Point(0, 315);
            this.pnl_addOns.Name = "pnl_addOns";
            this.pnl_addOns.Size = new System.Drawing.Size(235, 232);
            this.pnl_addOns.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmb_freedomSize);
            this.panel5.Controls.Add(this.lbl_plissedRd);
            this.panel5.Controls.Add(this.nud_plissedRd);
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
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 547);
            this.panel5.TabIndex = 0;
            // 
            // cmb_freedomSize
            // 
            this.cmb_freedomSize.FormattingEnabled = true;
            this.cmb_freedomSize.Location = new System.Drawing.Point(143, 111);
            this.cmb_freedomSize.Name = "cmb_freedomSize";
            this.cmb_freedomSize.Size = new System.Drawing.Size(74, 21);
            this.cmb_freedomSize.TabIndex = 4;
            this.cmb_freedomSize.SelectedValueChanged += new System.EventHandler(this.cmb_freedomSize_SelectedValueChanged);
            // 
            // lbl_plissedRd
            // 
            this.lbl_plissedRd.AutoSize = true;
            this.lbl_plissedRd.Location = new System.Drawing.Point(12, 114);
            this.lbl_plissedRd.Name = "lbl_plissedRd";
            this.lbl_plissedRd.Size = new System.Drawing.Size(40, 13);
            this.lbl_plissedRd.TabIndex = 87;
            this.lbl_plissedRd.Text = "Panels";
            // 
            // nud_plissedRd
            // 
            this.nud_plissedRd.Location = new System.Drawing.Point(87, 110);
            this.nud_plissedRd.Name = "nud_plissedRd";
            this.nud_plissedRd.Size = new System.Drawing.Size(50, 22);
            this.nud_plissedRd.TabIndex = 3;
            this.nud_plissedRd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_plissedRd.ValueChanged += new System.EventHandler(this.nud_plissedRd_ValueChanged);
            // 
            // lbl_Plissé
            // 
            this.lbl_Plissé.AutoSize = true;
            this.lbl_Plissé.Location = new System.Drawing.Point(11, 92);
            this.lbl_Plissé.Name = "lbl_Plissé";
            this.lbl_Plissé.Size = new System.Drawing.Size(61, 13);
            this.lbl_Plissé.TabIndex = 84;
            this.lbl_Plissé.Text = "Plissé Type";
            // 
            // cmb_PlisséType
            // 
            this.cmb_PlisséType.FormattingEnabled = true;
            this.cmb_PlisséType.Location = new System.Drawing.Point(87, 89);
            this.cmb_PlisséType.Name = "cmb_PlisséType";
            this.cmb_PlisséType.Size = new System.Drawing.Size(130, 21);
            this.cmb_PlisséType.TabIndex = 2;
            this.cmb_PlisséType.SelectedIndexChanged += new System.EventHandler(this.cmb_PlisséType_SelectedIndexChanged);
            // 
            // rdBtn_Door
            // 
            this.rdBtn_Door.AutoSize = true;
            this.rdBtn_Door.Location = new System.Drawing.Point(136, 11);
            this.rdBtn_Door.Name = "rdBtn_Door";
            this.rdBtn_Door.Size = new System.Drawing.Size(51, 17);
            this.rdBtn_Door.TabIndex = 5;
            this.rdBtn_Door.Text = "Door";
            this.rdBtn_Door.UseVisualStyleBackColor = true;
            this.rdBtn_Door.CheckedChanged += new System.EventHandler(this.rdBtn_Door_CheckedChanged);
            // 
            // rdBtn_Window
            // 
            this.rdBtn_Window.AutoSize = true;
            this.rdBtn_Window.Location = new System.Drawing.Point(26, 10);
            this.rdBtn_Window.Name = "rdBtn_Window";
            this.rdBtn_Window.Size = new System.Drawing.Size(69, 17);
            this.rdBtn_Window.TabIndex = 4;
            this.rdBtn_Window.Text = "Window";
            this.rdBtn_Window.UseVisualStyleBackColor = true;
            this.rdBtn_Window.CheckedChanged += new System.EventHandler(this.rdBtn_Window_CheckedChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(57, 271);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(98, 26);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_color
            // 
            this.lbl_color.AutoSize = true;
            this.lbl_color.Location = new System.Drawing.Point(11, 40);
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(61, 13);
            this.lbl_color.TabIndex = 79;
            this.lbl_color.Text = "Base Color";
            // 
            // cmb_baseColor
            // 
            this.cmb_baseColor.FormattingEnabled = true;
            this.cmb_baseColor.Location = new System.Drawing.Point(87, 37);
            this.cmb_baseColor.Name = "cmb_baseColor";
            this.cmb_baseColor.Size = new System.Drawing.Size(130, 21);
            this.cmb_baseColor.TabIndex = 0;
            this.cmb_baseColor.SelectedValueChanged += new System.EventHandler(this.cmb_baseColor_SelectedValueChanged);
            // 
            // nud_Factor
            // 
            this.nud_Factor.Location = new System.Drawing.Point(87, 190);
            this.nud_Factor.Name = "nud_Factor";
            this.nud_Factor.Size = new System.Drawing.Size(130, 22);
            this.nud_Factor.TabIndex = 7;
            this.nud_Factor.ValueChanged += new System.EventHandler(this.nud_Factor_ValueChanged);
            this.nud_Factor.Enter += new System.EventHandler(this.nud_Factor_Enter);
            // 
            // lbl_Factor
            // 
            this.lbl_Factor.AutoSize = true;
            this.lbl_Factor.Location = new System.Drawing.Point(12, 192);
            this.lbl_Factor.Name = "lbl_Factor";
            this.lbl_Factor.Size = new System.Drawing.Size(39, 13);
            this.lbl_Factor.TabIndex = 78;
            this.lbl_Factor.Text = "Factor";
            // 
            // nud_TotalPrice
            // 
            this.nud_TotalPrice.Enabled = false;
            this.nud_TotalPrice.Location = new System.Drawing.Point(87, 230);
            this.nud_TotalPrice.Name = "nud_TotalPrice";
            this.nud_TotalPrice.Size = new System.Drawing.Size(130, 22);
            this.nud_TotalPrice.TabIndex = 8;
            this.nud_TotalPrice.TabStop = false;
            // 
            // lbl_whitePrice
            // 
            this.lbl_whitePrice.AutoSize = true;
            this.lbl_whitePrice.Location = new System.Drawing.Point(12, 232);
            this.lbl_whitePrice.Name = "lbl_whitePrice";
            this.lbl_whitePrice.Size = new System.Drawing.Size(32, 13);
            this.lbl_whitePrice.TabIndex = 75;
            this.lbl_whitePrice.Text = "Total";
            // 
            // lbl_ScreenType
            // 
            this.lbl_ScreenType.AutoSize = true;
            this.lbl_ScreenType.Location = new System.Drawing.Point(11, 65);
            this.lbl_ScreenType.Name = "lbl_ScreenType";
            this.lbl_ScreenType.Size = new System.Drawing.Size(67, 13);
            this.lbl_ScreenType.TabIndex = 74;
            this.lbl_ScreenType.Text = "Screen Type";
            // 
            // cmb_ScreenType
            // 
            this.cmb_ScreenType.FormattingEnabled = true;
            this.cmb_ScreenType.Location = new System.Drawing.Point(87, 62);
            this.cmb_ScreenType.Name = "cmb_ScreenType";
            this.cmb_ScreenType.Size = new System.Drawing.Size(130, 21);
            this.cmb_ScreenType.TabIndex = 1;
            this.cmb_ScreenType.SelectedValueChanged += new System.EventHandler(this.cmb_ScreenType_SelectedValueChanged);
            // 
            // nud_Height
            // 
            this.nud_Height.Location = new System.Drawing.Point(87, 162);
            this.nud_Height.Name = "nud_Height";
            this.nud_Height.Size = new System.Drawing.Size(130, 22);
            this.nud_Height.TabIndex = 6;
            this.nud_Height.ValueChanged += new System.EventHandler(this.nud_Height_ValueChanged);
            this.nud_Height.Enter += new System.EventHandler(this.nud_Height_Enter);
            this.nud_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_Height_KeyPress);
            // 
            // nud_Width
            // 
            this.nud_Width.Location = new System.Drawing.Point(87, 134);
            this.nud_Width.Name = "nud_Width";
            this.nud_Width.Size = new System.Drawing.Size(130, 22);
            this.nud_Width.TabIndex = 5;
            this.nud_Width.ValueChanged += new System.EventHandler(this.nud_Width_ValueChanged);
            this.nud_Width.Enter += new System.EventHandler(this.nud_Width_Enter);
            this.nud_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_Width_KeyPress);
            // 
            // lbl_ScreenHeight
            // 
            this.lbl_ScreenHeight.AutoSize = true;
            this.lbl_ScreenHeight.Location = new System.Drawing.Point(12, 164);
            this.lbl_ScreenHeight.Name = "lbl_ScreenHeight";
            this.lbl_ScreenHeight.Size = new System.Drawing.Size(42, 13);
            this.lbl_ScreenHeight.TabIndex = 73;
            this.lbl_ScreenHeight.Text = "Height";
            // 
            // lbl_ScreenWidth
            // 
            this.lbl_ScreenWidth.AutoSize = true;
            this.lbl_ScreenWidth.Location = new System.Drawing.Point(12, 136);
            this.lbl_ScreenWidth.Name = "lbl_ScreenWidth";
            this.lbl_ScreenWidth.Size = new System.Drawing.Size(39, 13);
            this.lbl_ScreenWidth.TabIndex = 72;
            this.lbl_ScreenWidth.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 207);
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
            this.tsScreen.Size = new System.Drawing.Size(1033, 27);
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
            this.tsBtnExchangeRate.Visible = false;
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
            this.ClientSize = new System.Drawing.Size(1033, 574);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(840, 527);
            this.Name = "ScreenView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenView_FormClosing);
            this.Load += new System.EventHandler(this.ScreenView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenView_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Screen)).EndInit();
            this.cmsScreen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_plissedRd)).EndInit();
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
        private System.Windows.Forms.Label lbl_plissedRd;
        private System.Windows.Forms.NumericUpDown nud_plissedRd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Discount;
        private System.Windows.Forms.TextBox txt_ItemNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_freedomSize;
    }
}