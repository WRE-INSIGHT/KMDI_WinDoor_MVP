using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public interface ITransomUC : IViewCommon
    {
        int Div_ID { get; set; }

        //event EventHandler deleteToolStripMenuItemClickedEventRaised;
        event MouseEventHandler transomUCMouseDownEventRaised;
        event EventHandler transomUCMouseEnterEventRaised;
        event EventHandler transomUCMouseLeaveEventRaised;
        event MouseEventHandler transomUCMouseMoveEventRaised;
        event MouseEventHandler transomUCMouseUpEventRaised;
        event PaintEventHandler transomUCPaintEventRaised;
        event EventHandler transomUCSizeChangedEventRaised;

        void InvalidateThis();
    }
}