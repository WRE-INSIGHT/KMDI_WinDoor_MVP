using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_BottomFramePropertyUC: IViewCommon
    {
        event EventHandler bottomFramePropertyLoadEventRaised;
        event EventHandler cmbbotFrameProfileSelectedValueChangedRaised;
    }
}