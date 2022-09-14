using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_RotoswingForSlidingPropertyUC : UserControl, IPP_RotoswingForSlidingPropertyUC
    {
        public PP_RotoswingForSlidingPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPRotoswingForSlidingPropertyUCLoadEventRaised;
        public event EventHandler cmbRotoswingForSlidingNoSelectedValueChangedEventRaised;


        private void PP_RotoswingForSlidingPropertyUC_Load(object sender, EventArgs e)
        {
            List<Rotoswing_Sliding_HandleArtNo> rotoswingForSlidingHandle = new List<Rotoswing_Sliding_HandleArtNo>();
            foreach (Rotoswing_Sliding_HandleArtNo item in Rotoswing_Sliding_HandleArtNo.GetAll())
            {
                rotoswingForSlidingHandle.Add(item);
            }
            cmb_RotoswingForSlidingNo.DataSource = rotoswingForSlidingHandle;

            EventHelpers.RaiseEvent(sender, PPRotoswingForSlidingPropertyUCLoadEventRaised, e);
        }

        private void cmb_RotoswingForSlidingNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRotoswingForSlidingNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_RotoswingForSlidingHandleOptionVisibilty"]);
            cmb_RotoswingForSlidingNo.DataBindings.Add(ModelBinding["Panel_RotoswingForSlidingHandleArtNo"]);
        }
    }
}
