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
using ModelLayer;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

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

        private Frame_Padding _frameType;
        public Frame_Padding Frame_Type
        {
            get
            {
                return _frameType;
            }
            set
            {
                _frameType = value;
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
        public event EventHandler cmbFrameProfileSelectedValueChangedEventRaised;
        public event EventHandler cmbFrameReinfSelectedValueChangedEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void FramePropertiesUC_Load(object sender, EventArgs e)
        {
            num_fWidth.Maximum = int.MaxValue;
            num_fHeight.Maximum = int.MaxValue;
            this.Dock = DockStyle.Top;

            List<FrameProfile_ArticleNo> fArtNo = new List<FrameProfile_ArticleNo>();

            foreach (FrameProfile_ArticleNo item in FrameProfile_ArticleNo.GetAll())
            {
                fArtNo.Add(item);
            }
            cmb_FrameProfile.DataSource = fArtNo;

            List<FrameReinf_ArticleNo> fReinf = new List<FrameReinf_ArticleNo>();
            foreach (FrameReinf_ArticleNo item in FrameReinf_ArticleNo.GetAll())
            {
                fReinf.Add(item);
            }
            cmb_FrameReinf.DataSource = fReinf;

            EventHelpers.RaiseEvent(this, FramePropertiesLoadEventRaised, e);
         }
        public void ThisBinding(Dictionary<string, Binding> frameModelBinding)
        {
            this.DataBindings.Add(frameModelBinding["Frame_ID"]);
            this.DataBindings.Add(frameModelBinding["FrameProp_Height"]);
            lbl_frameName.DataBindings.Add(frameModelBinding["Frame_Name"]);
            this.DataBindings.Add(frameModelBinding["Frame_Visible"]);
            this.DataBindings.Add(frameModelBinding["Frame_Type"]);
            num_fWidth.DataBindings.Add(frameModelBinding["Frame_Width"]);
            num_fHeight.DataBindings.Add(frameModelBinding["Frame_Height"]);
            rdBtn_Window.DataBindings.Add(frameModelBinding["Frame_Type_Window"]);
            rdBtn_Door.DataBindings.Add(frameModelBinding["Frame_Type_Door"]);
            cmb_FrameProfile.DataBindings.Add(frameModelBinding["Frame_ArtNo"]);
            cmb_FrameReinf.DataBindings.Add(frameModelBinding["Frame_ReinfArtNo"]);
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
        public void SetFrameTypeRadioBtnEnabled(bool frameTypeEnabled)
        {
            rdBtn_Window.Enabled = frameTypeEnabled;
            rdBtn_Door.Enabled = frameTypeEnabled;
        }
        private void cmb_FrameProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbFrameProfileSelectedValueChangedEventRaised, e);
        }
        private void cmb_FrameReinf_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbFrameReinfSelectedValueChangedEventRaised, e);
        }
        public Panel GetFramePropertiesPNL()
        {
            return pnl_frameProperties;
        }
        public Panel GetBodyPropertiesPNL()
        {
            return pnl_Body;
        }
        public void AddHT_PanelBody(int addht)
        {
            pnl_Body.Height += addht;
        }

        public UserControl GetThis()
        {
            return this;
        }

        public void BringToFrontFrame()
        {
            this.BringToFront();
        }
        private void cmb_FrameProfile_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_FrameProfile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmb_FrameReinf_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_FrameReinf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_fWidth_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void num_fHeight_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}