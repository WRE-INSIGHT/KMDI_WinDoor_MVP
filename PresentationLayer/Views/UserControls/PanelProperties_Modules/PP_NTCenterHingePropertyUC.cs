using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_NTCenterHingePropertyUC : UserControl, IPP_NTCenterHingePropertyUC
    {
        public PP_NTCenterHingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler CmbNTCenterHingeSelectedValueChangedEventRaised;
        public event EventHandler NTCenterHingePropertyUCLoadEventRaised;

        private void cmb_NTCenterHinge_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbNTCenterHingeSelectedValueChangedEventRaised, e);
        }

        private void PP_NTCenterHingePropertyUC_Load(object sender, EventArgs e)
        {
            List<NTCenterHinge_ArticleNo> NTCenterHingeArticleNo = new List<NTCenterHinge_ArticleNo>();
            foreach (NTCenterHinge_ArticleNo item in NTCenterHinge_ArticleNo.GetAll())
            {
                NTCenterHingeArticleNo.Add(item);
            }
            cmb_NTCenterHinge.DataSource = NTCenterHingeArticleNo;
            EventHelpers.RaiseEvent(sender, NTCenterHingePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_NTCenterHingeVisibility"]);
            cmb_NTCenterHinge.DataBindings.Add(ModelBinding["Panel_NTCenterHingeArticleNo"]);
        }
    }
}
