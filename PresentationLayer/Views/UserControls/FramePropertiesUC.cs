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
        public FramePropertiesUC()
        {
            InitializeComponent();
        }

        //public int fHeight
        //{
        //    get
        //    {
        //        return (int)num_fHeight.Value;
        //    }

        //    set
        //    {
        //        num_fHeight.Value = value;
        //    }
        //}

        //public string Frame_Name
        //{
        //    set
        //    {
        //        lbl_frameName.Text = value;
        //    }
        //}

        //public FrameModel.Frame_Padding Frame_Type
        //{
        //    set
        //    {
        //        if (value == FrameModel.Frame_Padding.Window)
        //        {
        //            rdBtn_Window.Checked = true;
        //        }
        //        else if (value == FrameModel.Frame_Padding.Door)
        //        {
        //            rdBtn_Door.Checked = true;
        //        }
        //        else if (value == FrameModel.Frame_Padding.Concrete)
        //        {
        //            rdBtn_Concrete.Checked = true;
        //        }
        //    }
        //}

        //public int fWidth
        //{
        //    get
        //    {
        //        return (int)num_fWidth.Value;
        //    }

        //    set
        //    {
        //        num_fWidth.Value = value;
        //    }
        //}

        //public int ThisHeight
        //{
        //    set
        //    {
        //        this.Height = value;
        //    }
        //}

        //public bool ThisVisibility
        //{
        //    get
        //    {
        //        return this.Visible;
        //    }

        //    set
        //    {
        //        this.Visible = value;
        //    }
        //}

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
