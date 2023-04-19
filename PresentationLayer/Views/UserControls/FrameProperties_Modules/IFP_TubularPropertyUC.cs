using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_TubularPropertyUC : IViewCommon
    {
        event EventHandler chkTubularCheckedChangedEventRaised;
        event EventHandler FPTubularPropertyUCLoadEventRaised;
        event EventHandler nudTubularHeightValueChangedEventRaised;
        event EventHandler nudTubularWidthValueChangedEventRaised;
    }
}