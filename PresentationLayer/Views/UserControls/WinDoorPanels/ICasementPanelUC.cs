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
        event MouseEventHandler casementPanelUCMouseDoubleClickedEventRaised;
        event EventHandler rightToolStripClickedEventRaised;
        event EventHandler leftToolStripClickedEventRaised;
        event EventHandler bothToolStripClickedEventRaised;
        event EventHandler noneToolStripClickedEventRaised;
        event KeyEventHandler casementPanelUCKeyDownEventRaised;
        void FocusOnThis();
    }
}