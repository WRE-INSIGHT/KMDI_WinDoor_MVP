using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IControlsUC
    {
        string CustomText { get; set; }
        Image CustomImage { get; set; }
        event MouseEventHandler controlsUCMouseDownEventRaised;
    }
}