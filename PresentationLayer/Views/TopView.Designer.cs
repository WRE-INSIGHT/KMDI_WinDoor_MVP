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
            this.ts_Structural = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_nonStructural = new System.Windows.Forms.ToolStripMenuItem();
            this.nonleftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonrightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nonbothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Popup = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_dHandle = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Cremone = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Frame)).BeginInit();
            this.cmenu_TopViewProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TVSave
            // 
            this.btn_TVSave.Location = new System.Drawing.Point(596, 463);
            this.btn_TVSave.Name = "btn_TVSave";
            this.btn_TVSave.Size = new System.Drawing.Size(75, 34);
            this.btn_TVSave.TabIndex = 0;
            this.btn_TVSave.Text = "Save";
            this.btn_TVSave.UseVisualStyleBackColor = true;
            this.btn_TVSave.Click += new System.EventHandler(this.btn_TVSave_Click);
            // 
            // pbox_Frame
            // 
            this.pbox_Frame.Location = new System.Drawing.Point(32, 72);
            this.pbox_Frame.Name = "pbox_Frame";
            this.pbox_Frame.Size = new System.Drawing.Size(639, 337);
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
            this.label2.Location = new System.Drawing.Point(48, 39);
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
            this.lbl_Panels.Location = new System.Drawing.Point(130, 39);
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
            // ts_Structural
            // 
            this.ts_Structural.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.bothToolStripMenuItem});
            this.ts_Structural.Name = "ts_Structural";
            this.ts_Structural.Size = new System.Drawing.Size(153, 22);
            this.ts_Structural.Text = "Structural";
            this.ts_Structural.Click += new System.EventHandler(this.StructuralToolStripMenuItem_Click);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // bothToolStripMenuItem
            // 
            this.bothToolStripMenuItem.Name = "bothToolStripMenuItem";
            this.bothToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bothToolStripMenuItem.Text = "Both";
            this.bothToolStripMenuItem.Click += new System.EventHandler(this.bothToolStripMenuItem_Click);
            // 
            // ts_nonStructural
            // 
            this.ts_nonStructural.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nonleftToolStripMenuItem,
            this.nonrightToolStripMenuItem1,
            this.nonbothToolStripMenuItem});
            this.ts_nonStructural.Name = "ts_nonStructural";
            this.ts_nonStructural.Size = new System.Drawing.Size(153, 22);
            this.ts_nonStructural.Text = "Non-Structural";
            this.ts_nonStructural.Click += new System.EventHandler(this.nonStructuralToolStripMenuItem_Click);
            // 
            // nonleftToolStripMenuItem
            // 
            this.nonleftToolStripMenuItem.Name = "nonleftToolStripMenuItem";
            this.nonleftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nonleftToolStripMenuItem.Text = "Left";
            this.nonleftToolStripMenuItem.Click += new System.EventHandler(this.nonleftToolStripMenuItem_Click);
            // 
            // nonrightToolStripMenuItem1
            // 
            this.nonrightToolStripMenuItem1.Name = "nonrightToolStripMenuItem1";
            this.nonrightToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nonrightToolStripMenuItem1.Text = "Right";
            this.nonrightToolStripMenuItem1.Click += new System.EventHandler(this.nonrightToolStripMenuItem1_Click);
            // 
            // nonbothToolStripMenuItem
            // 
            this.nonbothToolStripMenuItem.Name = "nonbothToolStripMenuItem";
            this.nonbothToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nonbothToolStripMenuItem.Text = "Both";
            this.nonbothToolStripMenuItem.Click += new System.EventHandler(this.nonbothToolStripMenuItem_Click);
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
            // ts_Popup
            // 
            this.ts_Popup.Name = "ts_Popup";
            this.ts_Popup.Size = new System.Drawing.Size(125, 22);
            this.ts_Popup.Text = "Pop up";
            this.ts_Popup.Click += new System.EventHandler(this.popupToolStripMenuItem_Click);
            // 
            // ts_dHandle
            // 
            this.ts_dHandle.Name = "ts_dHandle";
            this.ts_dHandle.Size = new System.Drawing.Size(125, 22);
            this.ts_dHandle.Text = "D-Handle";
            this.ts_dHandle.Click += new System.EventHandler(this.dHandleToolStripMenuItem_Click);
            // 
            // ts_Cremone
            // 
            this.ts_Cremone.Name = "ts_Cremone";
            this.ts_Cremone.Size = new System.Drawing.Size(125, 22);
            this.ts_Cremone.Text = "Cremone";
            this.ts_Cremone.Click += new System.EventHandler(this.cremoneToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "INSIDE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "OUTSIDE";
            // 
            // TopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 509);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonleftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonrightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nonbothToolStripMenuItem;
    }
}