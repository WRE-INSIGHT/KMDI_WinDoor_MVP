using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IMultiPanelMullionUC: IViewCommon
    {
        int MPanel_ID { get; set; }

        event PaintEventHandler flpMulltiPaintEventRaised;
        event DragEventHandler flpMultiDragDropEventRaised;
        event EventHandler flpMultiMouseEnterEventRaised;
        event EventHandler flpMultiMouseLeaveEventRaised;
        event EventHandler divCountClickedEventRaised;
        event EventHandler deleteClickedEventRaised;
        event EventHandler multiMullionSizeChangedEventRaised;

        void InvalidateFlp();
        void DeletePanel(UserControl panel);
        Bitmap GetPartImageThis(int height);
    }
}