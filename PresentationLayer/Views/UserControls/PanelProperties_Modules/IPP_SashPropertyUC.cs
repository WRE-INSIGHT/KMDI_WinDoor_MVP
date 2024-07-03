using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_SashPropertyUC : IViewCommon
    {
        string ProfileType_FromMainPresenter { get; set; }

        event EventHandler cmbSashProfileReinfSelectedValueEventRaised;
        event EventHandler cmbSashProfileSelectedValueEventRaised;
        event EventHandler PPSashPropertyLoadEventRaised;
    }
}