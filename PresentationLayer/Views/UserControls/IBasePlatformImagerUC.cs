using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IBasePlatformImagerUC : IViewCommon
    {
        event PaintEventHandler basePlatformPaintEventRaised;
        event PaintEventHandler flpFrameDragDropPaintEventRaised;
        void InvalidateThis();
        void ClearBinding(Control _basePlatfomrUC);
    }
}