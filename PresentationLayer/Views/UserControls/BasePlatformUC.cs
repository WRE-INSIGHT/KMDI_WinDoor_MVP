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
    public partial class BasePlatformUC : UserControl, IBasePlatformUC
    {
        public BasePlatformUC()
        {
            InitializeComponent();
        }

        public int bp_Height
        {
            get
            {
                return this.Height;
            }

            set
            {
                this.Height = value + 35;
            }
        }

        public int bp_Width
        {
            get
            {
                return this.Width;
            }

            set
            {
                this.Width = value + 70;
            }
        }
        
        public Point bp_Location
        {
            get
            {
                return this.Location;
            }

            set
            {
                this.Location = value;
            }
        }

        public event PaintEventHandler basePlatformPaintEventRaised;
        public event EventHandler basePlatformSizeChangedEventRaised;
        public event PaintEventHandler flpFrameDragDropPaintEventRaised;

        public FlowLayoutPanel GetFlpMain()
        {
            return flp_frameDragDrop;
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void PerformLayoutThis()
        {
            this.PerformLayout();
        }

        private void BasePlatformUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, basePlatformPaintEventRaised, e);
        }

        private void BasePlatformUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, basePlatformSizeChangedEventRaised, e);
        }

        private void flp_frameDragDrop_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpFrameDragDropPaintEventRaised, e);
        }
    }
}
