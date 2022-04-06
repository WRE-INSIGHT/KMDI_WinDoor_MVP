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

namespace PresentationLayer.Views.UserControls
{
    public partial class ConcreteUC : UserControl, IConcreteUC
    {
        public ConcreteUC()
        {
            InitializeComponent();
        }

        public int Concrete_ID { get; set; }

        public event EventHandler ConcreteUCLoadEventRaised;
        public event EventHandler ConcreteUCMouseEnterEventRaised;
        public event EventHandler ConcreteUCMouseLeaveEventRaised;
        public event EventHandler deleteToolStripMenuItemClickEventRaised;
        public event PaintEventHandler ConcreteUCPaintEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Concrete_ID"]);
            this.DataBindings.Add(ModelBinding["Concrete_WidthToBind"]);
            this.DataBindings.Add(ModelBinding["Concrete_HeightToBind"]);
            this.DataBindings.Add(ModelBinding["Concrete_Name"]);
        }

        private void ConcreteUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, ConcreteUCPaintEventRaised, e);
        }

        private void ConcreteUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_concrete.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void ConcreteUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ConcreteUCLoadEventRaised, e);
        }

        private void ConcreteUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ConcreteUCMouseEnterEventRaised, e);
        }

        private void ConcreteUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ConcreteUCMouseLeaveEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripMenuItemClickEventRaised, e);
        }
    }
}
