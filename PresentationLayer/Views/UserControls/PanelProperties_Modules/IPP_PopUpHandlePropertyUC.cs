using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_PopUpHandlePropertyUC : IViewCommon
    {
        event EventHandler cmbPopUpArtNoSelectedValueChangedEventRaiased;
        event EventHandler PPPopUpHandlePropertyUCLoadEventRaiased;
    }
}