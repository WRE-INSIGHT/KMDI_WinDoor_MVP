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
using System.Drawing.Drawing2D;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class MultiPanelTransomUC : UserControl, IMultiPanelTransomUC, IMultiPanelUC
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

        private string _mpanelPlacement;
        public string MPanel_Placement
        {
            get
            {
                return _mpanelPlacement;
            }

            set
            {
                _mpanelPlacement = value;
            }
        }

        private bool _mpanelCmenuDeleteVisibility;
        public bool MPanel_CmenuDeleteVisibility
        {
            get
            {
                return _mpanelCmenuDeleteVisibility;
            }

            set
            {
                _mpanelCmenuDeleteVisibility = value;
            }
        }

        public bool MPanel_DividerEnabledVisibility
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event PaintEventHandler flpMulltiPaintEventRaised;
        public event EventHandler flpMultiMouseEnterEventRaised;
        public event EventHandler flpMultiMouseLeaveEventRaised;
        public event EventHandler divCountClickedEventRaised;
        public event EventHandler deleteClickedEventRaised;
        public event DragEventHandler flpMultiDragDropEventRaised;
        public event EventHandler multiMullionSizeChangedEventRaised;
        public event EventHandler dividerEnabledCheckedChangedEventRaised;
        public event DragEventHandler flpMultiDragOverEventRaised;

        public void InvalidateFlp()
        {
            flp_MultiTransom.Invalidate();
        }

        public void DeletePanel(UserControl obj)
        {
            flp_MultiTransom.Controls.Remove(obj);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanel_Name"]);
            this.DataBindings.Add(ModelBinding["MPanel_Dock"]);
            this.DataBindings.Add(ModelBinding["MPanel_Width"]);
            this.DataBindings.Add(ModelBinding["MPanel_Height"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
            this.DataBindings.Add(ModelBinding["MPanel_Placement"]);
            this.DataBindings.Add(ModelBinding["MPanel_CmenuDeleteVisibility"]);
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
            if (e.Button == MouseButtons.Right && _mpanelCmenuDeleteVisibility == true)
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
            EventHelpers.RaiseDragEvent(sender, flpMultiDragOverEventRaised, e);
        }

        private void flp_MultiTransom_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, flpMultiDragDropEventRaised, e);
        }

        private void MultiPanelTransomUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, multiMullionSizeChangedEventRaised, e);
        }

        private void MultiPanelTransomUC_Paint(object sender, PaintEventArgs e)
        {
            flp_MultiTransom.Invalidate();
        }

        private void dividerEnabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, dividerEnabledCheckedChangedEventRaised, e);
        }

        public ToolStripMenuItem GetDivEnabler()
        {
            return dividerEnabledToolStripMenuItem;
        }

    }
}
