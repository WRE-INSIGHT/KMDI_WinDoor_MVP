using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_CladdingQtyPropertyUC : IViewCommon
    {
        event EventHandler CladdingQtyPropertyUCLoadEventRaised;
        event EventHandler nudCladdingQtyValueChangedEventRaised;
    }
}