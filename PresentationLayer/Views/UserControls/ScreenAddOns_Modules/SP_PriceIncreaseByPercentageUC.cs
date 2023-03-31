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

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_PriceIncreaseByPercentageUC : UserControl, ISP_PriceIncreaseByPercentageUC
    {

        public event EventHandler nudPercentageValueChangedEventRaised;
        public event EventHandler chkboxAdditionalPercentageCheckedChangedEventRaised;
        public event EventHandler SPPriceIncreaseByPercentageUCLoadEventRaised;

        public decimal Screen_PriceIncreaseByPercentage
        {
            get
            {
                return Convert.ToDecimal(nud_Percentage.Value);
            }
            set
            {
                nud_Percentage.Value = value;
            }
        }

        public UserControl GetPriceIncraeseUserControl()
        {
            return this;
        }
        public NumericUpDown GetNudPriceIncrease()
        {
            return nud_Percentage;
        }

        public CheckBox GetChkBoxPriceIncrease()
        {
            return chkbox_AdditionalPercentage;
        }

        public Panel GetPanelBody()
        {
            return pnl_body;
        }

        public SP_PriceIncreaseByPercentageUC()
        {
            InitializeComponent();
        }

        private void nud_Percentage_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudPercentageValueChangedEventRaised, e);
        }

        private void nud_Percentage_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudPercentageValueChangedEventRaised, e);
        }

        private void chkbox_AdditionalPercentage_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxAdditionalPercentageCheckedChangedEventRaised, e);
        }
        private void SP_PriceIncreaseByPercentageUC_Load(object sender, EventArgs e)
        {
            nud_Percentage.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, SPPriceIncreaseByPercentageUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string,Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_PriceIncreaseVisibility"]);
            chkbox_AdditionalPercentage.DataBindings.Add(ModelBinding["Screen_PriceIncreaseVisibilityOption"]);
            nud_Percentage.DataBindings.Add(ModelBinding["Screen_PriceIncreasePercentage"]);

        }

        
    }
}
