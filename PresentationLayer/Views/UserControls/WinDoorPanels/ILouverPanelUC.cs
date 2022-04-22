using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ILouverPanelUC : IViewCommon
    {
        event EventHandler deleteToolStripClickedEventRaised;
        event EventHandler louverPanelUCLoadEventRaised;
        event EventHandler louverPanelUCMouseEnterEventRaised;
        event EventHandler louverPanelUCMouseLeaveEventRaised;
        event PaintEventHandler louverPanelUCPaintEventRaised;
        event EventHandler louverPanelUCSizeChangedEventRaised;
    }
}