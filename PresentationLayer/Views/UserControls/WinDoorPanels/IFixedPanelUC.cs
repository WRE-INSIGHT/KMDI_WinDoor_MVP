using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC
    {
        event EventHandler fixedPanelUCLoadEventRaised;
        DockStyle thisdock { set; }
    }
}