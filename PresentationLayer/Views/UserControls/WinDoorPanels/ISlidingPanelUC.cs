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
        event PaintEventHandler slidingPanelUCPaintEventRaised;
        event EventHandler slidingPanelUCSizeChangedEventRaised;
        event EventHandler noRightToolStripClickedEventRaised;
        event EventHandler noLeftToolStripClickedEventRaised;
        event EventHandler noBothToolStripClickedEventRaised;
        event EventHandler fullToolStripClickedEventRaised;
    }
}