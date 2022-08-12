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
        
        public event MouseEventHandler mullionUCMouseDownEventRaised;
        public event MouseEventHandler mullionUCMouseMoveEventRaised;
        public event MouseEventHandler mullionUCMouseUpEventRaised;
        public event MouseEventHandler mullionUCMouseDoubleClickedEventRaised;
        public event PaintEventHandler mullionUCPaintEventRaised;
        //public event EventHandler deleteToolStripMenuItemClickedEventRaised;
        public event EventHandler mullionUCMouseEnterEventRaised;
        public event EventHandler mullionUCMouseLeaveEventRaised;
        public event EventHandler mullionUCSizeChangedEventRaised;
        public event KeyEventHandler mullionUCKeyDownEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            this.DataBindings.Add(ModelBinding["Div_Name"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
            this.DataBindings.Add(ModelBinding["Div_WidthToBind"]);
            this.DataBindings.Add(ModelBinding["Div_HeightToBind"]);
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EventHelpers.RaiseEvent(sender, deleteToolStripMenuItemClickedEventRaised, e);
        }

        private void MullionUC_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    cmenu_mullion.Show(new Point(MousePosition.X, MousePosition.Y));
            //}
            Console.WriteLine(this.Width);
            Console.WriteLine(this.Location);
            Console.WriteLine(this.Parent.Name);
        }

        private void MullionUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, mullionUCMouseEnterEventRaised, e);
        }

        private void MullionUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, mullionUCMouseLeaveEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void MullionUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, mullionUCSizeChangedEventRaised, e);
        }

        private void MullionUC_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(this, mullionUCKeyDownEventRaised, e);
        }

        private void MullionUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void MullionUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, mullionUCMouseDoubleClickedEventRaised, e);
        }

        public void FocusOnThis()
        {
            this.Focus();
        }
    }
}
