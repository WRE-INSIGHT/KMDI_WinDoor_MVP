using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IPanelPropertiesUC: IViewCommon
    {
        event EventHandler PanelPropertiesLoadEventRaised;
    }
}