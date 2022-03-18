using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CostEngrLandingView : Form, ICostEngrLandingView
    {
        public CostEngrLandingView()
        {
            InitializeComponent();
        }

        public event EventHandler CostEngrLandingViewLoadEventRaised;

        public void ShowThis()
        {
            this.ShowDialog();
        }

        private void CostEngrLandingView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CostEngrLandingViewLoadEventRaised, e);
        }

        private void btn_backNav_Click(object sender, EventArgs e)
        {
            tab_Nav.SelectedIndex = (tab_Nav.SelectedIndex > 0) ? tab_Nav.SelectedIndex - 1 : 0;
        }

        private void btn_forwardNav_Click(object sender, EventArgs e)
        {
            tab_Nav.SelectedIndex += 1;
        }
    }
}
