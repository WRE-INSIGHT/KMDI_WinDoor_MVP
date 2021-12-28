using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IControlsUC
    {
        string CustomText { get; set; }
        int DivCount { get; set; }
        int Iteration { get; set; }
        event MouseEventHandler controlsUCMouseDownEventRaised;
        event EventHandler controlsUCLoadEventRaised;
        event EventHandler divcountToolStripMenuItemClickEventRaised;
        event EventHandler iterationToolStripMenuItemClickEventRaised;

        Panel GetWinDoorPanel();
    }
}