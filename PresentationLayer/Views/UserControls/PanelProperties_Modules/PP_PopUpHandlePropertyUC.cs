using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_PopUpHandlePropertyUC : UserControl, IPP_PopUpHandlePropertyUC
    {
        public PP_PopUpHandlePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPPopUpHandlePropertyUCLoadEventRaiased;
        public event EventHandler cmbPopUpArtNoSelectedValueChangedEventRaiased;


        private void PP_PopUpHandlePropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PPPopUpHandlePropertyUCLoadEventRaiased, e);
        }

        private void cmb_PopUpArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbPopUpArtNoSelectedValueChangedEventRaiased, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_PopUpHandleOptionVisibilty"]);
            cmb_PopUpArtNo.DataBindings.Add(ModelBinding["Panel_PopUpHandleArtNo"]);
        }
    }
}
