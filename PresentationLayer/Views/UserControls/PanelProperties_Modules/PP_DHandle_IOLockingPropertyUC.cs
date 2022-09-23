using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_DHandle_IOLockingPropertyUC : UserControl, IPP_DHandle_IOLockingPropertyUC
    {
        public PP_DHandle_IOLockingPropertyUC()
        {
            InitializeComponent();
        }


        public event EventHandler PPDHandleIOLockingPropertyUCLoadEventRaised;
        public event EventHandler cmbD_IOLockingArtNoSelectedValueChangedEventRaised;

        private void cmb_D_IOLockingArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbD_IOLockingArtNoSelectedValueChangedEventRaised, e);
        }

        private void PP_DHandle_IOLockingPropertyUC_Load(object sender, EventArgs e)
        {
            List<D_Handle_IO_LockingArtNo> DHandleIOLocing = new List<D_Handle_IO_LockingArtNo>();
            foreach (D_Handle_IO_LockingArtNo item in D_Handle_IO_LockingArtNo.GetAll())
            {
                if (item.DisplayName.Contains("out"))
                {
                    DHandleIOLocing.Add(item);
                }
            }
            cmb_D_IOLockingArtNo.DataSource = DHandleIOLocing;

            EventHelpers.RaiseEvent(sender, PPDHandleIOLockingPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_DHandleIOLockingOptionVisibilty"]);
            cmb_D_IOLockingArtNo.DataBindings.Add(ModelBinding["Panel_DHandleIOLockingOutsideArtNo"]);
        }
    }
}
