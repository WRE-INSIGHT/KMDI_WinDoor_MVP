using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_CenterClosurePropertyUC : IViewCommon
    {
        event EventHandler chkBoxCenterClosureCheckedChangedEventRaised;
        event EventHandler SPCenterClosurePropertyUCLoadEventRaised;
        event EventHandler nud_LatchKitQty_ValueChangedEventRaised;
        event EventHandler nud_IntermediatePartQty_ValueChangedEventRaised;

        int Screen_LatchKitQty { get; set; }
        int Screen_IntermediatePartQty { get; set; }
        Panel GetPanelBody();



    }
}