using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class FrameUC : UserControl, IFrameUC
    {
        public bool thisVisible
        {
            get
            {
                return this.Visible;
            }
        }

        private int _frameID;
        public int frameID
        {
            get
            {
                return _frameID;
            }

            set
            {
                _frameID = value;
                this.Tag = value;
                pnl_inner.Tag = value;
            }
        }

        public FrameUC()
        {
            InitializeComponent();
        }

        public event EventHandler frameLoadEventRaised;
        public event PaintEventHandler innerFramePaintEventRaised;
        public event PaintEventHandler outerFramePaintEventRaised;
        public event MouseEventHandler frameMouseClickEventRaised;
        public event EventHandler deleteCmenuEventRaised;
        public event EventHandler frameMouseEnterEventRaised;
        public event EventHandler frameMouseLeaveEventRaised;
        public event EventHandler panelInnerMouseEnterEventRaised;
        public event EventHandler panelInnerMouseLeaveEventRaised;
        public event DragEventHandler panelInnerDragDropEventRaised;

        private void FrameUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, outerFramePaintEventRaised, e);
        }

        private void FrameUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, frameLoadEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void pnl_inner_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, innerFramePaintEventRaised, e);
        }

        private void frame_MouseClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, frameMouseClickEventRaised, e);
        }

        public ContextMenuStrip GetFrameCmenu()
        {
            return cmenu_frame;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteCmenuEventRaised, e);
        }

        private void FrameUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, frameMouseEnterEventRaised, e);
        }

        private void FrameUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, frameMouseLeaveEventRaised, e);
        }

        private void pnl_inner_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, panelInnerMouseEnterEventRaised, e);
        }

        private void pnl_inner_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, panelInnerMouseLeaveEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Frame_ID"]);
            this.DataBindings.Add(binding["Frame_Visible"]);
            this.DataBindings.Add(binding["Frame_Width"]);
            this.DataBindings.Add(binding["Frame_Height"]);
            this.DataBindings.Add(binding["Frame_Padding"]);
        }

        public void InvalidatePanelInner()
        {
            pnl_inner.Invalidate();
        }

        public void InvalidateThisParent()
        {
            this.Parent.Invalidate();
        }

        public void InvalidateThisParentsParent()
        {
            this.Parent.Parent.Invalidate();
        }

        private void pnl_inner_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, panelInnerDragDropEventRaised, e);
        }

        public Panel GetInnerPanel()
        {
            return pnl_inner;
        }
    }
}
