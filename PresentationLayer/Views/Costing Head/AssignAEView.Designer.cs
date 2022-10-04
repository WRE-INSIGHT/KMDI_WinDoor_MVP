namespace PresentationLayer.Views.Costing_Head
{
    partial class AssignAEView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmenu_dgvClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assignAEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lListofAE = new System.Windows.Forms.Label();
            this.btnEqual = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SearchProj = new System.Windows.Forms.Button();
            this.txt_SearchClientStr = new System.Windows.Forms.TextBox();
            this.btn_SearchAEIC = new System.Windows.Forms.Button();
            this.txt_SearchAEICStr = new System.Windows.Forms.TextBox();
            this.dgv_Client = new System.Windows.Forms.DataGridView();
            this.dgv_AEIC = new System.Windows.Forms.DataGridView();
            this.dgv_Project = new System.Windows.Forms.DataGridView();
            this.cmenu_dgvProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Save = new System.Windows.Forms.Button();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AEICName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenu_dgvClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AEIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Project)).BeginInit();
            this.cmenu_dgvProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_dgvClient
            // 
            this.cmenu_dgvClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignAEToolStripMenuItem});
            this.cmenu_dgvClient.Name = "contextMenuStrip1";
            this.cmenu_dgvClient.Size = new System.Drawing.Size(137, 26);
            // 
            // assignAEToolStripMenuItem
            // 
            this.assignAEToolStripMenuItem.Name = "assignAEToolStripMenuItem";
            this.assignAEToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.assignAEToolStripMenuItem.Text = "Add Project";
            this.assignAEToolStripMenuItem.Click += new System.EventHandler(this.assignAEToolStripMenuItem_Click);
            // 
            // lListofAE
            // 
            this.lListofAE.AutoSize = true;
            this.lListofAE.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lListofAE.Location = new System.Drawing.Point(281, 229);
            this.lListofAE.Name = "lListofAE";
            this.lListofAE.Size = new System.Drawing.Size(52, 55);
            this.lListofAE.TabIndex = 95;
            this.lListofAE.Text = "+";
            // 
            // btnEqual
            // 
            this.btnEqual.AutoSize = true;
            this.btnEqual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(80)))));
            this.btnEqual.FlatAppearance.BorderSize = 0;
            this.btnEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqual.Location = new System.Drawing.Point(608, 224);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(62, 65);
            this.btnEqual.TabIndex = 96;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 98;
            this.label1.Text = "Client ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 99;
            this.label2.Text = "AEIC";
            // 
            // btn_SearchProj
            // 
            this.btn_SearchProj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SearchProj.BackgroundImage = global::PresentationLayer.Properties.Resources.search_filled_100px;
            this.btn_SearchProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SearchProj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchProj.Location = new System.Drawing.Point(240, 64);
            this.btn_SearchProj.Name = "btn_SearchProj";
            this.btn_SearchProj.Size = new System.Drawing.Size(35, 29);
            this.btn_SearchProj.TabIndex = 101;
            this.btn_SearchProj.UseVisualStyleBackColor = false;
            this.btn_SearchProj.Click += new System.EventHandler(this.btn_SearchProj_Click);
            // 
            // txt_SearchClientStr
            // 
            this.txt_SearchClientStr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchClientStr.Location = new System.Drawing.Point(12, 63);
            this.txt_SearchClientStr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SearchClientStr.Name = "txt_SearchClientStr";
            this.txt_SearchClientStr.Size = new System.Drawing.Size(228, 29);
            this.txt_SearchClientStr.TabIndex = 100;
            this.txt_SearchClientStr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SearchClientStr_KeyDown);
            // 
            // btn_SearchAEIC
            // 
            this.btn_SearchAEIC.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SearchAEIC.BackgroundImage = global::PresentationLayer.Properties.Resources.search_filled_100px;
            this.btn_SearchAEIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SearchAEIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchAEIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchAEIC.Location = new System.Drawing.Point(567, 64);
            this.btn_SearchAEIC.Name = "btn_SearchAEIC";
            this.btn_SearchAEIC.Size = new System.Drawing.Size(35, 29);
            this.btn_SearchAEIC.TabIndex = 103;
            this.btn_SearchAEIC.UseVisualStyleBackColor = false;
            this.btn_SearchAEIC.Click += new System.EventHandler(this.btn_SearchAEIC_Click);
            // 
            // txt_SearchAEICStr
            // 
            this.txt_SearchAEICStr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchAEICStr.Location = new System.Drawing.Point(339, 63);
            this.txt_SearchAEICStr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SearchAEICStr.Name = "txt_SearchAEICStr";
            this.txt_SearchAEICStr.Size = new System.Drawing.Size(228, 29);
            this.txt_SearchAEICStr.TabIndex = 102;
            this.txt_SearchAEICStr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SearchAEICStr_KeyDown);
            // 
            // dgv_Client
            // 
            this.dgv_Client.AllowUserToAddRows = false;
            this.dgv_Client.AllowUserToDeleteRows = false;
            this.dgv_Client.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_Client.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Client.ContextMenuStrip = this.cmenu_dgvClient;
            this.dgv_Client.Location = new System.Drawing.Point(12, 93);
            this.dgv_Client.Name = "dgv_Client";
            this.dgv_Client.ReadOnly = true;
            this.dgv_Client.Size = new System.Drawing.Size(263, 328);
            this.dgv_Client.TabIndex = 104;
            this.dgv_Client.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Client_RowPostPaint);
            // 
            // dgv_AEIC
            // 
            this.dgv_AEIC.AllowUserToAddRows = false;
            this.dgv_AEIC.AllowUserToDeleteRows = false;
            this.dgv_AEIC.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.dgv_AEIC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_AEIC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AEIC.Location = new System.Drawing.Point(339, 93);
            this.dgv_AEIC.Name = "dgv_AEIC";
            this.dgv_AEIC.ReadOnly = true;
            this.dgv_AEIC.Size = new System.Drawing.Size(263, 328);
            this.dgv_AEIC.TabIndex = 105;
            this.dgv_AEIC.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AEIC_RowPostPaint);
            // 
            // dgv_Project
            // 
            this.dgv_Project.AllowUserToAddRows = false;
            this.dgv_Project.AllowUserToDeleteRows = false;
            this.dgv_Project.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dgv_Project.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Project.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Project.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Project.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectName,
            this.AEICName,
            this.ProjectId,
            this.EmployeeId});
            this.dgv_Project.ContextMenuStrip = this.cmenu_dgvProject;
            this.dgv_Project.Location = new System.Drawing.Point(676, 93);
            this.dgv_Project.Name = "dgv_Project";
            this.dgv_Project.ReadOnly = true;
            this.dgv_Project.Size = new System.Drawing.Size(355, 328);
            this.dgv_Project.TabIndex = 106;
            this.dgv_Project.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Project_RowPostPaint);
            // 
            // cmenu_dgvProject
            // 
            this.cmenu_dgvProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletetoolStripMenuItem});
            this.cmenu_dgvProject.Name = "contextMenuStrip1";
            this.cmenu_dgvProject.Size = new System.Drawing.Size(108, 26);
            // 
            // deletetoolStripMenuItem
            // 
            this.deletetoolStripMenuItem.Name = "deletetoolStripMenuItem";
            this.deletetoolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deletetoolStripMenuItem.Text = "Delete";
            this.deletetoolStripMenuItem.Click += new System.EventHandler(this.deletetoolStripMenuItem_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Save.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(958, 427);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 38);
            this.btn_Save.TabIndex = 107;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ProjectName.HeaderText = "Project Name";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Width = 139;
            // 
            // AEICName
            // 
            this.AEICName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AEICName.HeaderText = "AEIC";
            this.AEICName.Name = "AEICName";
            this.AEICName.ReadOnly = true;
            this.AEICName.Width = 70;
            // 
            // ProjectId
            // 
            this.ProjectId.HeaderText = "ProjectId";
            this.ProjectId.Name = "ProjectId";
            this.ProjectId.ReadOnly = true;
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "AEICId";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            // 
            // AssignAEView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 474);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgv_Project);
            this.Controls.Add(this.dgv_AEIC);
            this.Controls.Add(this.dgv_Client);
            this.Controls.Add(this.btn_SearchAEIC);
            this.Controls.Add(this.txt_SearchAEICStr);
            this.Controls.Add(this.btn_SearchProj);
            this.Controls.Add(this.txt_SearchClientStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.lListofAE);
            this.Name = "AssignAEView";
            this.Text = "Assign AE";
            this.Load += new System.EventHandler(this.AssignAE_Load);
            this.cmenu_dgvClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AEIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Project)).EndInit();
            this.cmenu_dgvProject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lListofAE;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmenu_dgvClient;
        private System.Windows.Forms.ToolStripMenuItem assignAEToolStripMenuItem;
        private System.Windows.Forms.Button btn_SearchProj;
        private System.Windows.Forms.TextBox txt_SearchClientStr;
        private System.Windows.Forms.Button btn_SearchAEIC;
        private System.Windows.Forms.TextBox txt_SearchAEICStr;
        private System.Windows.Forms.DataGridView dgv_Client;
        private System.Windows.Forms.DataGridView dgv_AEIC;
        private System.Windows.Forms.DataGridView dgv_Project;
        private System.Windows.Forms.ContextMenuStrip cmenu_dgvProject;
        private System.Windows.Forms.ToolStripMenuItem deletetoolStripMenuItem;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AEICName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
    }
}