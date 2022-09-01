using System;
using System.Collections.Generic;
using System.Drawing;
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

        private bool _frameCmenuDeleteVisibility;
        public bool Frame_CmenuDeleteVisibility
        {
            get
            {
                return _frameCmenuDeleteVisibility;
            }

            set
            {
                _frameCmenuDeleteVisibility = value;
            }
        }

        //public Padding thisPadding
        //{
        //    get
        //    {
        //        return this.Padding;
        //    }

        //    set
        //    {
        //        this.Padding = value;
        //        this.Invalidate();
        //    }
        //}

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
        public event ControlEventHandler frameControlAddedEventRaised;
        public event ControlEventHandler frameControlRemovedEventRaised;

        private void FrameUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, outerFramePaintEventRaised, e);
        }

        private void FrameUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, frameLoadEventRaised, e);
        }

        private void frame_MouseClick(object sender, MouseEventArgs e)
        {
            if (_frameCmenuDeleteVisibility == true)
            {
                EventHelpers.RaiseMouseEvent(sender, frameMouseClickEventRaised, e);
            }
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
            this.DataBindings.Add(binding["Frame_CmenuDeleteVisibility"]);
        }

        private void FrameUC_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(this, frameDragDropEventRaised, e);
        }

        private void FrameUC_DragOver(object sender, DragEventArgs e)
        {
            if (this.Controls.Count == 0)
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (this.Controls.Count > 0)
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FrameUC_ControlAdded(object sender, ControlEventArgs e)
        {
            EventHelpers.RaiseControlEvent(sender, frameControlAddedEventRaised, e);
            this.Invalidate();
        }

        private void FrameUC_ControlRemoved(object sender, ControlEventArgs e)
        {
            EventHelpers.RaiseControlEvent(sender, frameControlRemovedEventRaised, e);
            this.Invalidate();
        }

        public void DeleteControl(UserControl control)
        {
            this.Controls.Remove(control);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void InvalidateThisParent()
        {
            this.Parent.Invalidate();
        }

        public void InvalidateThisParentsParent()
        {
            this.Parent.Parent.Invalidate();
        }

        public void PerformLayoutThis()
        {
            this.PerformLayout();
        }

        public void InvalidateThisControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Invalidate();
            }
        }

        private void FrameUC_PaddingChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FrameUC_SizeChanged(object sender, EventArgs e)
        {
            InvalidateThis();
        }

        public UserControl GetThis()
        {
            return this;
        }

      
    }
}
