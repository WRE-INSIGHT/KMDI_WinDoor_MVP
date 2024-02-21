using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_MotorizedPropertyUC : UserControl, IPP_MotorizedPropertyUC
    {
        public PP_MotorizedPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPMotorizedPropertyUCLoadEventRaised;
        public event EventHandler chkMotorizedCheckedChangedEventRaised;
        public event EventHandler cmbMotorizedMechSelectedValueChangedEventRaised;
        public event EventHandler chkRemoteCheckedChangedEventRaised;
        public event EventHandler numSetQtyValueChangedEventRaised;
        public event EventHandler num2dHingeQtyValueChangedEventRaised;
        public event EventHandler numButtHingeQtyValueChangedEventRaised;

        private void PP_MotorizedPropertyUC_Load(object sender, EventArgs e)
        {
            num_SetQty.Maximum = decimal.MaxValue;
            num_2dHingeQty.Maximum = decimal.MaxValue;
            num_ButtHingeQty.Maximum = decimal.MaxValue;

            List<MotorizedMech_ArticleNo> motormech = new List<MotorizedMech_ArticleNo>();
            foreach (MotorizedMech_ArticleNo item in MotorizedMech_ArticleNo.GetAll())
            {
                motormech.Add(item);
            }
            cmb_MotorizedMechanism.DataSource = motormech;

            EventHelpers.RaiseEvent(this, PPMotorizedPropertyUCLoadEventRaised, e);
        }

        private void chk_Motorized_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkMotorizedCheckedChangedEventRaised, e);
        }

        private void cmb_MotorizedMechanism_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbMotorizedMechSelectedValueChangedEventRaised, e);
        }

        private void chk_Remote_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkRemoteCheckedChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            chk_Motorized.DataBindings.Add(ModelBinding["Panel_MotorizedOptionVisibility"]);
            pnl_motorizedOptions.DataBindings.Add(ModelBinding["Panel_MotorizedOptionVisibility2"]);
            cmb_MotorizedMechanism.DataBindings.Add(ModelBinding["Panel_MotorizedMechArtNo"]);
            num_SetQty.DataBindings.Add(ModelBinding["Panel_MotorizedMechSetQty"]);
            num_2dHingeQty.DataBindings.Add(ModelBinding["Panel_2DHingeQty"]);
            num_ButtHingeQty.DataBindings.Add(ModelBinding["Panel_ButtHingeQty"]);
            this.DataBindings.Add(ModelBinding["Panel_MotorizedPropertyHeight"]);
            pnl_2dHinge.DataBindings.Add(ModelBinding["Panel_2dHingeVisibility"]);
            pnl_ButtHinge.DataBindings.Add(ModelBinding["Panel_ButtHingeVisibility"]);
            chk_Remote.DataBindings.Add(ModelBinding["Panel_MotorizedMechRemoteOption"]);
        }
        private void cmb_MotorizedMechanism_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_MotorizedMechanism_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_SetQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void num_2dHingeQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void num_ButtHingeQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void num_SetQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numSetQtyValueChangedEventRaised, e);
        }

        private void num_SetQty_KeyUp(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numSetQtyValueChangedEventRaised, e);
        }

        private void num_2dHingeQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num2dHingeQtyValueChangedEventRaised, e);
        }

        private void num_2dHingeQty_KeyUp(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num2dHingeQtyValueChangedEventRaised, e);
        }

        private void num_ButtHingeQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numButtHingeQtyValueChangedEventRaised, e);
        }

        private void num_ButtHingeQty_KeyUp(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numButtHingeQtyValueChangedEventRaised, e);
        }
    }
}
