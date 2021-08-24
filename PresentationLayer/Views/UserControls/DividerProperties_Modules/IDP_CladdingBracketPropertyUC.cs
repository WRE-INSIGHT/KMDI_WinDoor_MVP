using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public interface IDP_CladdingBracketPropertyUC : IViewCommon
    {
        event EventHandler CladdingBracketPropertyUCLoadEventRaised;
        event EventHandler nudBracketForConcreteValueChangedEventRaised;
        event EventHandler nudBracketForUPVCValueChangedEventRaised;
    }
}