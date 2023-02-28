using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_TrackProfilePropertyUC : UserControl, IFP_TrackProfilePropertyUC
    {
        public FP_TrackProfilePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler TrackProfilePropertyUCLoadEventRaised;
        public event EventHandler TrackProfileSelectedValueChangedEventRaised;


        private void FP_TrackProfilePropertyUC_Load(object sender, EventArgs e)
        {
            List<TrackProfile_ArticleNo> TrackProfile = new List<TrackProfile_ArticleNo>();
            foreach (TrackProfile_ArticleNo item in TrackProfile_ArticleNo.GetAll())
            {
                TrackProfile.Add(item);
            }
            cmb_TrackProfile.DataSource = TrackProfile;

            EventHelpers.RaiseEvent(sender, TrackProfilePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_TrackProfileArtNoVisibility"]);
            cmb_TrackProfile.DataBindings.Add(ModelBinding["Frame_TrackProfileArtNo"]);
        }

        private void cmb_TrackProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TrackProfileSelectedValueChangedEventRaised, e);
        }
    }
}
