using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public interface IMullionUC: IViewCommon
    {
        int Div_ID { get; set; }
        event MouseEventHandler mullionUCMouseDownEventRaised;
        event MouseEventHandler mullionUCMouseMoveEventRaised;
        event MouseEventHandler mullionUCMouseUpEventRaised;
        event MouseEventHandler mullionUCMouseDoubleClickedEventRaised;
        event PaintEventHandler mullionUCPaintEventRaised;
        //event EventHandler deleteToolStripMenuItemClickedEventRaised;
        event EventHandler mullionUCMouseEnterEventRaised;
        event EventHandler mullionUCMouseLeaveEventRaised;
        event EventHandler mullionUCSizeChangedEventRaised;
        event KeyEventHandler mullionUCKeyDownEventRaised;

        void InvalidateThis();
        void FocusOnThis();
    }
}