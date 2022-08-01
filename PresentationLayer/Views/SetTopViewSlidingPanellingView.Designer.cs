namespace PresentationLayer.Views
{
    partial class SetTopViewSlidingPanellingView
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
            this.pnl_SlidingTopView = new System.Windows.Forms.Panel();
            this.pnl_panelling = new System.Windows.Forms.Panel();
            this.pnl_right = new System.Windows.Forms.Panel();
            this.btnMinusRightLine = new System.Windows.Forms.Button();
            this.btnAddRightLine = new System.Windows.Forms.Button();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.btnMinusLeftLine = new System.Windows.Forms.Button();
            this.btnAddLeftLine = new System.Windows.Forms.Button();
            this.pbox_frame = new System.Windows.Forms.PictureBox();
            this.pnl_SlidingArrow = new System.Windows.Forms.Panel();
            this.pnl_SlidingTopView.SuspendLayout();
            this.pnl_right.SuspendLayout();
            this.pnl_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_frame)).BeginInit();
            this.pnl_SlidingArrow.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_SlidingTopView
            // 
            this.pnl_SlidingTopView.Controls.Add(this.pnl_panelling);
            this.pnl_SlidingTopView.Controls.Add(this.pnl_right);
            this.pnl_SlidingTopView.Controls.Add(this.pnl_left);
            this.pnl_SlidingTopView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_SlidingTopView.Location = new System.Drawing.Point(0, 401);
            this.pnl_SlidingTopView.Name = "pnl_SlidingTopView";
            this.pnl_SlidingTopView.Size = new System.Drawing.Size(474, 127);
            this.pnl_SlidingTopView.TabIndex = 0;
            // 
            // pnl_panelling
            // 
            this.pnl_panelling.BackColor = System.Drawing.Color.White;
            this.pnl_panelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_panelling.Location = new System.Drawing.Point(45, 0);
            this.pnl_panelling.Name = "pnl_panelling";
            this.pnl_panelling.Size = new System.Drawing.Size(384, 127);
            this.pnl_panelling.TabIndex = 2;
            this.pnl_panelling.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_panelling_Paint);
            // 
            // pnl_right
            // 
            this.pnl_right.Controls.Add(this.btnMinusRightLine);
            this.pnl_right.Controls.Add(this.btnAddRightLine);
            this.pnl_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_right.Location = new System.Drawing.Point(429, 0);
            this.pnl_right.Name = "pnl_right";
            this.pnl_right.Size = new System.Drawing.Size(45, 127);
            this.pnl_right.TabIndex = 1;
            // 
            // btnMinusRightLine
            // 
            this.btnMinusRightLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinusRightLine.Location = new System.Drawing.Point(0, 64);
            this.btnMinusRightLine.Name = "btnMinusRightLine";
            this.btnMinusRightLine.Size = new System.Drawing.Size(45, 64);
            this.btnMinusRightLine.TabIndex = 3;
            this.btnMinusRightLine.Text = "-";
            this.btnMinusRightLine.UseVisualStyleBackColor = true;
            this.btnMinusRightLine.Click += new System.EventHandler(this.btnMinusRightLine_Click);
            // 
            // btnAddRightLine
            // 
            this.btnAddRightLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRightLine.Location = new System.Drawing.Point(0, 1);
            this.btnAddRightLine.Name = "btnAddRightLine";
            this.btnAddRightLine.Size = new System.Drawing.Size(45, 64);
            this.btnAddRightLine.TabIndex = 2;
            this.btnAddRightLine.Text = "+";
            this.btnAddRightLine.UseVisualStyleBackColor = true;
            this.btnAddRightLine.Click += new System.EventHandler(this.btnAddRightLine_Click);
            // 
            // pnl_left
            // 
            this.pnl_left.Controls.Add(this.btnMinusLeftLine);
            this.pnl_left.Controls.Add(this.btnAddLeftLine);
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(45, 127);
            this.pnl_left.TabIndex = 0;
            // 
            // btnMinusLeftLine
            // 
            this.btnMinusLeftLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinusLeftLine.Location = new System.Drawing.Point(0, 63);
            this.btnMinusLeftLine.Name = "btnMinusLeftLine";
            this.btnMinusLeftLine.Size = new System.Drawing.Size(45, 64);
            this.btnMinusLeftLine.TabIndex = 1;
            this.btnMinusLeftLine.Text = "-";
            this.btnMinusLeftLine.UseVisualStyleBackColor = true;
            this.btnMinusLeftLine.Click += new System.EventHandler(this.btnMinusLeftLine_Click);
            // 
            // btnAddLeftLine
            // 
            this.btnAddLeftLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLeftLine.Location = new System.Drawing.Point(0, 0);
            this.btnAddLeftLine.Name = "btnAddLeftLine";
            this.btnAddLeftLine.Size = new System.Drawing.Size(45, 64);
            this.btnAddLeftLine.TabIndex = 0;
            this.btnAddLeftLine.Text = "+";
            this.btnAddLeftLine.UseVisualStyleBackColor = true;
            this.btnAddLeftLine.Click += new System.EventHandler(this.btnAddLeftLine_Click);
            // 
            // pbox_frame
            // 
            this.pbox_frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_frame.Location = new System.Drawing.Point(70, 35);
            this.pbox_frame.Name = "pbox_frame";
            this.pbox_frame.Size = new System.Drawing.Size(404, 366);
            this.pbox_frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_frame.TabIndex = 0;
            this.pbox_frame.TabStop = false;
            // 
            // pnl_SlidingArrow
            // 
            this.pnl_SlidingArrow.BackColor = System.Drawing.Color.White;
            this.pnl_SlidingArrow.Controls.Add(this.pbox_frame);
            this.pnl_SlidingArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_SlidingArrow.Location = new System.Drawing.Point(0, 0);
            this.pnl_SlidingArrow.Name = "pnl_SlidingArrow";
            this.pnl_SlidingArrow.Padding = new System.Windows.Forms.Padding(70, 35, 0, 0);
            this.pnl_SlidingArrow.Size = new System.Drawing.Size(474, 401);
            this.pnl_SlidingArrow.TabIndex = 16;
            this.pnl_SlidingArrow.SizeChanged += new System.EventHandler(this.pnl_SlidingArrow_SizeChanged);
            this.pnl_SlidingArrow.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_SlidingArrow_Paint);
            // 
            // SetTopViewSlidingPanellingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 528);
            this.Controls.Add(this.pnl_SlidingArrow);
            this.Controls.Add(this.pnl_SlidingTopView);
            this.Name = "SetTopViewSlidingPanellingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetTopSlidingPanellingView";
            this.Load += new System.EventHandler(this.SetTopViewSlidingPanellingView_Load);
            this.pnl_SlidingTopView.ResumeLayout(false);
            this.pnl_right.ResumeLayout(false);
            this.pnl_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_frame)).EndInit();
            this.pnl_SlidingArrow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_SlidingTopView;
        private System.Windows.Forms.PictureBox pbox_frame;
        private System.Windows.Forms.Panel pnl_SlidingArrow;
        private System.Windows.Forms.Panel pnl_panelling;
        private System.Windows.Forms.Panel pnl_right;
        private System.Windows.Forms.Button btnMinusRightLine;
        private System.Windows.Forms.Button btnAddRightLine;
        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.Button btnMinusLeftLine;
        private System.Windows.Forms.Button btnAddLeftLine;
    }
}