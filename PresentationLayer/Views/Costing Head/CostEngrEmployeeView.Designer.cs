namespace PresentationLayer.Views.Costing_Head
{
    partial class CostEngrEmployeeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostEngrEmployeeView));
            this.chkList_CE = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Status = new System.Windows.Forms.Panel();
            this.pbox_Loading = new System.Windows.Forms.PictureBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnl_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // chkList_CE
            // 
            this.chkList_CE.CheckOnClick = true;
            this.chkList_CE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkList_CE.FormattingEnabled = true;
            this.chkList_CE.HorizontalScrollbar = true;
            this.chkList_CE.Location = new System.Drawing.Point(0, 0);
            this.chkList_CE.Name = "chkList_CE";
            this.chkList_CE.Size = new System.Drawing.Size(284, 261);
            this.chkList_CE.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pnl_Status);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 38);
            this.panel1.TabIndex = 1;
            // 
            // pnl_Status
            // 
            this.pnl_Status.Controls.Add(this.pbox_Loading);
            this.pnl_Status.Controls.Add(this.lbl_Status);
            this.pnl_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Status.Location = new System.Drawing.Point(0, 0);
            this.pnl_Status.Name = "pnl_Status";
            this.pnl_Status.Size = new System.Drawing.Size(134, 38);
            this.pnl_Status.TabIndex = 2;
            this.pnl_Status.Visible = false;
            // 
            // pbox_Loading
            // 
            this.pbox_Loading.Image = global::PresentationLayer.Properties.Resources.loading_trans;
            this.pbox_Loading.Location = new System.Drawing.Point(0, 0);
            this.pbox_Loading.Name = "pbox_Loading";
            this.pbox_Loading.Size = new System.Drawing.Size(40, 38);
            this.pbox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_Loading.TabIndex = 1;
            this.pbox_Loading.TabStop = false;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(40, 12);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(88, 15);
            this.lbl_Status.TabIndex = 0;
            this.lbl_Status.Text = "Processing 2/3";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(134, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 38);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Accept.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Accept.FlatAppearance.BorderSize = 0;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.Location = new System.Drawing.Point(209, 0);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 38);
            this.btn_Accept.TabIndex = 0;
            this.btn_Accept.Text = "Accept";
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // CostEngrEmployeeView
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkList_CE);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostEngrEmployeeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Cost Engineer(s)";
            this.Load += new System.EventHandler(this.CostEngrEmployeeView_Load);
            this.panel1.ResumeLayout(false);
            this.pnl_Status.ResumeLayout(false);
            this.pnl_Status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkList_CE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_Status;
        private System.Windows.Forms.PictureBox pbox_Loading;
        private System.Windows.Forms.Label lbl_Status;
    }
}