using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RotoswingPropertyUC : IViewCommon
    {
        event EventHandler PPRotoswingPropertyLoadEventRaised;
        event EventHandler cmbRotoswingNoSelectedValueEventRaised;

        Panel GetRotoswingOptionPNL();
    }
}