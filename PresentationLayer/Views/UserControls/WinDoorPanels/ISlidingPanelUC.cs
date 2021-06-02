using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ISlidingPanelUC: IViewCommon
    {
        event EventHandler deleteToolStripClickedEventRaised;
        event EventHandler slidingPanelUCMouseEnterEventRaised;
        event EventHandler slidingPanelUCMouseLeaveEventRaised;
        event PaintEventHandler slidingPanelUCPaintEventRaised;
        event EventHandler slidingPanelUCSizeChangedEventRaised;
    }
}