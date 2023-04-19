using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_LouverGalleryPropertyUC : IViewCommon
    {
        event EventHandler LouverBladesCombinationPropertyUCLoadEventRaised;
        event EventHandler cmbBladeTypeSelectedValueChangedEventRaised;
        event EventHandler chkSecurityGrillCheckedChangedEventRaised;
        event EventHandler chkRingpullLeverHandleCheckedChangedEventRaised;
    }
}