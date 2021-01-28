using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IMultiPanelTransomUC : IViewCommon
    {
        int MPanel_ID { get; set; }

        event EventHandler deleteClickedEventRaised;
        event EventHandler divCountClickedEventRaised;
        event PaintEventHandler flpMulltiPaintEventRaised;
        event DragEventHandler flpMultiDragDropEventRaised;
        event EventHandler flpMultiMouseEnterEventRaised;
        event EventHandler flpMultiMouseLeaveEventRaised;

        void DeletePanel(UserControl panel);
        void InvalidateFlp();
        Bitmap GetPartImageThis(int height);
    }
}