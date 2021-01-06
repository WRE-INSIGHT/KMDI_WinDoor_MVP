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
            //throw new NotImplementedException();
        }

        private void BasePlatformImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, basePlatformPaintEventRaised, e);
        }

        private void flp_frameDragDrop_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpFrameDragDropPaintEventRaised, e);
        }
    }
}
