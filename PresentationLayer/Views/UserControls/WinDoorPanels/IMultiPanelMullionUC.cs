using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IMultiPanelMullionUC: IViewCommon
    {
        int MPanel_ID { get; set; }

        event PaintEventHandler flpMulltiPaintEventRaised;
        event EventHandler flpMultiMouseEnterEventRaised;
        event EventHandler flpMultiMouseLeaveEventRaised;
        event EventHandler divCountClickedEventRaised;
        event EventHandler deleteClickedEventRaised;
        event DragEventHandler flpMultiDragDropEventRaised;

        void InvalidateFlp();
    }
}