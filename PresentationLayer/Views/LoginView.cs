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
        public event EventHandler LoginBtnClickEventRaised;

        public void ShowLoginView()
        {
            this.Show();
        }
        public LoginView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, LoginBtnClickEventRaised, e);
        }
    }
}
