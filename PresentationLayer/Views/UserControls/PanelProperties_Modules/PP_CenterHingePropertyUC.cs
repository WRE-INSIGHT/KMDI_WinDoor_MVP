using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_CenterHingePropertyUC : UserControl, IPP_CenterHingePropertyUC
    {
        public PP_CenterHingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler CenterHingePropertyUCLoadEventRaised;
        public event EventHandler CmbCenterHingeSelectedValueChangedEventRaised;


        private void PP_CenterHingePropertyUC_Load(object sender, EventArgs e)
        {
            List<CenterHingeOption> CetnerHingeLst = new List<CenterHingeOption>();
            foreach (CenterHingeOption item in CenterHingeOption.GetAll())
            {
                CetnerHingeLst.Add(item);
            }
            cmb_CenterHinge.DataSource = CetnerHingeLst;
            EventHelpers.RaiseEvent(sender, CenterHingePropertyUCLoadEventRaised, e);
        }

        private void cmb_CenterHinge_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbCenterHingeSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_CenterHinge.DataBindings.Add(ModelBinding["Panel_CenterHingeOptions"]);
            this.DataBindings.Add(ModelBinding["Panel_CenterHingeOptionsVisibility"]);
        }

        private void cmb_CenterHinge_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_CenterHinge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
