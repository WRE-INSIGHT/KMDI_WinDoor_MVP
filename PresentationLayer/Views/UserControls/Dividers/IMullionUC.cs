using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public interface IMullionUC
    {
        int Mullion_Left { get; set; }

        event MouseEventHandler mullionUCMouseDownEventRaised;
        event MouseEventHandler mullionUCMouseMoveEventRaised;
        event MouseEventHandler mullionUCMouseUpEventRaised;
        event PaintEventHandler mullionUCPaintEventRaised;
    }
}