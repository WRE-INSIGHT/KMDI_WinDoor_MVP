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
using System.IO;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class MultiPanelTransomUC : UserControl, IMultiPanelTransomUC
    {
        public MultiPanelTransomUC()
        {
            InitializeComponent();
        }

        private int _mpanelID;
        public int MPanel_ID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }
        public event PaintEventHandler flpMulltiPaintEventRaised;
        public event EventHandler flpMultiMouseEnterEventRaised;
        public event EventHandler flpMultiMouseLeaveEventRaised;
        public event EventHandler divCountClickedEventRaised;
        public event EventHandler deleteClickedEventRaised;
        public event DragEventHandler flpMultiDragDropEventRaised;

        public void InvalidateFlp()
        {
            flp_MultiTransom.Invalidate();
        }

        public void DeletePanel(UserControl panel)
        {
            flp_MultiTransom.Controls.Remove(panel);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanel_Dock"]);
            this.DataBindings.Add(ModelBinding["MPanel_Width"]);
            this.DataBindings.Add(ModelBinding["MPanel_Height"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
        }

        private void flp_MultiTransom_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
        }

        private void flp_MultiTransom_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseEnterEventRaised, e);
        }

        private void flp_MultiTransom_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseLeaveEventRaised, e);
        }

        private void flp_MultiTransom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_mulltiP.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void divCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, divCountClickedEventRaised, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteClickedEventRaised, e);
        }

        private void flp_MultiTransom_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flp_MultiTransom_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, flpMultiDragDropEventRaised, e);
        }
    }
}
