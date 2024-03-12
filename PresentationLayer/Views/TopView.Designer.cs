namespace PresentationLayer.Views
{
    partial class TopView
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
            this.btn_TVSave = new System.Windows.Forms.Button();
            this.pbox_Frame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Tracks = new System.Windows.Forms.Label();
            this.lbl_Panels = new System.Windows.Forms.Label();
            this.FormTimer = new System.Windows.Forms.Timer(this.components);
            this.cmenu_TopViewProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.interlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Structural = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_nonStructural = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Popup = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_dHandle = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Cremone = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Frame)).BeginInit();
            this.cmenu_TopViewProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TVSave
            // 
            this.btn_TVSave.Location = new System.Drawing.Point(536, 453);
            this.btn_TVSave.Name = "btn_TVSave";
            this.btn_TVSave.Size = new System.Drawing.Size(75, 34);
            this.btn_TVSave.TabIndex = 0;
            this.btn_TVSave.Text = "Save";
            this.btn_TVSave.UseVisualStyleBackColor = true;
            this.btn_TVSave.Click += new System.EventHandler(this.btn_TVSave_Click);
            // 
            // pbox_Frame
            // 
            this.pbox_Frame.Location = new System.Drawing.Point(32, 47);
            this.pbox_Frame.Name = "pbox_Frame";
            this.pbox_Frame.Size = new System.Drawing.Size(600, 400);
            this.pbox_Frame.TabIndex = 1;
            this.pbox_Frame.TabStop = false;
            this.pbox_Frame.Paint += new System.Windows.Forms.PaintEventHandler(this.pbox_Frame_Paint);
            this.pbox_Frame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbox_Frame_MouseClick);
            this.pbox_Frame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_Frame_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No. of Tracks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. of Panels:";
            // 
            // lbl_Tracks
            // 
            this.lbl_Tracks.AutoSize = true;
            this.lbl_Tracks.Location = new System.Drawing.Point(130, 13);
            this.lbl_Tracks.Name = "lbl_Tracks";
            this.lbl_Tracks.Size = new System.Drawing.Size(0, 13);
            this.lbl_Tracks.TabIndex = 4;
            // 
            // lbl_Panels
            // 
            this.lbl_Panels.AutoSize = true;
            this.lbl_Panels.Location = new System.Drawing.Point(289, 13);
            this.lbl_Panels.Name = "lbl_Panels";
            this.lbl_Panels.Size = new System.Drawing.Size(0, 13);
            this.lbl_Panels.TabIndex = 5;
            // 
            // FormTimer
            // 
            this.FormTimer.Enabled = true;
            this.FormTimer.Interval = 20;
            this.FormTimer.Tick += new System.EventHandler(this.FormTimerTickEvent);
            // 
            // cmenu_TopViewProperties
            // 
            this.cmenu_TopViewProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interlockToolStripMenuItem,
            this.handleToolStripMenuItem});
            this.cmenu_TopViewProperties.Name = "cmenu_TopViewProperties";
            this.cmenu_TopViewProperties.Size = new System.Drawing.Size(153, 70);
            // 
            // interlockToolStripMenuItem
            // 
            this.interlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Structural,
            this.ts_nonStructural});
            this.interlockToolStripMenuItem.Name = "interlockToolStripMenuItem";
            this.interlockToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.interlockToolStripMenuItem.Text = "Interlock";
            // 
            // handleToolStripMenuItem
            // 
            this.handleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Popup,
            this.ts_dHandle,
            this.ts_Cremone});
            this.handleToolStripMenuItem.Name = "handleToolStripMenuItem";
            this.handleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.handleToolStripMenuItem.Text = "Handle";
            // 
            // ts_Structural
            // 
            this.ts_Structural.CheckOnClick = true;
            this.ts_Structural.Name = "ts_Structural";
            this.ts_Structural.Size = new System.Drawing.Size(153, 22);
            this.ts_Structural.Text = "Structural";
            // 
            // ts_nonStructural
            // 
            this.ts_nonStructural.CheckOnClick = true;
            this.ts_nonStructural.Name = "ts_nonStructural";
            this.ts_nonStructural.Size = new System.Drawing.Size(153, 22);
            this.ts_nonStructural.Text = "Non-Structural";
            // 
            // ts_Popup
            // 
            this.ts_Popup.CheckOnClick = true;
            this.ts_Popup.Name = "ts_Popup";
            this.ts_Popup.Size = new System.Drawing.Size(152, 22);
            this.ts_Popup.Text = "Pop up";
            // 
            // ts_dHandle
            // 
            this.ts_dHandle.CheckOnClick = true;
            this.ts_dHandle.Name = "ts_dHandle";
            this.ts_dHandle.Size = new System.Drawing.Size(152, 22);
            this.ts_dHandle.Text = "D-Handle";
            // 
            // ts_Cremone
            // 
            this.ts_Cremone.CheckOnClick = true;
            this.ts_Cremone.Name = "ts_Cremone";
            this.ts_Cremone.Size = new System.Drawing.Size(152, 22);
            this.ts_Cremone.Text = "Cremone";
            // 
            // TopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 509);
            this.Controls.Add(this.lbl_Panels);
            this.Controls.Add(this.lbl_Tracks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbox_Frame);
            this.Controls.Add(this.btn_TVSave);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top View (Select Panel)";
            this.Load += new System.EventHandler(this.TopView_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TopView_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Frame)).EndInit();
            this.cmenu_TopViewProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TVSave;
        private System.Windows.Forms.PictureBox pbox_Frame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Tracks;
        private System.Windows.Forms.Label lbl_Panels;
        private System.Windows.Forms.Timer FormTimer;
        private System.Windows.Forms.ContextMenuStrip cmenu_TopViewProperties;
        private System.Windows.Forms.ToolStripMenuItem interlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_Structural;
        private System.Windows.Forms.ToolStripMenuItem ts_nonStructural;
        private System.Windows.Forms.ToolStripMenuItem handleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_Popup;
        private System.Windows.Forms.ToolStripMenuItem ts_dHandle;
        private System.Windows.Forms.ToolStripMenuItem ts_Cremone;
    }
}