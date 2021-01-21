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
            //for mullion transparency
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
        }

        private int _divID;
        public int Div_ID
        {
            get
            {
                return _divID;
            }
            set
            {
                _divID = value;
            }
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

        public Point Mullion_Location
        {
            get
            {
                return this.Location;
            }
        }
        
        public event MouseEventHandler mullionUCMouseDownEventRaised;
        public event MouseEventHandler mullionUCMouseMoveEventRaised;
        public event MouseEventHandler mullionUCMouseUpEventRaised;
        public event PaintEventHandler mullionUCPaintEventRaised;
        public event EventHandler deleteToolStripMenuItemClickedEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
            this.DataBindings.Add(ModelBinding["Div_Width"]);
            this.DataBindings.Add(ModelBinding["Div_Height"]);
        }

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

        private void MullionUC_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.X == 0)
            {
                this.Margin = new Padding(10, 0, 0, 0);
            }
            else
            {
                this.Margin = new Padding(0, 0, 0, 0);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripMenuItemClickedEventRaised, e);
        }

        private void MullionUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_mullion.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }
    }
}
