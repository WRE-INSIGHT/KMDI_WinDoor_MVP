using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_TrackRailPropertyUC : UserControl, IPP_TrackRailPropertyUC
    {
        public PP_TrackRailPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler PPTrackRailPropertyUCLoadEventRaised;
        public event EventHandler cmbTrackRailArtNoSelectedValueChangedEventRaised;
        private void PP_TrackRailPropertyUC_Load(object sender, EventArgs e)
        {
            List<TrackRail_ArticleNo> track = new List<TrackRail_ArticleNo>();
            foreach (TrackRail_ArticleNo item in TrackRail_ArticleNo.GetAll())
            {
                track.Add(item);
            }

            EventHelpers.RaiseEvent(sender, PPTrackRailPropertyUCLoadEventRaised, e);
        }

        private void cmb_TrackRailArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbTrackRailArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_TrackRailArtNoVisibility"]);
            cmb_TrackRailArtNo.DataBindings.Add(ModelBinding["Panel_TrackRailArtNo"]);
        }
    }
}
