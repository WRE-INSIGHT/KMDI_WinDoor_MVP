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
        public event EventHandler TopViewPanelViewButtonClickEventRaised;
        public event PaintEventHandler pnlSlidingArrowPaintEventRaised;
        public event PaintEventHandler pboxTopViewPaintEventRaised;
        public event MouseEventHandler TopViewSlidingViewMouseUpEventRaised;
        public event EventHandler TopViewPanelViewSizeChangedEventRaised;


        public string topviewpanel_title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public void showTopViewPanelViewer()
        {
            //  try
            //  {
            //      if (Screen.AllScreens.Length > 1)
            //      {
            //          this.Location = Screen.AllScreens[1].WorkingArea.Location;
            //          this.Show();
            //      }
            //      else
            //      {
            //          this.Show();
            //      }
            //  }
            //  catch (Exception ex)
            //  {
            //      Console.WriteLine(this + " " + ex.Message);
            //  }
            this.Show();
        }
        public void CloseTopViewPanelViewer()
        {
            this.Close();
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
        public PictureBox GetPnlPanelViewer()
        {
            return pbox_panels;
        }
        public void TopView_BringtoFront()
        {
            this.Focus();
        }
        private void TopViewPanelViewer_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewPanelViewLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            pbox_panels.DataBindings.Add(ModelBinding["pnlTopViewer"]);
        }

        private void panel_topviewer_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, pnlSlidingArrowPaintEventRaised, e);
        }

        private void TopViewPanelViewer_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, TopViewSlidingViewMouseUpEventRaised, e);
        }

        private void pbox_panels_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, pboxTopViewPaintEventRaised, e);
        }

        private void TopViewPanelViewerNewButton_Clicked(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewPanelViewButtonClickEventRaised, e);
        }

        private void TopViewPanelViewer_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewPanelViewSizeChangedEventRaised, e);
        }
    }
}
