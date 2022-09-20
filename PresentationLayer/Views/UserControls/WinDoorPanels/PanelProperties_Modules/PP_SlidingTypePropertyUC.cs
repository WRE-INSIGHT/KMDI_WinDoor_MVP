using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_SlidingTypePropertyUC : UserControl, IPP_SlidingTypePropertyUC
    {
        public PP_SlidingTypePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler PPSlidingTypePropertyUCLoadEventRaised;
        public event EventHandler cmbSlidingTypeSelectedValueChangedEventRaised;

        private void PP_SlidingTypePropertyUC_Load(object sender, EventArgs e)
        {
            List<SlidingTypes> SlidingType = new List<SlidingTypes>();
            foreach (SlidingTypes item in SlidingTypes.GetAll())
            {
                SlidingType.Add(item);
            }
            cmb_SlidingType.DataSource = SlidingType;

            EventHelpers.RaiseEvent(sender, PPSlidingTypePropertyUCLoadEventRaised, e);
            cmb_SlidingType.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_SlidingType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbSlidingTypeSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            cmb_SlidingType.DataBindings.Add(ModelBinding["Panel_SlidingTypes"]);
            this.DataBindings.Add(ModelBinding["Panel_SlidingTypeVisibility"]);
        }

    }
}
