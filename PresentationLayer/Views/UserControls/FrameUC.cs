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

        public Bitmap GetImageThis()
        {
            Bitmap bgThis = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bgThis, new Rectangle(10, 10, this.Width - 20, this.Height - 20));

            Bitmap cropped = new Bitmap(280, 280);

            //Load image from file
            using (Bitmap image = new Bitmap(bgThis))
            {
                // Create a Graphics object to do the drawing, *with the new bitmap as the target*
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    // Draw the desired area of the original into the graphics object
                    g.DrawImage(image, new Rectangle(0, 0, this.Width - 20, this.Height - 20), 
                                       new Rectangle(10, 10, this.Width - 20, this.Height - 20), GraphicsUnit.Pixel);
                    // Save the result
                    //cropped.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\2.png");
                }
            }
            return cropped;
        }
    }
}
