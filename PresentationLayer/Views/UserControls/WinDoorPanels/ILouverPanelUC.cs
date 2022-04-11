using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ILouverPanelUC : IViewCommon
    {
        Color Panel_BackColor { get; }
        bool Panel_CmenuDeleteVisibility { get; set; }
        int Panel_ID { get; set; }
        string Panel_Placement { get; set; }

        event EventHandler deleteToolStripClickedEventRaised;
        event EventHandler louverPanelUCLoadEventRaised;
        event EventHandler louverPanelUCMouseEnterEventRaised;
        event EventHandler louverPanelUCMouseLeaveEventRaised;
        event PaintEventHandler louverPanelUCPaintEventRaised;
        event EventHandler louverPanelUCSizeChangedEventRaised;

        void InvalidateThis();
    }
}