using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_CenterProfilePropertyUC : UserControl, IPP_CenterProfilePropertyUC
    {
        public PP_CenterProfilePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler CenterProfilePropertyUCLoadEventRaised;
        public event EventHandler CenterProfileArtNoSelectedValueChangedEventRaised;

        private void PP_CenterProfilePropertyUC_Load(object sender, EventArgs e)
        {
            List<CenterProfile_ArticleNo> CenterProfile = new List<CenterProfile_ArticleNo>();
            foreach (CenterProfile_ArticleNo item in CenterProfile_ArticleNo.GetAll())
            {
                CenterProfile.Add(item);
            }
            cmb_CenterProfileArtNo.DataSource = CenterProfile;

            EventHelpers.RaiseEvent(sender, CenterProfilePropertyUCLoadEventRaised, e);
        }

        private void cmb_CenterProfileArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CenterProfileArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_CenterProfileVisibility"]);
            cmb_CenterProfileArtNo.DataBindings.Add(ModelBinding["Panel_CenterProfileArtNo"]);
        }
        private void cmb_CenterProfileArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_CenterProfileArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}