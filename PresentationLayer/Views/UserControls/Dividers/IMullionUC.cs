using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public interface IMullionUC: IViewCommon
    {
        int Mullion_Left { get; set; }
        int Div_ID { get; set; }
        event MouseEventHandler mullionUCMouseDownEventRaised;
        event MouseEventHandler mullionUCMouseMoveEventRaised;
        event MouseEventHandler mullionUCMouseUpEventRaised;
        event PaintEventHandler mullionUCPaintEventRaised;
    }
}