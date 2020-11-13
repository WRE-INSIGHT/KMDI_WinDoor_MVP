namespace PresentationLayer.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnl_btnContainer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pboxLoading = new System.Windows.Forms.PictureBox();
            this.chk_Remember = new System.Windows.Forms.CheckBox();
            this.btn_OffLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_btnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(93, 138);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(216, 25);
            this.txtPass.TabIndex = 15;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(13, 141);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 19);
            this.lblPass.TabIndex = 14;
            this.lblPass.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(93, 109);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(216, 25);
            this.txtUser.TabIndex = 13;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(13, 112);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(71, 19);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(85, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_btnContainer
            // 
            this.pnl_btnContainer.Controls.Add(this.btnLogin);
            this.pnl_btnContainer.Controls.Add(this.btnCancel);
            this.pnl_btnContainer.Location = new System.Drawing.Point(153, 193);
            this.pnl_btnContainer.Name = "pnl_btnContainer";
            this.pnl_btnContainer.Size = new System.Drawing.Size(163, 35);
            this.pnl_btnContainer.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pboxLoading
            // 
            this.pboxLoading.BackColor = System.Drawing.Color.Transparent;
            this.pboxLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxLoading.Image = global::PresentationLayer.Properties.Resources.loading2;
            this.pboxLoading.Location = new System.Drawing.Point(15, 12);
            this.pboxLoading.Name = "pboxLoading";
            this.pboxLoading.Size = new System.Drawing.Size(302, 217);
            this.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxLoading.TabIndex = 18;
            this.pboxLoading.TabStop = false;
            this.pboxLoading.Visible = false;
            // 
            // chk_Remember
            // 
            this.chk_Remember.AutoSize = true;
            this.chk_Remember.Location = new System.Drawing.Point(17, 171);
            this.chk_Remember.Name = "chk_Remember";
            this.chk_Remember.Size = new System.Drawing.Size(117, 23);
            this.chk_Remember.TabIndex = 20;
            this.chk_Remember.Text = "Remember me";
            this.chk_Remember.UseVisualStyleBackColor = true;
            // 
            // btn_OffLogin
            // 
            this.btn_OffLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_OffLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OffLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OffLogin.FlatAppearance.BorderSize = 0;
            this.btn_OffLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_OffLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OffLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OffLogin.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OffLogin.ForeColor = System.Drawing.Color.Blue;
            this.btn_OffLogin.Location = new System.Drawing.Point(10, 197);
            this.btn_OffLogin.Name = "btn_OffLogin";
            this.btn_OffLogin.Size = new System.Drawing.Size(137, 28);
            this.btn_OffLogin.TabIndex = 19;
            this.btn_OffLogin.Text = "No internet, Offline use";
            this.btn_OffLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OffLogin.UseVisualStyleBackColor = true;
            this.btn_OffLogin.Click += new System.EventHandler(this.btn_OffLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.K_M_logo_official_2018_1;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // LoginView
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(326, 241);
            this.Controls.Add(this.pboxLoading);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pnl_btnContainer);
            this.Controls.Add(this.chk_Remember);
            this.Controls.Add(this.btn_OffLogin);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costing Login";
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.pnl_btnContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnl_btnContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pboxLoading;
        private System.Windows.Forms.CheckBox chk_Remember;
        public System.Windows.Forms.Button btn_OffLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}