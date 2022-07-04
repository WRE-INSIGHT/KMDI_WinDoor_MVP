using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ICasementPanelUC: IViewCommon
    {
        event EventHandler casementPanelUCSizeChangedEventRaised;
        event EventHandler casementPanelUCMouseEnterEventRaised;
        event EventHandler casementPanelUCMouseLeaveEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
        event PaintEventHandler casementPanelUCPaintEventRaised;
        event MouseEventHandler casementPanelUCMouseMoveEventRaised;
        event MouseEventHandler casementPanelUCMouseDownEventRaised;
        event MouseEventHandler casementPanelUCMouseUpEventRaised;
        event MouseEventHandler casementPanelUCMouseClickEventRaised;
        event EventHandler noRightToolStripClickedEventRaised;
        event EventHandler noLeftToolStripClickedEventRaised;
        event EventHandler noBothToolStripClickedEventRaised;
        event EventHandler fullToolStripClickedEventRaised;
    }
}