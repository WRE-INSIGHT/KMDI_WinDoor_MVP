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
    public partial class TopView : Form, ITopView
    {
        public TopView()
        {
            InitializeComponent();
        }

        public event EventHandler TopViewSlidingViewLoadEventRaised;
        public event EventHandler FormTimerTickEventRaised;
        public event EventHandler TopViewSlidingViewButtonClickEventRaised;
        public event PaintEventHandler TopViewPaintEventRaised;
        public event MouseEventHandler TopViewSlidingViewMouseMoveEventRaised;
        public event MouseEventHandler TopViewSlidingViewMouseUpEventRaised;
        public event MouseEventHandler TopViewSlidingViewMouseDownEventRaised;
        public event EventHandler TopViewSlidingViewMouseHoverEventRaised;
        public event MouseEventHandler TopViewSlidingViewMouseClickEventRaised;




        public void ShowTopView()
        {
            //   try
            //   {
            //       if (Screen.AllScreens.Length > 1)
            //       {
            //           this.Location = Screen.AllScreens[1].WorkingArea.Location;
            //           this.Show();
            //       }
            //       else
            //       {
            //           this.Show();
            //       }
            //   }
            //   catch (Exception ex)
            //   {
            //       Console.WriteLine(this + " " + ex.Message);
            //   }
            this.ShowDialog();
        }
        private void FormTimerTickEvent(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, FormTimerTickEventRaised, e);
        }
        public PictureBox GetPbox()
        {
            return pbox_Frame;
        }
        public Label GetLabelTracks()
        {
            return lbl_Tracks;
        }
        public Label GetLabelPanel()
        {
            return lbl_Panels;
        }
        public ContextMenuStrip GetcmenuTopView()
        {
            return cmenu_TopViewProperties;
        }

        public void CloseTopView()
        {
            this.Close();
        }
        public Form GetThis()
        {
            return this;
        }

        private void TopView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewSlidingViewLoadEventRaised, e);
        }

        private void pbox_Frame_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, TopViewPaintEventRaised, e);
        }

        private void pbox_Frame_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, TopViewSlidingViewMouseMoveEventRaised, e);
        }

        private void TopView_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pbox_Frame_MouseClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, TopViewSlidingViewMouseClickEventRaised, e);
        }

        private void btn_TVSave_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TopViewSlidingViewButtonClickEventRaised, e);
        }
    }
}
