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

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_MagnumScreenTypeUC : UserControl, ISP_MagnumScreenTypeUC
    {
        public event EventHandler reinforcedCheckBoxEventRaised;
        public event EventHandler magnumScreenTypeEventRaised;
        public event EventHandler magnumScreenTypeUCloadEventRaised;

        public CheckBox GetReinforcedCheckBox()
        {
            return reinforcedChkBx;
        }
        public SP_MagnumScreenTypeUC()
        {
            InitializeComponent();
        }
   
        private void SP_MagnumScreenTypeUC_Load(object sender, EventArgs e)
        {
            List<Magnum_ScreenType> _magnumScreen = new List<Magnum_ScreenType>();
            foreach(Magnum_ScreenType item in Magnum_ScreenType.GetAll())
            {
                _magnumScreen.Add(item);
            }
            magnumScreenTypeCmb.DataSource = _magnumScreen;

            EventHelpers.RaiseEvent(sender, magnumScreenTypeUCloadEventRaised, e);

        }     
        private void reinforcedChkBx_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, reinforcedCheckBoxEventRaised, e);
        }
  
        private void magnumScreenTypeCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, magnumScreenTypeEventRaised, e);

        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["SP_MagnumScreenType_Visibility"]);
            reinforcedChkBx.DataBindings.Add(ModelBinding["Reinforced"]);
            magnumScreenTypeCmb.DataBindings.Add(ModelBinding["Magnum_ScreenType"]);
        }
    }   
}
