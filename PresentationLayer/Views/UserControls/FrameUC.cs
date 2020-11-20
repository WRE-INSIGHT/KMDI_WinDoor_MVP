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

        public FrameUC()
        {
            InitializeComponent();
        }

        public event EventHandler frameLoadEventRaised;
        public event PaintEventHandler innerFramePaintEventRaised;
        public event PaintEventHandler outerFramePaintEventRaised;

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
    }
}
