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
using ModelLayer.Model.Quotation.Frame;

namespace PresentationLayer.Views.UserControls
{
    public partial class FramePropertiesUC : UserControl, IFramePropertiesUC
    {
        private int frameID;
        public int FrameID
        {
            get
            {
                return frameID;
            }

            set
            {
                frameID = value;
            }
        }

        public FramePropertiesUC()
        {
            InitializeComponent();
        }
        
        public event EventHandler FramePropertiesLoadEventRaised;
        public event EventHandler NumFHeightValueChangedEventRaised;
        public event EventHandler NumFWidthValueChangedEventRaised;
        public event EventHandler RdBtnCheckedChangedEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void FramePropertiesUC_Load(object sender, EventArgs e)
        {
            num_fWidth.Maximum = int.MaxValue;
            num_fHeight.Maximum = int.MaxValue;
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, FramePropertiesLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> frameModelBinding)
        {
            this.DataBindings.Add(frameModelBinding["Frame_ID"]);
            lbl_frameName.DataBindings.Add(frameModelBinding["Frame_Name"]);
            this.DataBindings.Add(frameModelBinding["Frame_Visible"]);
            num_fWidth.DataBindings.Add(frameModelBinding["Frame_Width"]);
            num_fHeight.DataBindings.Add(frameModelBinding["Frame_Height"]);
            rdBtn_Window.DataBindings.Add(frameModelBinding["Frame_Type_Window"]);
            rdBtn_Door.DataBindings.Add(frameModelBinding["Frame_Type_Door"]);
            rdBtn_Concrete.DataBindings.Add(frameModelBinding["Frame_Type_Concrete"]);
        }

        private void num_fWidth_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NumFWidthValueChangedEventRaised, e);
        }

        private void num_fHeight_ValueChanged_1(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NumFHeightValueChangedEventRaised, e);
        }

        private void rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, RdBtnCheckedChangedEventRaised, e);
        }
    }
}
