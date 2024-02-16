using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_MiddleCloserPropertyUC : IViewCommon
    {
        event EventHandler MiddleCloserPropertyUCLoadEventRaised;
        event EventHandler CmbMiddleCLoserSelectedValueChangedEventRaised;
        event EventHandler MCPairQtyValueChangedEventRaised;
        event EventHandler MCPairQtyValueKeyPressEventRaised;

    }
}