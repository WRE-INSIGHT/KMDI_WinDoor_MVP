using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_DummyDHandlePropertyUC : UserControl, IPP_DummyDHandlePropertyUC
    {
        public PP_DummyDHandlePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPDummyDHandlePropertyUCLoadEventRaised;
        public event EventHandler cmbDummyDArtNoSelectedValueChangedEventRaised;

        private void cmb_DummyDArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbDummyDArtNoSelectedValueChangedEventRaised, e);
        }

        private void PP_DummyDHandlePropertyUC_Load(object sender, EventArgs e)
        {
            List<DummyD_HandleArtNo> DummyDHandle = new List<DummyD_HandleArtNo>();
            foreach (DummyD_HandleArtNo item in DummyD_HandleArtNo.GetAll())
            {
                if (item.DisplayName.Contains("out"))
                {
                    DummyDHandle.Add(item);
                }
            }
            cmb_DummyDArtNo.DataSource = DummyDHandle;

            EventHelpers.RaiseEvent(sender, PPDummyDHandlePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_DummyDHandleOptionVisibilty"]);
            cmb_DummyDArtNo.DataBindings.Add(ModelBinding["Panel_DummyDHandleOutsideArtNo"]);
        }
        private void cmb_DummyDArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_DummyDArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
