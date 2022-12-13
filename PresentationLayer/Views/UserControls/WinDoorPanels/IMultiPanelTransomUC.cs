using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IMultiPanelTransomUC : IViewCommon
    {
        event PaintEventHandler flpMulltiPaintEventRaised;
        event DragEventHandler flpMultiDragDropEventRaised;
        event EventHandler flpMultiMouseEnterEventRaised;
        event EventHandler flpMultiMouseLeaveEventRaised;
        event EventHandler divCountClickedEventRaised;
        event EventHandler deleteClickedEventRaised;
        event EventHandler multiMullionSizeChangedEventRaised;
        event EventHandler dividerEnabledCheckedChangedEventRaised;
        event DragEventHandler flpMultiDragOverEventRaised;
        event MouseEventHandler multiTransomUCMouseClickEventRaised;
        FlowLayoutPanel Getflp();
    }
}