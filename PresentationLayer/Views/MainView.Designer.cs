namespace PresentationLayer.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnsMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.C70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PremiLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSyncDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncLocalToCloudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertOrientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnNwin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNdoor = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CloudStoragetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsb_Undo = new System.Windows.Forms.ToolStripButton();
            this.tsb_Redo = new System.Windows.Forms.ToolStripButton();
            this.tsprogress_Loading = new System.Windows.Forms.ToolStripProgressBar();
            this.deleteItemToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsp_Sync = new System.Windows.Forms.ToolStripLabel();
            this.tsLbl_Loading = new System.Windows.Forms.ToolStripLabel();
            this.tsBot = new System.Windows.Forms.ToolStrip();
            this.tsSize2 = new System.Windows.Forms.ToolStripLabel();
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.tsLbl_Welcome = new System.Windows.Forms.ToolStripLabel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlControlMain = new System.Windows.Forms.Panel();
            this.dgvControls = new System.Windows.Forms.DataGridView();
            this.ImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flp_base = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.pnlPropertiesBody = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mnsMainMenu.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.tsBot.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMainMenu
            // 
            this.mnsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.costingToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.mnsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMainMenu.Name = "mnsMainMenu";
            this.mnsMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnsMainMenu.Size = new System.Drawing.Size(1084, 24);
            this.mnsMainMenu.TabIndex = 2;
            this.mnsMainMenu.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.syncToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuotationToolStripMenuItem,
            this.ItemToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "Ne&w";
            // 
            // QuotationToolStripMenuItem
            // 
            this.QuotationToolStripMenuItem.Name = "QuotationToolStripMenuItem";
            this.QuotationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.QuotationToolStripMenuItem.Text = "&Quotation";
            this.QuotationToolStripMenuItem.Click += new System.EventHandler(this.QuotationToolStripMenuItem_Click);
            // 
            // ItemToolStripMenuItem
            // 
            this.ItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C70ToolStripMenuItem,
            this.PremiLineToolStripMenuItem});
            this.ItemToolStripMenuItem.Enabled = false;
            this.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem";
            this.ItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ItemToolStripMenuItem.Text = "I&tem";
            // 
            // C70ToolStripMenuItem
            // 
            this.C70ToolStripMenuItem.Name = "C70ToolStripMenuItem";
            this.C70ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.C70ToolStripMenuItem.Text = "&C70";
            // 
            // PremiLineToolStripMenuItem
            // 
            this.PremiLineToolStripMenuItem.Name = "PremiLineToolStripMenuItem";
            this.PremiLineToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.PremiLineToolStripMenuItem.Text = "P&remiLine";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "&Save as";
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Enabled = false;
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.syncToolStripMenuItem.Text = "Cloud sync";
            // 
            // costingToolStripMenuItem
            // 
            this.costingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.defaultValuesToolStripMenuItem});
            this.costingToolStripMenuItem.Name = "costingToolStripMenuItem";
            this.costingToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.costingToolStripMenuItem.Text = "Cos&ting";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Enabled = false;
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // defaultValuesToolStripMenuItem
            // 
            this.defaultValuesToolStripMenuItem.Name = "defaultValuesToolStripMenuItem";
            this.defaultValuesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.defaultValuesToolStripMenuItem.Text = "Default values";
            this.defaultValuesToolStripMenuItem.Visible = false;
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoDescriptionToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ViewToolStripMenuItem.Text = "View";
            // 
            // autoDescriptionToolStripMenuItem
            // 
            this.autoDescriptionToolStripMenuItem.Checked = true;
            this.autoDescriptionToolStripMenuItem.CheckOnClick = true;
            this.autoDescriptionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoDescriptionToolStripMenuItem.Name = "autoDescriptionToolStripMenuItem";
            this.autoDescriptionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.autoDescriptionToolStripMenuItem.Text = "Auto Description";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSyncDirectoryToolStripMenuItem,
            this.syncLocalToCloudToolStripMenuItem,
            this.editorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // changeSyncDirectoryToolStripMenuItem
            // 
            this.changeSyncDirectoryToolStripMenuItem.Name = "changeSyncDirectoryToolStripMenuItem";
            this.changeSyncDirectoryToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.changeSyncDirectoryToolStripMenuItem.Text = "Change sync directory";
            // 
            // syncLocalToCloudToolStripMenuItem
            // 
            this.syncLocalToCloudToolStripMenuItem.Name = "syncLocalToCloudToolStripMenuItem";
            this.syncLocalToCloudToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.syncLocalToCloudToolStripMenuItem.Text = "Sync local to cloud";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertOrientationToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // invertOrientationToolStripMenuItem
            // 
            this.invertOrientationToolStripMenuItem.CheckOnClick = true;
            this.invertOrientationToolStripMenuItem.Name = "invertOrientationToolStripMenuItem";
            this.invertOrientationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.invertOrientationToolStripMenuItem.Text = "Invert Orientation";
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNwin,
            this.tsBtnNdoor,
            this.openToolStripButton,
            this.CloudStoragetoolStripButton,
            this.saveToolStripButton,
            this.refreshToolStripButton,
            this.printToolStripButton,
            this.tsb_Undo,
            this.tsb_Redo,
            this.tsprogress_Loading,
            this.deleteItemToolStripButton1,
            this.tsp_Sync,
            this.tsLbl_Loading});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(1084, 32);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsBtnNwin
            // 
            this.tsBtnNwin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNwin.Image = global::PresentationLayer.Properties.Resources.AddNew_Window;
            this.tsBtnNwin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNwin.Name = "tsBtnNwin";
            this.tsBtnNwin.Size = new System.Drawing.Size(24, 29);
            this.tsBtnNwin.Text = "New Window";
            this.tsBtnNwin.Click += new System.EventHandler(this.tsBtnNwin_Click);
            // 
            // tsBtnNdoor
            // 
            this.tsBtnNdoor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNdoor.Enabled = false;
            this.tsBtnNdoor.Image = global::PresentationLayer.Properties.Resources.AddNew_Door;
            this.tsBtnNdoor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNdoor.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnNdoor.Name = "tsBtnNdoor";
            this.tsBtnNdoor.Size = new System.Drawing.Size(24, 32);
            this.tsBtnNdoor.Text = "New Door";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 29);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // CloudStoragetoolStripButton
            // 
            this.CloudStoragetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloudStoragetoolStripButton.Enabled = false;
            this.CloudStoragetoolStripButton.Image = global::PresentationLayer.Properties.Resources.cloud_storage_40px;
            this.CloudStoragetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloudStoragetoolStripButton.Name = "CloudStoragetoolStripButton";
            this.CloudStoragetoolStripButton.Size = new System.Drawing.Size(24, 29);
            this.CloudStoragetoolStripButton.Text = "Open Cloud storage";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 29);
            this.saveToolStripButton.Text = "&Save";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Enabled = false;
            this.refreshToolStripButton.Image = global::PresentationLayer.Properties.Resources.refresh_30px;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(24, 29);
            this.refreshToolStripButton.Text = "Refresh image";
            this.refreshToolStripButton.ToolTipText = "Refresh image";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 29);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Visible = false;
            // 
            // tsb_Undo
            // 
            this.tsb_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Undo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Undo.Image")));
            this.tsb_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Undo.Name = "tsb_Undo";
            this.tsb_Undo.Size = new System.Drawing.Size(24, 29);
            this.tsb_Undo.Text = "Undo";
            this.tsb_Undo.Visible = false;
            // 
            // tsb_Redo
            // 
            this.tsb_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Redo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Redo.Image")));
            this.tsb_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Redo.Name = "tsb_Redo";
            this.tsb_Redo.Size = new System.Drawing.Size(24, 29);
            this.tsb_Redo.Text = "Redo";
            this.tsb_Redo.Visible = false;
            // 
            // tsprogress_Loading
            // 
            this.tsprogress_Loading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsprogress_Loading.Name = "tsprogress_Loading";
            this.tsprogress_Loading.Size = new System.Drawing.Size(100, 29);
            this.tsprogress_Loading.Visible = false;
            // 
            // deleteItemToolStripButton1
            // 
            this.deleteItemToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteItemToolStripButton1.Image = global::PresentationLayer.Properties.Resources.delete_file_30px;
            this.deleteItemToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteItemToolStripButton1.Name = "deleteItemToolStripButton1";
            this.deleteItemToolStripButton1.Size = new System.Drawing.Size(24, 29);
            this.deleteItemToolStripButton1.Text = "Delete item";
            this.deleteItemToolStripButton1.ToolTipText = "Delete item";
            // 
            // tsp_Sync
            // 
            this.tsp_Sync.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_Sync.AutoSize = false;
            this.tsp_Sync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsp_Sync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_Sync.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsp_Sync.Image = global::PresentationLayer.Properties.Resources.cloud_sync_40px;
            this.tsp_Sync.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsp_Sync.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsp_Sync.Name = "tsp_Sync";
            this.tsp_Sync.Size = new System.Drawing.Size(50, 32);
            this.tsp_Sync.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsp_Sync.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsp_Sync.Visible = false;
            // 
            // tsLbl_Loading
            // 
            this.tsLbl_Loading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLbl_Loading.Name = "tsLbl_Loading";
            this.tsLbl_Loading.Size = new System.Drawing.Size(61, 29);
            this.tsLbl_Loading.Text = "Initializing";
            this.tsLbl_Loading.Visible = false;
            // 
            // tsBot
            // 
            this.tsBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBot.Enabled = false;
            this.tsBot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSize2,
            this.lblZoom,
            this.tsLbl_Welcome});
            this.tsBot.Location = new System.Drawing.Point(0, 553);
            this.tsBot.Name = "tsBot";
            this.tsBot.Size = new System.Drawing.Size(1084, 25);
            this.tsBot.TabIndex = 5;
            this.tsBot.Text = "toolStrip1";
            // 
            // tsSize2
            // 
            this.tsSize2.DoubleClickEnabled = true;
            this.tsSize2.Name = "tsSize2";
            this.tsSize2.Size = new System.Drawing.Size(55, 22);
            this.tsSize2.Text = "400 x 400";
            // 
            // lblZoom
            // 
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(35, 22);
            this.lblZoom.Text = "100%";
            // 
            // tsLbl_Welcome
            // 
            this.tsLbl_Welcome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLbl_Welcome.Name = "tsLbl_Welcome";
            this.tsLbl_Welcome.Size = new System.Drawing.Size(86, 22);
            this.tsLbl_Welcome.Text = "Welcome, User";
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.pnlItems);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(916, 56);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(168, 497);
            this.pnlRight.TabIndex = 6;
            // 
            // pnlItems
            // 
            this.pnlItems.AutoScroll = true;
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 29);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(166, 466);
            this.pnlItems.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Items";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlControlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMain);
            this.splitContainer1.Panel2.Controls.Add(this.pnlProperties);
            this.splitContainer1.Size = new System.Drawing.Size(916, 497);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 7;
            // 
            // pnlControlMain
            // 
            this.pnlControlMain.Controls.Add(this.dgvControls);
            this.pnlControlMain.Controls.Add(this.label1);
            this.pnlControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlControlMain.Name = "pnlControlMain";
            this.pnlControlMain.Size = new System.Drawing.Size(129, 495);
            this.pnlControlMain.TabIndex = 5;
            // 
            // dgvControls
            // 
            this.dgvControls.AllowUserToAddRows = false;
            this.dgvControls.AllowUserToDeleteRows = false;
            this.dgvControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvControls.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControls.ColumnHeadersVisible = false;
            this.dgvControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageCol,
            this.DescCol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvControls.Location = new System.Drawing.Point(0, 29);
            this.dgvControls.MultiSelect = false;
            this.dgvControls.Name = "dgvControls";
            this.dgvControls.ReadOnly = true;
            this.dgvControls.RowHeadersVisible = false;
            this.dgvControls.RowTemplate.Height = 55;
            this.dgvControls.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvControls.Size = new System.Drawing.Size(129, 466);
            this.dgvControls.TabIndex = 5;
            // 
            // ImageCol
            // 
            this.ImageCol.HeaderText = "Image";
            this.ImageCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ImageCol.Name = "ImageCol";
            this.ImageCol.ReadOnly = true;
            this.ImageCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImageCol.Width = 5;
            // 
            // DescCol
            // 
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            this.DescCol.Width = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Controls";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.AutoSize = true;
            this.pnlMain.Controls.Add(this.flp_base);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(139, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(640, 495);
            this.pnlMain.TabIndex = 3;
            // 
            // flp_base
            // 
            this.flp_base.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_base.Location = new System.Drawing.Point(161, 97);
            this.flp_base.Name = "flp_base";
            this.flp_base.Size = new System.Drawing.Size(300, 300);
            this.flp_base.TabIndex = 0;
            this.flp_base.Visible = false;
            // 
            // pnlProperties
            // 
            this.pnlProperties.AutoScroll = true;
            this.pnlProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProperties.Controls.Add(this.chkView);
            this.pnlProperties.Controls.Add(this.pnlPropertiesBody);
            this.pnlProperties.Controls.Add(this.label2);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProperties.Location = new System.Drawing.Point(0, 0);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(139, 495);
            this.pnlProperties.TabIndex = 4;
            // 
            // chkView
            // 
            this.chkView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkView.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkView.AutoSize = true;
            this.chkView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chkView.FlatAppearance.BorderSize = 0;
            this.chkView.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chkView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkView.Location = new System.Drawing.Point(93, 3);
            this.chkView.Margin = new System.Windows.Forms.Padding(2);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(40, 23);
            this.chkView.TabIndex = 2;
            this.chkView.Text = "View";
            this.chkView.UseVisualStyleBackColor = false;
            // 
            // pnlPropertiesBody
            // 
            this.pnlPropertiesBody.AutoScroll = true;
            this.pnlPropertiesBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropertiesBody.Location = new System.Drawing.Point(0, 29);
            this.pnlPropertiesBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPropertiesBody.Name = "pnlPropertiesBody";
            this.pnlPropertiesBody.Size = new System.Drawing.Size(137, 464);
            this.pnlPropertiesBody.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Properties";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "WNDR files (*.wndr)|*.wndr";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.tsBot);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnsMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.mnsMainMenu.ResumeLayout(false);
            this.mnsMainMenu.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tsBot.ResumeLayout(false);
            this.tsBot.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlProperties.ResumeLayout(false);
            this.pnlProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem C70ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PremiLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSyncDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncLocalToCloudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertOrientationToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsBtnNwin;
        private System.Windows.Forms.ToolStripButton tsBtnNdoor;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton CloudStoragetoolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton tsb_Undo;
        private System.Windows.Forms.ToolStripButton tsb_Redo;
        private System.Windows.Forms.ToolStripProgressBar tsprogress_Loading;
        private System.Windows.Forms.ToolStripButton deleteItemToolStripButton1;
        private System.Windows.Forms.ToolStripLabel tsp_Sync;
        private System.Windows.Forms.ToolStripLabel tsLbl_Loading;
        private System.Windows.Forms.ToolStrip tsBot;
        private System.Windows.Forms.ToolStripLabel tsSize2;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.ToolStripLabel tsLbl_Welcome;
        private System.Windows.Forms.Panel pnlRight;
        public System.Windows.Forms.Panel pnlItems;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlControlMain;
        private System.Windows.Forms.DataGridView dgvControls;
        private System.Windows.Forms.DataGridViewImageColumn ImageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlProperties;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.Panel pnlPropertiesBody;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp_base;
    }
}