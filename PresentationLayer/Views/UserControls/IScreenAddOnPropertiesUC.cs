using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IScreenAddOnPropertiesUC
    {
        event EventHandler btnAddMatsClickEventRaised;
        event EventHandler ScreenAddOnPropertiesUCLoadEventRaised;

        Panel GetPanelAddOns();
    }
}