using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_ScreenPropertyUC : IViewCommon
    {
        event EventHandler FScreenPropertyUCLoadEventRaised;
        event EventHandler ScreenCheckedChangedEventRaised;
        //event EventHandler screenHeightOptionCheckedChangedEventRaised;
        event EventHandler nudScreenHeightValueChangedEventRaised;

    }
}