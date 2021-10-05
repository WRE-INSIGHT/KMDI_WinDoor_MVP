using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_HingePropertyUC : UserControl, IPP_HingePropertyUC
    {
        public PP_HingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPHingeLoadEventRaised;
        public event EventHandler cmbHingeSelectedValueChangedEventRaised;

        private void PP_HingePropertyUC_Load(object sender, EventArgs e)
        {
            num_2dHingeQtyNonMotorized.Maximum = decimal.MaxValue;

            List<HingeOption> Hinge_Option = new List<HingeOption>();
            foreach (HingeOption item in HingeOption.GetAll())
            {
                Hinge_Option.Add(item);
            }
            cmb_Hinge.DataSource = Hinge_Option;

            EventHelpers.RaiseEvent(sender, PPHingeLoadEventRaised, e);
        }

        private void cmb_Hinge_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbHingeSelectedValueChangedEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_Hinge.DataBindings.Add(ModelBinding["Panel_HingeOptions"]);
            num_2dHingeQtyNonMotorized.DataBindings.Add(ModelBinding["Panel_2DHingeQty_nonMotorized"]);
            this.DataBindings.Add(ModelBinding["Panel_HingeOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Panel_HingeOptionsPropertyHeight"]);
        }
    }
}
