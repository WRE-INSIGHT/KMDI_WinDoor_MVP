using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_PriceIncreaseByPercentageUC
    {
        decimal Screen_PriceIncreaseByPercentage { get; set; }

        event EventHandler chkboxAdditionalPercentageCheckedChangedEventRaised;
        event EventHandler nudPercentageValueChangedEventRaised;
        event EventHandler SPPriceIncreaseByPercentageUCLoadEventRaised;
        NumericUpDown GetNudPriceIncrease();
        Panel GetPanelBody();
        CheckBox GetChkBoxPriceIncrease();
        UserControl GetPriceIncraeseUserControl();
        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}