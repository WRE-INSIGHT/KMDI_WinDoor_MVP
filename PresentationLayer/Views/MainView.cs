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
    public partial class MainView : Form, IMainView
    {
        public string Nickname
        {
            set
            {
                tsLbl_Welcome.Text = "Welcome, " + value;
            }
        }

        public event EventHandler MainViewLoadEventRaised;
        public event EventHandler MainViewClosingEventRaised;

        public MainView()
        {
            InitializeComponent();
        }

        public void ShowMainView()
        {
            this.Show();
        }
        
        private void MainView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, MainViewLoadEventRaised, e);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, MainViewClosingEventRaised, e);
        }
    }
}
