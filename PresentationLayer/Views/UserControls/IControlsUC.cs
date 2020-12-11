using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IControlsUC
    {
        string CustomText { get; set; }
        event MouseEventHandler controlsUCMouseDownEventRaised;
        event EventHandler controlsUCLoadEventRaised;
        Panel GetWinDoorPanel();
    }
}