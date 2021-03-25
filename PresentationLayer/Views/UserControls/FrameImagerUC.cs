using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class FrameImagerUC : UserControl, IFrameImagerUC
    {
        public FrameImagerUC()
        {
            InitializeComponent();
        }
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

        public event EventHandler frameLoadEventRaised;
        public event PaintEventHandler outerFramePaintEventRaised;
        
        private void FrameImagerUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, frameLoadEventRaised, e);
        }

        private void FrameImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, outerFramePaintEventRaised, e);
        }

        public void AddImagerControl(Control ctrlObj)
        {
            this.Controls.Add(ctrlObj);
        }
        
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_ID"]);
            this.DataBindings.Add(ModelBinding["Frame_Visible"]);
            this.DataBindings.Add(ModelBinding["FrameImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["FrameImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["Frame_Padding"]);
            this.DataBindings.Add(ModelBinding["Frame_Name"]);
        }
    }
}
