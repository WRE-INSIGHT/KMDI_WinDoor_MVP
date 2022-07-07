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
        event MouseEventHandler slidingPanelUCMouseMoveEventRaised;
        event MouseEventHandler slidingPanelUCMouseDownEventRaised;
        event MouseEventHandler slidingPanelUCMouseUpEventRaised;
        event MouseEventHandler slidingPanelUCMouseClickEventRaised;
        event PaintEventHandler slidingPanelUCPaintEventRaised;
        event EventHandler slidingPanelUCSizeChangedEventRaised;
        event EventHandler rightToolStripClickedEventRaised;
        event EventHandler leftToolStripClickedEventRaised;
        event EventHandler bothToolStripClickedEventRaised;
        event EventHandler noneToolStripClickedEventRaised;
    }
}