using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_ExtensionUC : IViewCommon
    {
        event EventHandler PPExtensionUCLoadEventRaised;
        event EventHandler btnaddTopExt2ClickedEventRaised;
    }
}