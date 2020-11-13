using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public string username
        {
            get
            {
                return txtUser.Text;
            }

            set
            {
                txtUser.Text = value;
            }
        }

        public string password
        {
            get
            {
                return txtPass.Text;
            }

            set
            {
                txtPass.Text = value;
            }
        }

        public bool pboxVisibility
        {
            get
            {
                return pboxLoading.Visible;
            }

            set
            {
                pboxLoading.Visible = value;
            }
        }

        public bool frmVisibility
        {
            set
            {
                this.Visible = value;
            }
        }

        public bool chkRememberMe
        {
            set
            {
                chk_Remember.Checked = value;
            }
        }

        bool ILoginView.chkRememberMe
        {
            get
            {
                return chk_Remember.Checked;
            }

            set
            {
                chk_Remember.Checked = value;
            }
        }

        public event EventHandler LoginBtnClickEventRaised;
        public event EventHandler CancelBtnClickEventRaised;
        public event EventHandler OffLoginBtnClickEventRaised;
        public event EventHandler FormLoadEventRaised;

        public void ShowLoginView()
        {
            this.Show();
        }
        public void CloseLoginView()
        {
            this.Close();
        }
        public LoginView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, LoginBtnClickEventRaised, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, CancelBtnClickEventRaised, e);
        }

        private void btn_OffLogin_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, OffLoginBtnClickEventRaised, e);
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, FormLoadEventRaised, e);
        }
    }
}
