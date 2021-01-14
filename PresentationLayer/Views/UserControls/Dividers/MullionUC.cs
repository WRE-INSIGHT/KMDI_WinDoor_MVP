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

namespace PresentationLayer.Views.UserControls.Dividers
{
    public partial class MullionUC : UserControl, IMullionUC
    {
        public MullionUC()
        {
            InitializeComponent();
        }

        public int Mullion_Left
        {
            get
            {
                return this.Left;
            }

            set
            {
                this.Left = value;
            }
        }

        public event MouseEventHandler mullionUCMouseDownEventRaised;
        public event MouseEventHandler mullionUCMouseMoveEventRaised;
        public event MouseEventHandler mullionUCMouseUpEventRaised;
        public event PaintEventHandler mullionUCPaintEventRaised;

        private void MullionUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, mullionUCMouseDownEventRaised, e);
        }

        private void MullionUC_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, mullionUCMouseMoveEventRaised, e);
        }

        private void MullionUC_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, mullionUCMouseUpEventRaised, e);
        }

        private void MullionUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, mullionUCPaintEventRaised, e);
        }
    }
}
