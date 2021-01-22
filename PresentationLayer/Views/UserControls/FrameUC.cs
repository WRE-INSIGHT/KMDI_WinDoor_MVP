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
            }
        }

        public Padding thisPadding
        {
            get
            {
                return this.Padding;
            }

            set
            {
                this.Padding = value;
                this.Invalidate();
            }
        }

        public FrameUC()
        {
            InitializeComponent();
        }

        public event EventHandler frameLoadEventRaised;
        public event PaintEventHandler outerFramePaintEventRaised;
        public event MouseEventHandler frameMouseClickEventRaised;
        public event EventHandler deleteCmenuEventRaised;
        public event EventHandler frameMouseEnterEventRaised;
        public event EventHandler frameMouseLeaveEventRaised;
        public event DragEventHandler frameDragDropEventRaised;

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

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Frame_ID"]);
            this.DataBindings.Add(binding["Frame_Visible"]);
            this.DataBindings.Add(binding["Frame_Width"]);
            this.DataBindings.Add(binding["Frame_Height"]);
            this.DataBindings.Add(binding["Frame_Padding"]);
            this.DataBindings.Add(binding["Frame_Name"]);
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

        private void FrameUC_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(this, frameDragDropEventRaised, e);
        }

        private void FrameUC_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void FrameUC_ControlAdded(object sender, ControlEventArgs e)
        {
            this.Invalidate();
        }

        private void FrameUC_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.Invalidate();
        }

        public void DeleteControl(UserControl control)
        {
            this.Controls.Remove(control);
        }

        public void PerformLayoutThis()
        {
            this.PerformLayout();
        }
    }
}
