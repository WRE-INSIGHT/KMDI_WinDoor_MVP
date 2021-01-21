using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public interface IMullionUC: IViewCommon
    {
        int Mullion_Left { get; set; }
        int Div_ID { get; set; }
        Point Mullion_Location { get; }
        event MouseEventHandler mullionUCMouseDownEventRaised;
        event MouseEventHandler mullionUCMouseMoveEventRaised;
        event MouseEventHandler mullionUCMouseUpEventRaised;
        event PaintEventHandler mullionUCPaintEventRaised;
        event EventHandler deleteToolStripMenuItemClickedEventRaised;
    }
}