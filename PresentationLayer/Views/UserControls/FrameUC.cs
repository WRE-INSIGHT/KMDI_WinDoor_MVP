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

namespace PresentationLayer.Views.UserControls
{
    public partial class FrameUC : UserControl, IFrameUC
    {
        public int fWidth
        {
            get
            {
                return this.Width;
            }

            set
            {
                this.Width = value;
            }
        }

        public int fHeight
        {
            get
            {
                return this.Height;
            }

            set
            {
                this.Height = value;
            }
        }

        public int fPadding
        {
            set
            {
                this.Padding = new Padding(value);
            }
        }

        public FrameUC()
        {
            InitializeComponent();
        }

        public event EventHandler frameLoadEventRaised;
        public event PaintEventHandler innerFramePaintEventRaised;
        public event PaintEventHandler outerFramePaintEventRaised;
        public event MouseEventHandler frameMouseClickEventRaised;
        public event EventHandler deleteCmenuEventRaised;
        public event EventHandler frameMouseEnterEventRaised;
        public event EventHandler frameMouseLeaveEventRaised;
        public event EventHandler panelInnerMouseEnterEventRaised;
        public event EventHandler panelInnerMouseLeaveEventRaised;

        private void FrameUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, outerFramePaintEventRaised, e);
        }

        private void FrameUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, frameLoadEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void pnl_inner_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, innerFramePaintEventRaised, e);
        }

        private void frame_MouseClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, frameMouseClickEventRaised, e);
        }

        public ContextMenuStrip GetFrameCmenu()
        {
            return cmenu_frame;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteCmenuEventRaised, e);
        }

        private void FrameUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, frameMouseEnterEventRaised, e);
        }

        private void FrameUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, frameMouseLeaveEventRaised, e);
        }

        private void pnl_inner_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, panelInnerMouseEnterEventRaised, e);
        }

        private void pnl_inner_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, panelInnerMouseLeaveEventRaised, e);
        }
    }
}
