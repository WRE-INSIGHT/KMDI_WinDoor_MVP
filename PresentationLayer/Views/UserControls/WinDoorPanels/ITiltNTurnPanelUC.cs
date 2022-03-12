using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ITiltNTurnPanelUC : IViewCommon
    {
        event EventHandler deleteToolStripClickedEventRaised;
        event EventHandler tiltNturnPanelUCMouseEnterEventRaised;
        event EventHandler tiltNturnPanelUCMouseLeaveEventRaised;
        event PaintEventHandler tiltNturnPanelUCPaintEventRaised;
        event EventHandler tiltNturnPanelUCSizeChangedEventRaised;
    }
}