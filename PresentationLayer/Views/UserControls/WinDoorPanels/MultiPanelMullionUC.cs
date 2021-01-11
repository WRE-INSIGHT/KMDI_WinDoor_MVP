using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class MultiPanelMullionUC : UserControl
    {
        public MultiPanelMullionUC()
        {
            InitializeComponent();
        }
        public event PaintEventHandler flpMulltiPaintEventRaised;

        private void flp_Multi_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
        }
    }
}
