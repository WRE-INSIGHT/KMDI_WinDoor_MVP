using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IPanelPropertiesUC: IViewCommon
    {
        int Panel_ID { get; set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler ChkOrientationCheckChangedEventRaised;
        event EventHandler CmbGlassThickSelectedIndexChangedEventRaised;
        //event EventHandler PnumWidthValueChangedEventRaised;
        //event EventHandler PnumHeightValueChangedEventRaised;
    }
}