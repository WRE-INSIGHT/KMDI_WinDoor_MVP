using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_BottomFramePropertyUC : UserControl, IFP_BottomFramePropertyUC
    {
        public FP_BottomFramePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler bottomFramePropertyLoadEventRaised;
        public event EventHandler cmbbotFrameProfileSelectedValueChangedRaised;

        private void FP_BottomFramePropertyUC_Load(object sender, EventArgs e)
        {
            List<BottomFrameTypes> fbotArtNo = new List<BottomFrameTypes>();
            foreach (BottomFrameTypes item in BottomFrameTypes.GetAll())
            {
                fbotArtNo.Add(item);
            }
            cmb_botFrameProfile.DataSource = fbotArtNo;

            EventHelpers.RaiseEvent(this, bottomFramePropertyLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_botFrameProfile.DataBindings.Add(ModelBinding["Frame_BotFrameArtNo"]);
            this.DataBindings.Add(ModelBinding["Frame_BotFrameEnable"]);
            this.DataBindings.Add(ModelBinding["Frame_BotFrameVisible"]);
        }

        private void cmb_botFrameProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbotFrameProfileSelectedValueChangedRaised, e);
        }
    }
}
