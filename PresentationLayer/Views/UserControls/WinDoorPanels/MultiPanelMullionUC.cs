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
using System.Drawing.Drawing2D;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class MultiPanelMullionUC : UserControl, IMultiPanelMullionUC, IMultiPanelUC
    {
        public MultiPanelMullionUC()
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
       

        public event PaintEventHandler flpMulltiPaintEventRaised;
        public event EventHandler flpMultiMouseEnterEventRaised;
        public event EventHandler flpMultiMouseLeaveEventRaised;
        public event EventHandler divCountClickedEventRaised;
        public event EventHandler deleteClickedEventRaised;
        public event DragEventHandler flpMultiDragDropEventRaised;
        public event EventHandler multiMullionSizeChangedEventRaised;
        public event EventHandler dividerEnabledCheckedChangedEventRaised;
        public event DragEventHandler flpMultiDragOverEventRaised;

        private void flp_Multi_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
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

        private void flp_MultiMullion_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseEnterEventRaised, e);
        }

        private void flp_MultiMullion_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseLeaveEventRaised, e);
        }

        public void InvalidateFlp()
        {
            flp_MultiMullion.Invalidate();
        }

        private void flp_MultiMullion_MouseDown(object sender, MouseEventArgs e)
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

        private void flp_MultiMullion_DragOver(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, flpMultiDragOverEventRaised, e);
        }

        private void flp_MultiMullion_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, flpMultiDragDropEventRaised, e);
        }

        public void DeletePanel(UserControl panel)
        {
            flp_MultiMullion.Controls.Remove(panel);
        }

        private void MultiPanelMullionUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, multiMullionSizeChangedEventRaised, e);
        }

        private void MultiPanelMullionUC_Paint(object sender, PaintEventArgs e)
        {
            flp_MultiMullion.Invalidate();
        }

        private void dividerEnabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, dividerEnabledCheckedChangedEventRaised, e);
        }

        public ToolStripMenuItem GetDivEnabler()
        {
            return dividerEnabledToolStripMenuItem;
        }
        private void flp_MultiMullion_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Height " + this.Height);
            Console.WriteLine("Width " + this.Width);
        }
    }
}