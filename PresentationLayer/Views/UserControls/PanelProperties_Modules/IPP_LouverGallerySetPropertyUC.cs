using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_LouverGallerySetPropertyUC : IViewCommon
    {
        event EventHandler LouverGallerySetPropertyUCLoadEventRaised;
        event EventHandler btnAddLouverClickEventRaised;
        event EventHandler cmbBladeHeightSelectedValueChangedEventRaised;
        event EventHandler cmbHandleTypeSelectedValueChangedEventRaised;
        event EventHandler cmbHandleLocationSelectedValueChangedEventRaised;
        event EventHandler cmbGalleryColorSelectedValueChangedEventRaised;
        event EventHandler chkMotorizedCheckedChangedEventRaised;

        Panel GetPanelBody();
        ComboBox GetHandleLoc();
        ComboBox GetHandleType();
        ComboBox GetBladeHeight();
        ComboBox GetGalleryColor();
    }
}