using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_InversionClipPropertyUC : IViewCommon
    {
        event EventHandler InversionClipCheckedChangedEventRaised;
        event EventHandler InversionClipPropertyUCLoadEventRaised;
    }
}
