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
        }

        public int bp_Width
        {
            get
            {
                return this.Width;
            }
        }

        public bool thisVisibility
        {
            get
            {
                return this.Visible;
            }
        }

        public Color bp_bgColor
        {
            get
            {
                return this.BackColor;
            }

            set
            {
                this.BackColor = value;
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
            flp_frameDragDrop.Invalidate();
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

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["WD_width_4basePlatform"]);
            this.DataBindings.Add(binding["WD_height_4basePlatform"]);
            this.DataBindings.Add(binding["WD_visibility"]);
        }

        public void ClearBinding(Control ctrl)
        {
            ctrl.DataBindings.Clear();
        }

        public void RemoveBindingThis()
        {
            this.DataBindings.Clear();
        }

        private void BasePlatformUC_Load(object sender, EventArgs e)
        {

        }
    }
}
