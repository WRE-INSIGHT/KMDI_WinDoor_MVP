using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RollerPropertyUC : IViewCommon
    {

        string ProfileType_FromMainPresenter { get; set; }

        event EventHandler cmbRollerSelectedValueChangedEventRaised;
        event EventHandler PPRollerPropertyUCLoadEventRaised;
    }
}