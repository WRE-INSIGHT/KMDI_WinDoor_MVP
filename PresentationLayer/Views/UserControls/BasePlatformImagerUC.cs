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
    public partial class BasePlatformImagerUC : UserControl, IBasePlatformImagerUC
    {
        public BasePlatformImagerUC()
        {
            InitializeComponent();
        }

        public event EventHandler basePlatformSizeChangedEventRaised;
        public event EventHandler BasePlatformImagerUCLoadEventRaised;
        public event PaintEventHandler basePlatformPaintEventRaised;
        public event PaintEventHandler flpFrameDragDropPaintEventRaised;

        public void ClearBinding(Control _basePlatfomrUC)
        {
            _basePlatfomrUC.DataBindings.Clear();
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["WD_width_4basePlatform_forImageRenderer"]);
            this.DataBindings.Add(ModelBinding["WD_height_4basePlatform_forImageRenderer"]);
            this.DataBindings.Add(ModelBinding["WD_visibility"]);
        }

        private void BasePlatformImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, basePlatformPaintEventRaised, e);
        }

        private void flp_frameDragDrop_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpFrameDragDropPaintEventRaised, e);
        }

        private void BasePlatformImagerUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, basePlatformSizeChangedEventRaised, e);
        }

        public FlowLayoutPanel GetFlpMain()
        {
            return flp_frameDragDrop;
        }

        public void BringToFront_baseImager()
        {
            this.BringToFront();
        }

        public void SendToBack_baseImager()
        {
            this.SendToBack();
        }

        private void BasePlatformImagerUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BasePlatformImagerUCLoadEventRaised, e);
        }
    }
}
