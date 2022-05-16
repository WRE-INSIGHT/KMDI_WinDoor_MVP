namespace PresentationLayer.Views
{
    partial class CustomArrowHeadView
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
            this.pnl_CustomArrow = new System.Windows.Forms.Panel();
            this.pbox_frame = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_ArrowWidth = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ArrowWdCount = new System.Windows.Forms.Label();
            this.lbl_ArrowWidthLength = new System.Windows.Forms.Label();
            this.btn_AddArrowHeadWidth = new System.Windows.Forms.Button();
            this.pnl_ArrowHeight = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ArrowHtCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_AddArrowHeadHeight = new System.Windows.Forms.Button();
            this.lbl_ArrowHeightLength = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SaveCustomArrow = new System.Windows.Forms.Button();
            this.pnl_CustomArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_CustomArrow
            // 
            this.pnl_CustomArrow.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_CustomArrow.Controls.Add(this.pbox_frame);
            this.pnl_CustomArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_CustomArrow.Location = new System.Drawing.Point(211, 0);
            this.pnl_CustomArrow.Name = "pnl_CustomArrow";
            this.pnl_CustomArrow.Padding = new System.Windows.Forms.Padding(70, 35, 0, 0);
            this.pnl_CustomArrow.Size = new System.Drawing.Size(493, 441);
            this.pnl_CustomArrow.TabIndex = 15;
            this.pnl_CustomArrow.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_CustomArrow_Paint);
            // 
            // pbox_frame
            // 
            this.pbox_frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_frame.Location = new System.Drawing.Point(70, 35);
            this.pbox_frame.Name = "pbox_frame";
            this.pbox_frame.Size = new System.Drawing.Size(423, 406);
            this.pbox_frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_frame.TabIndex = 0;
            this.pbox_frame.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_ArrowWidth);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_ArrowHeight);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(211, 441);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnl_ArrowWidth
            // 
            this.pnl_ArrowWidth.AutoScroll = true;
            this.pnl_ArrowWidth.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_ArrowWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_ArrowWidth.Location = new System.Drawing.Point(0, 52);
            this.pnl_ArrowWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_ArrowWidth.Name = "pnl_ArrowWidth";
            this.pnl_ArrowWidth.Size = new System.Drawing.Size(211, 146);
            this.pnl_ArrowWidth.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_ArrowWdCount);
            this.panel2.Controls.Add(this.lbl_ArrowWidthLength);
            this.panel2.Controls.Add(this.btn_AddArrowHeadWidth);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 52);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Arrow Width Length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arrow Width";
            // 
            // lbl_ArrowWdCount
            // 
            this.lbl_ArrowWdCount.AutoSize = true;
            this.lbl_ArrowWdCount.BackColor = System.Drawing.Color.Silver;
            this.lbl_ArrowWdCount.Location = new System.Drawing.Point(109, 9);
            this.lbl_ArrowWdCount.Name = "lbl_ArrowWdCount";
            this.lbl_ArrowWdCount.Size = new System.Drawing.Size(15, 17);
            this.lbl_ArrowWdCount.TabIndex = 13;
            this.lbl_ArrowWdCount.Text = "0";
            // 
            // lbl_ArrowWidthLength
            // 
            this.lbl_ArrowWidthLength.AutoSize = true;
            this.lbl_ArrowWidthLength.BackColor = System.Drawing.Color.IndianRed;
            this.lbl_ArrowWidthLength.Location = new System.Drawing.Point(178, 35);
            this.lbl_ArrowWidthLength.Name = "lbl_ArrowWidthLength";
            this.lbl_ArrowWidthLength.Size = new System.Drawing.Size(15, 17);
            this.lbl_ArrowWidthLength.TabIndex = 10;
            this.lbl_ArrowWidthLength.Text = "0";
            // 
            // btn_AddArrowHeadWidth
            // 
            this.btn_AddArrowHeadWidth.Location = new System.Drawing.Point(130, 7);
            this.btn_AddArrowHeadWidth.Name = "btn_AddArrowHeadWidth";
            this.btn_AddArrowHeadWidth.Size = new System.Drawing.Size(76, 25);
            this.btn_AddArrowHeadWidth.TabIndex = 6;
            this.btn_AddArrowHeadWidth.Text = "Add";
            this.btn_AddArrowHeadWidth.UseVisualStyleBackColor = true;
            this.btn_AddArrowHeadWidth.Click += new System.EventHandler(this.btn_AddArrowHeadWidth_Click);
            // 
            // pnl_ArrowHeight
            // 
            this.pnl_ArrowHeight.AutoScroll = true;
            this.pnl_ArrowHeight.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_ArrowHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_ArrowHeight.Location = new System.Drawing.Point(0, 52);
            this.pnl_ArrowHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_ArrowHeight.Name = "pnl_ArrowHeight";
            this.pnl_ArrowHeight.Size = new System.Drawing.Size(211, 137);
            this.pnl_ArrowHeight.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_ArrowHtCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btn_AddArrowHeadHeight);
            this.panel3.Controls.Add(this.lbl_ArrowHeightLength);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 52);
            this.panel3.TabIndex = 21;
            // 
            // lbl_ArrowHtCount
            // 
            this.lbl_ArrowHtCount.AutoSize = true;
            this.lbl_ArrowHtCount.BackColor = System.Drawing.Color.Silver;
            this.lbl_ArrowHtCount.Location = new System.Drawing.Point(96, 4);
            this.lbl_ArrowHtCount.Name = "lbl_ArrowHtCount";
            this.lbl_ArrowHtCount.Size = new System.Drawing.Size(15, 17);
            this.lbl_ArrowHtCount.TabIndex = 14;
            this.lbl_ArrowHtCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arrow Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Arrow Height Length";
            // 
            // btn_AddArrowHeadHeight
            // 
            this.btn_AddArrowHeadHeight.Location = new System.Drawing.Point(117, 0);
            this.btn_AddArrowHeadHeight.Name = "btn_AddArrowHeadHeight";
            this.btn_AddArrowHeadHeight.Size = new System.Drawing.Size(83, 25);
            this.btn_AddArrowHeadHeight.TabIndex = 7;
            this.btn_AddArrowHeadHeight.Text = "Add";
            this.btn_AddArrowHeadHeight.UseVisualStyleBackColor = true;
            this.btn_AddArrowHeadHeight.Click += new System.EventHandler(this.btn_AddArrowHeadHeight_Click);
            // 
            // lbl_ArrowHeightLength
            // 
            this.lbl_ArrowHeightLength.AutoSize = true;
            this.lbl_ArrowHeightLength.BackColor = System.Drawing.Color.IndianRed;
            this.lbl_ArrowHeightLength.Location = new System.Drawing.Point(165, 30);
            this.lbl_ArrowHeightLength.Name = "lbl_ArrowHeightLength";
            this.lbl_ArrowHeightLength.Size = new System.Drawing.Size(15, 17);
            this.lbl_ArrowHeightLength.TabIndex = 12;
            this.lbl_ArrowHeightLength.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SaveCustomArrow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 50);
            this.panel1.TabIndex = 20;
            // 
            // btn_SaveCustomArrow
            // 
            this.btn_SaveCustomArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SaveCustomArrow.Location = new System.Drawing.Point(65, 9);
            this.btn_SaveCustomArrow.Name = "btn_SaveCustomArrow";
            this.btn_SaveCustomArrow.Size = new System.Drawing.Size(78, 38);
            this.btn_SaveCustomArrow.TabIndex = 8;
            this.btn_SaveCustomArrow.Text = "Save";
            this.btn_SaveCustomArrow.UseVisualStyleBackColor = true;
            this.btn_SaveCustomArrow.Click += new System.EventHandler(this.btn_SaveCustomArrow_Click);
            // 
            // CustomArrowHeadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.pnl_CustomArrow);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CustomArrowHeadView";
            this.Text = "CustomArrowHeadView";
            this.Load += new System.EventHandler(this.CustomArrowHeadView_Load);
            this.SizeChanged += new System.EventHandler(this.CustomArrowHeadView_SizeChanged);
            this.pnl_CustomArrow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_frame)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_CustomArrow;
        private System.Windows.Forms.PictureBox pbox_frame;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnl_ArrowWidth;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ArrowWdCount;
        private System.Windows.Forms.Label lbl_ArrowWidthLength;
        private System.Windows.Forms.Button btn_AddArrowHeadWidth;
        private System.Windows.Forms.Panel pnl_ArrowHeight;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_ArrowHtCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_AddArrowHeadHeight;
        private System.Windows.Forms.Label lbl_ArrowHeightLength;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_SaveCustomArrow;
    }
}