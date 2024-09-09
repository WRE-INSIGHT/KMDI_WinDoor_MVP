using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_RollerPropertyUC : UserControl, IPP_RollerPropertyUC
    {
        public PP_RollerPropertyUC()
        {
            InitializeComponent();
        }
        public string ProfileType_FromMainPresenter { get; set; }

        public event EventHandler PPRollerPropertyUCLoadEventRaised;
        public event EventHandler cmbRollerSelectedValueChangedEventRaised;


        private void PP_RollerPropertyUC_Load(object sender, EventArgs e)
        {
            List<RollersTypes> SlidingType = new List<RollersTypes>();
            foreach (RollersTypes item in RollersTypes.GetAll())
             {
                if (ProfileType_FromMainPresenter.Contains("Alutek"))
                {
                    if (item == RollersTypes._H176 ||
                        item == RollersTypes._H177 ||
                        item == RollersTypes._H178)
                    {
                        SlidingType.Add(item);
                    }
                }
                else
                {
                    if (item != RollersTypes._H176 &&
                        item != RollersTypes._H177 &&
                        item != RollersTypes._H178)
                    {
                        SlidingType.Add(item);
                    }
                } 
            }
            cmb_Roller.DataSource = SlidingType;

            EventHelpers.RaiseEvent(sender, PPRollerPropertyUCLoadEventRaised, e);
        }

        private void cmb_Roller_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRollerSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            cmb_Roller.DataBindings.Add(ModelBinding["Panel_RollersTypes"]);
            this.DataBindings.Add(ModelBinding["Panel_RollersTypesVisibility"]);

        }
        private void cmb_Roller_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_Roller_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
