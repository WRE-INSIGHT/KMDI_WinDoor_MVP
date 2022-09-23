using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_DHandlePropertyUC : UserControl, IPP_DHandlePropertyUC
    {
        public PP_DHandlePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler PPDHandlePropertyUCLoadEventRaised;
        public event EventHandler cmb_DArtNoSelectedValueChangedEventRaised;

        private void PP_DHandlePropertyUC_Load(object sender, EventArgs e)
        {
            List<D_HandleArtNo> DHandle = new List<D_HandleArtNo>();
            foreach (D_HandleArtNo item in D_HandleArtNo.GetAll())
            {
                if (item.DisplayName.Contains("out"))
                {
                    DHandle.Add(item);
                }
            }
            cmb_DArtNo.DataSource = DHandle;

            EventHelpers.RaiseEvent(sender, PPDHandlePropertyUCLoadEventRaised, e);
        }

        private void cmb_DArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmb_DArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_DHandleOptionVisibilty"]);
            cmb_DArtNo.DataBindings.Add(ModelBinding["Panel_DHandleOutsideArtNo"]);
        }
    }
}
