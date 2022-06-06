namespace PresentationLayer.Views
{
    partial class CostEngrLandingView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostEngrLandingView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_nav = new System.Windows.Forms.Label();
            this.btn_forwardNav = new System.Windows.Forms.Button();
            this.btn_backNav = new System.Windows.Forms.Button();
            this.tab_Nav = new System.Windows.Forms.TabControl();
            this.tabPage_ProjectAssigned = new System.Windows.Forms.TabPage();
            this.dgv_AssignedProjects = new System.Windows.Forms.DataGridView();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_SearchProj = new System.Windows.Forms.Button();
            this.txt_SearchProj = new System.Windows.Forms.TextBox();
            this.tabPage_CustRef = new System.Windows.Forms.TabPage();
            this.dgv_CustRefNo = new System.Windows.Forms.DataGridView();
            this.tabPage_Quotation = new System.Windows.Forms.TabPage();
            this.dgv_QuoteNo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_AddNewQuote = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tab_Nav.SuspendLayout();
            this.tabPage_ProjectAssigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssignedProjects)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.tabPage_CustRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustRefNo)).BeginInit();
            this.tabPage_Quotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuoteNo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbl_nav);
            this.panel1.Controls.Add(this.btn_forwardNav);
            this.panel1.Controls.Add(this.btn_backNav);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 29);
            this.panel1.TabIndex = 2;
            // 
            // lbl_nav
            // 
            this.lbl_nav.AutoSize = true;
            this.lbl_nav.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nav.Location = new System.Drawing.Point(67, 5);
            this.lbl_nav.Name = "lbl_nav";
            this.lbl_nav.Size = new System.Drawing.Size(56, 19);
            this.lbl_nav.TabIndex = 4;
            this.lbl_nav.Text = "lbl_nav";
            // 
            // btn_forwardNav
            // 
            this.btn_forwardNav.BackColor = System.Drawing.SystemColors.Control;
            this.btn_forwardNav.BackgroundImage = global::PresentationLayer.Properties.Resources.disabled_forward_button_104px;
            this.btn_forwardNav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_forwardNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_forwardNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_forwardNav.Enabled = false;
            this.btn_forwardNav.FlatAppearance.BorderSize = 0;
            this.btn_forwardNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_forwardNav.Location = new System.Drawing.Point(31, 0);
            this.btn_forwardNav.Name = "btn_forwardNav";
            this.btn_forwardNav.Size = new System.Drawing.Size(31, 29);
            this.btn_forwardNav.TabIndex = 3;
            this.btn_forwardNav.UseVisualStyleBackColor = false;
            this.btn_forwardNav.Click += new System.EventHandler(this.btn_forwardNav_Click);
            // 
            // btn_backNav
            // 
            this.btn_backNav.BackColor = System.Drawing.SystemColors.Control;
            this.btn_backNav.BackgroundImage = global::PresentationLayer.Properties.Resources.disabled_back_arrow_104px;
            this.btn_backNav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_backNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_backNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_backNav.Enabled = false;
            this.btn_backNav.FlatAppearance.BorderSize = 0;
            this.btn_backNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_backNav.Location = new System.Drawing.Point(0, 0);
            this.btn_backNav.Name = "btn_backNav";
            this.btn_backNav.Size = new System.Drawing.Size(31, 29);
            this.btn_backNav.TabIndex = 2;
            this.btn_backNav.UseVisualStyleBackColor = false;
            this.btn_backNav.Click += new System.EventHandler(this.btn_backNav_Click);
            // 
            // tab_Nav
            // 
            this.tab_Nav.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_Nav.Controls.Add(this.tabPage_ProjectAssigned);
            this.tab_Nav.Controls.Add(this.tabPage_CustRef);
            this.tab_Nav.Controls.Add(this.tabPage_Quotation);
            this.tab_Nav.Location = new System.Drawing.Point(0, 5);
            this.tab_Nav.Name = "tab_Nav";
            this.tab_Nav.SelectedIndex = 0;
            this.tab_Nav.Size = new System.Drawing.Size(784, 556);
            this.tab_Nav.TabIndex = 3;
            // 
            // tabPage_ProjectAssigned
            // 
            this.tabPage_ProjectAssigned.Controls.Add(this.dgv_AssignedProjects);
            this.tabPage_ProjectAssigned.Controls.Add(this.pnl_top);
            this.tabPage_ProjectAssigned.Location = new System.Drawing.Point(4, 26);
            this.tabPage_ProjectAssigned.Name = "tabPage_ProjectAssigned";
            this.tabPage_ProjectAssigned.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ProjectAssigned.Size = new System.Drawing.Size(776, 526);
            this.tabPage_ProjectAssigned.TabIndex = 0;
            this.tabPage_ProjectAssigned.Text = "tabPage_ProjectAssigned";
            this.tabPage_ProjectAssigned.UseVisualStyleBackColor = true;
            // 
            // dgv_AssignedProjects
            // 
            this.dgv_AssignedProjects.AllowUserToAddRows = false;
            this.dgv_AssignedProjects.AllowUserToDeleteRows = false;
            this.dgv_AssignedProjects.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_AssignedProjects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_AssignedProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AssignedProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_AssignedProjects.Location = new System.Drawing.Point(3, 32);
            this.dgv_AssignedProjects.Name = "dgv_AssignedProjects";
            this.dgv_AssignedProjects.ReadOnly = true;
            this.dgv_AssignedProjects.Size = new System.Drawing.Size(770, 491);
            this.dgv_AssignedProjects.TabIndex = 6;
            this.dgv_AssignedProjects.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_AssignedProjects_CellMouseDoubleClick);
            this.dgv_AssignedProjects.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AssignedProjects_RowPostPaint);
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.btn_SearchProj);
            this.pnl_top.Controls.Add(this.txt_SearchProj);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(3, 3);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(770, 29);
            this.pnl_top.TabIndex = 2;
            // 
            // btn_SearchProj
            // 
            this.btn_SearchProj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SearchProj.BackgroundImage = global::PresentationLayer.Properties.Resources.search_filled_100px;
            this.btn_SearchProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SearchProj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchProj.Location = new System.Drawing.Point(693, 0);
            this.btn_SearchProj.Name = "btn_SearchProj";
            this.btn_SearchProj.Size = new System.Drawing.Size(77, 29);
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
            this.txt_SearchProj.Size = new System.Drawing.Size(693, 29);
            this.txt_SearchProj.TabIndex = 0;
            // 
            // tabPage_CustRef
            // 
            this.tabPage_CustRef.Controls.Add(this.dgv_CustRefNo);
            this.tabPage_CustRef.Location = new System.Drawing.Point(4, 26);
            this.tabPage_CustRef.Name = "tabPage_CustRef";
            this.tabPage_CustRef.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_CustRef.Size = new System.Drawing.Size(352, 526);
            this.tabPage_CustRef.TabIndex = 1;
            this.tabPage_CustRef.Text = "tabPage_CustRef";
            this.tabPage_CustRef.UseVisualStyleBackColor = true;
            // 
            // dgv_CustRefNo
            // 
            this.dgv_CustRefNo.AllowUserToAddRows = false;
            this.dgv_CustRefNo.AllowUserToDeleteRows = false;
            this.dgv_CustRefNo.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.dgv_CustRefNo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_CustRefNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustRefNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CustRefNo.Location = new System.Drawing.Point(3, 3);
            this.dgv_CustRefNo.Name = "dgv_CustRefNo";
            this.dgv_CustRefNo.ReadOnly = true;
            this.dgv_CustRefNo.Size = new System.Drawing.Size(346, 520);
            this.dgv_CustRefNo.TabIndex = 7;
            this.dgv_CustRefNo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CustRefNo_CellMouseDoubleClick);
            this.dgv_CustRefNo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_CustRefNo_RowPostPaint);
            // 
            // tabPage_Quotation
            // 
            this.tabPage_Quotation.Controls.Add(this.dgv_QuoteNo);
            this.tabPage_Quotation.Controls.Add(this.panel2);
            this.tabPage_Quotation.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Quotation.Name = "tabPage_Quotation";
            this.tabPage_Quotation.Size = new System.Drawing.Size(352, 526);
            this.tabPage_Quotation.TabIndex = 2;
            this.tabPage_Quotation.Text = "tabPage1";
            this.tabPage_Quotation.UseVisualStyleBackColor = true;
            // 
            // dgv_QuoteNo
            // 
            this.dgv_QuoteNo.AllowUserToAddRows = false;
            this.dgv_QuoteNo.AllowUserToDeleteRows = false;
            this.dgv_QuoteNo.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dgv_QuoteNo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_QuoteNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QuoteNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_QuoteNo.Location = new System.Drawing.Point(0, 29);
            this.dgv_QuoteNo.Name = "dgv_QuoteNo";
            this.dgv_QuoteNo.ReadOnly = true;
            this.dgv_QuoteNo.Size = new System.Drawing.Size(352, 497);
            this.dgv_QuoteNo.TabIndex = 8;
            this.dgv_QuoteNo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_QuoteNo_CellMouseDoubleClick);
            this.dgv_QuoteNo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_QuoteNo_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.btn_AddNewQuote);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 29);
            this.panel2.TabIndex = 9;
            // 
            // btn_AddNewQuote
            // 
            this.btn_AddNewQuote.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_AddNewQuote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddNewQuote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddNewQuote.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_AddNewQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewQuote.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AddNewQuote.Location = new System.Drawing.Point(265, 0);
            this.btn_AddNewQuote.Name = "btn_AddNewQuote";
            this.btn_AddNewQuote.Size = new System.Drawing.Size(87, 29);
            this.btn_AddNewQuote.TabIndex = 1;
            this.btn_AddNewQuote.Text = "+ Add new ";
            this.btn_AddNewQuote.UseVisualStyleBackColor = false;
            this.btn_AddNewQuote.Click += new System.EventHandler(this.btn_AddNewQuote_Click);
            // 
            // CostEngrLandingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tab_Nav);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostEngrLandingView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assigned Projects";
            this.Load += new System.EventHandler(this.CostEngrLandingView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab_Nav.ResumeLayout(false);
            this.tabPage_ProjectAssigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssignedProjects)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.tabPage_CustRef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustRefNo)).EndInit();
            this.tabPage_Quotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuoteNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_backNav;
        private System.Windows.Forms.Button btn_forwardNav;
        private System.Windows.Forms.Label lbl_nav;
        private System.Windows.Forms.TabControl tab_Nav;
        private System.Windows.Forms.TabPage tabPage_ProjectAssigned;
        private System.Windows.Forms.TabPage tabPage_CustRef;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_SearchProj;
        private System.Windows.Forms.TextBox txt_SearchProj;
        private System.Windows.Forms.DataGridView dgv_AssignedProjects;
        private System.Windows.Forms.DataGridView dgv_CustRefNo;
        private System.Windows.Forms.TabPage tabPage_Quotation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_AddNewQuote;
        private System.Windows.Forms.DataGridView dgv_QuoteNo;
    }
}