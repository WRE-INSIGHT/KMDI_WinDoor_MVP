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
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class TopViewPanelViewer : Form, ITopViewPanelViewer
    {
        public TopViewPanelViewer()
        {
            InitializeComponent();
        }
        public event EventHandler TopViewPanelViewLoadEventRaised;
        public event PaintEventHandler pnlSlidingArrowPaintEventRaised;

        public void showTopViewPanelViewer()
        {
              try
              {
                  if (Screen.AllScreens.Length > 1)
                  {
                      this.Location = Screen.AllScreens[1].WorkingArea.Location;
                      this.Show();
                  }
                  else
                  {
                      this.Show();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(this + " " + ex.Message);
              }
            //this.Show();
        }
        public Form GetTopViewPanelViewer()
        {
            return this;
        }
        public PictureBox GetTopViewPictureBox()
        {
            return pbox_TopView;
        }
        public Panel GetPnlTopViewer()
        {
            return panel_topviewer;
        }

        private void TopViewPanelViewer_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewPanelViewLoadEventRaised, e);
        }

        private void panel_topviewer_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, pnlSlidingArrowPaintEventRaised, e);
        }
    }
}
