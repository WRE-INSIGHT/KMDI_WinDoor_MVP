using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_DHandlePropertyUC : IViewCommon
    {
        event EventHandler cmb_DArtNoSelectedValueChangedEventRaised;
        event EventHandler PPDHandlePropertyUCLoadEventRaised;
        string ProfileType_FromMainPresenter { get; set; }
    }
}