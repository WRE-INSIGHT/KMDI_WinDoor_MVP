using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_CenterClosurePropertyUC : IViewCommon
    {
        event EventHandler chkBoxCenterClosureCheckedChangedEventRaised;
        event EventHandler nudIntermediatePartQtyValueChangedEventRaised;
        event EventHandler nudIntermediatePartValueChangedEventRaised;
        event EventHandler SPCenterClosurePropertyUCLoadEventRaised;
        Panel GetPanelBody();

    }
}