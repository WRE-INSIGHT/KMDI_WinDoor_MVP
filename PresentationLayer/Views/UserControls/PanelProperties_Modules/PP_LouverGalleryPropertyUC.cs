﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverGalleryPropertyUC : UserControl, IPP_LouverGalleryPropertyUC
    {
        public PP_LouverGalleryPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler LouverBladesCombinationPropertyUCLoadEventRaised;
        public event EventHandler cmbBladeTypeSelectedValueChangedEventRaised;
        public event EventHandler chkSecurityGrillCheckedChangedEventRaised;
        public event EventHandler chkRingpullLeverHandleCheckedChangedEventRaised;

        private void PP_LouverBladesCombinationPropertyUC_Load(object sender, EventArgs e)
        {
            List<BladeType_Option> BladeType = new List<BladeType_Option>();
            foreach (BladeType_Option item in BladeType_Option.GetAll())
            {
                BladeType.Add(item);
            }
            cmb_BladeType.DataSource = BladeType;

            EventHelpers.RaiseEvent(sender, LouverBladesCombinationPropertyUCLoadEventRaised, e);
        }
        private void cmb_BladeType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbBladeTypeSelectedValueChangedEventRaised, e);
        }
        private void chk_SecurityGrill_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkSecurityGrillCheckedChangedEventRaised, e);
        }

        private void chk_RingpullLeverHandle_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkRingpullLeverHandleCheckedChangedEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_LouverGalleryVisibility"]);
            cmb_BladeType.DataBindings.Add(ModelBinding["Panel_LouverBladeTypeOption"]);
            chk_RingpullLeverHandle.DataBindings.Add(ModelBinding["Panel_LouverRPLeverHandleCheck"]);
            chk_SecurityGrill.DataBindings.Add(ModelBinding["Panel_LouverSecurityGrillCheck"]);
        }
        private void cmb_BladeType_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_BladeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
