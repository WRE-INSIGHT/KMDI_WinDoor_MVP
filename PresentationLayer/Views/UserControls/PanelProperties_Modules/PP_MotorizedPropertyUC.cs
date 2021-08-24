using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;
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

        private void PP_MotorizedPropertyUC_Load(object sender, EventArgs e)
        {
            num_SetQty.Maximum = decimal.MaxValue;
            num_2dHingeQty.Maximum = decimal.MaxValue;

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

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            chk_Motorized.DataBindings.Add(ModelBinding["Panel_MotorizedOptionVisibility"]);
            pnl_motorizedOptions.DataBindings.Add(ModelBinding["Panel_MotorizedOptionVisibility2"]);
            cmb_MotorizedMechanism.DataBindings.Add(ModelBinding["Panel_MotorizedMechArtNo"]);
            num_SetQty.DataBindings.Add(ModelBinding["Panel_MotorizedMechSetQty"]);
            num_2dHingeQty.DataBindings.Add(ModelBinding["Panel_2DHingeQty"]);
            this.DataBindings.Add(ModelBinding["Panel_MotorizedPropertyHeight"]);
        }
    }
}
