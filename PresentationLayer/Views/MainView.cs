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
        public event EventHandler MainViewLoadEventRaised;
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
    }
}
