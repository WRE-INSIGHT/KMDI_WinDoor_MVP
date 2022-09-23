using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_FrameConnectionTypePropertyUC : UserControl, IFP_FrameConnectionTypePropertyUC
    {
        public FP_FrameConnectionTypePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler FrameConnectionTypePropertyUCLoadEventRaised;
        public event EventHandler cmbConnectionTypeSelectedValueChangedEventRaised;

        private void FP_FrameConnectionTypePropertyUC_Load(object sender, EventArgs e)
        {
            List<FrameConnectionType> connector = new List<FrameConnectionType>();
            foreach (FrameConnectionType item in FrameConnectionType.GetAll())
            {
                connector.Add(item);
            }
            cmb_ConnectionType.DataSource = connector;

            EventHelpers.RaiseEvent(sender, FrameConnectionTypePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_ConnectionType.DataBindings.Add(ModelBinding["Frame_ConnectionType"]);
            this.DataBindings.Add(ModelBinding["Frame_ConnectionTypeVisibility"]);
        }

        private void cmb_ConnectionType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbConnectionTypeSelectedValueChangedEventRaised, e);
        }
    }
}
