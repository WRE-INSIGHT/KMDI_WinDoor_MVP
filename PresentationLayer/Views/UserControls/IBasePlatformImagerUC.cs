using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IBasePlatformImagerUC : IViewCommon
    {
        event EventHandler basePlatformSizeChangedEventRaised;
        event EventHandler BasePlatformImagerUCLoadEventRaised;
        event PaintEventHandler basePlatformPaintEventRaised;
        event PaintEventHandler flpFrameDragDropPaintEventRaised;
        void InvalidateThis();
        void ClearBinding(Control _basePlatfomrUC);
        FlowLayoutPanel GetFlpMain();
        void BringToFront_baseImager();
        void SendToBack_baseImager();
    }
}