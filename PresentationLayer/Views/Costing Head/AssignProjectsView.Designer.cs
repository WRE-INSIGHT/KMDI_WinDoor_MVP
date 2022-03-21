namespace PresentationLayer.Views.Costing_Head
{
    partial class AssignProjectsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignProjectsView));
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_SearchProj = new System.Windows.Forms.Button();
            this.txt_SearchProj = new System.Windows.Forms.TextBox();
            this.dgv_Projects = new System.Windows.Forms.DataGridView();
            this.cmenu_dgvProj = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assignCostEngrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Projects)).BeginInit();
            this.cmenu_dgvProj.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.btn_SearchProj);
            this.pnl_top.Controls.Add(this.txt_SearchProj);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(784, 29);
            this.pnl_top.TabIndex = 3;
            // 
            // btn_SearchProj
            // 
            this.btn_SearchProj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SearchProj.BackgroundImage = global::PresentationLayer.Properties.Resources.search_filled_100px;
            this.btn_SearchProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SearchProj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchProj.Location = new System.Drawing.Point(754, 0);
            this.btn_SearchProj.Name = "btn_SearchProj";
            this.btn_SearchProj.Size = new System.Drawing.Size(30, 29);
            this.btn_SearchProj.TabIndex = 1;
            this.btn_SearchProj.UseVisualStyleBackColor = false;
            // 
            // txt_SearchProj
            // 
            this.txt_SearchProj.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_SearchProj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchProj.Location = new System.Drawing.Point(0, 0);
            this.txt_SearchProj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SearchProj.Name = "txt_SearchProj";
            this.txt_SearchProj.Size = new System.Drawing.Size(754, 29);
            this.txt_SearchProj.TabIndex = 0;
            // 
            // dgv_Projects
            // 
            this.dgv_Projects.AllowUserToAddRows = false;
            this.dgv_Projects.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_Projects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Projects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Projects.ContextMenuStrip = this.cmenu_dgvProj;
            this.dgv_Projects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Projects.Location = new System.Drawing.Point(0, 29);
            this.dgv_Projects.Name = "dgv_Projects";
            this.dgv_Projects.ReadOnly = true;
            this.dgv_Projects.Size = new System.Drawing.Size(784, 392);
            this.dgv_Projects.TabIndex = 4;
            this.dgv_Projects.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Projects_RowPostPaint);
            // 
            // cmenu_dgvProj
            // 
            this.cmenu_dgvProj.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignCostEngrToolStripMenuItem});
            this.cmenu_dgvProj.Name = "cmenu_dgvProj";
            this.cmenu_dgvProj.Size = new System.Drawing.Size(164, 26);
            // 
            // assignCostEngrToolStripMenuItem
            // 
            this.assignCostEngrToolStripMenuItem.Name = "assignCostEngrToolStripMenuItem";
            this.assignCostEngrToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.assignCostEngrToolStripMenuItem.Text = "Assign Cost Engr";
            // 
            // AssignProjectsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.dgv_Projects);
            this.Controls.Add(this.pnl_top);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignProjectsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Projects";
            this.Load += new System.EventHandler(this.AssignProjectsView_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Projects)).EndInit();
            this.cmenu_dgvProj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_SearchProj;
        private System.Windows.Forms.TextBox txt_SearchProj;
        private System.Windows.Forms.DataGridView dgv_Projects;
        private System.Windows.Forms.ContextMenuStrip cmenu_dgvProj;
        private System.Windows.Forms.ToolStripMenuItem assignCostEngrToolStripMenuItem;
    }
}