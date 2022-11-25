using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC: IViewCommon
    {
        event EventHandler deleteToolStripClickedEventRaised;
        event PaintEventHandler fixedPanelUCPaintEventRaised;
        event EventHandler fixedPanelMouseEnterEventRaised;
        event EventHandler fixedPanelMouseLeaveEventRaised;
        event EventHandler fixedPanelSizeChangedEventRaised;
        event MouseEventHandler fixedPanelUCMouseMoveEventRaised;
        event MouseEventHandler fixedPanelUCMouseDownEventRaised;
        event MouseEventHandler fixedPanelUCMouseClickEventRaised;
        event MouseEventHandler fixedPanelUCMouseUpEventRaised;
        int PanelGlass_ID { get; set; }
        event EventHandler rightToolStripClickedEventRaised;
        event EventHandler leftToolStripClickedEventRaised;
        event EventHandler bothToolStripClickedEventRaised;
        event EventHandler noneToolStripClickedEventRaised;
        bool cmenuFxdOverlapSashVisibility { get; set; }
        ContextMenuStrip GetcmenuFxd();
    }
}