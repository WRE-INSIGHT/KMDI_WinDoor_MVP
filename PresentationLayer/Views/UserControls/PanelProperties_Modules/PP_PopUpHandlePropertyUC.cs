﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

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
            List<PopUp_HandleArtNo> popUpHandle = new List<PopUp_HandleArtNo>();
            foreach (PopUp_HandleArtNo item in PopUp_HandleArtNo.GetAll())
            {
                popUpHandle.Add(item);
            }
            cmb_PopUpArtNo.DataSource = popUpHandle;

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
        private void cmb_PopUpArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_PopUpArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
