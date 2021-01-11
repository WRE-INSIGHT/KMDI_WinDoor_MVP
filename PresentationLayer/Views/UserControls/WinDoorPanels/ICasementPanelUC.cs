using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ICasementPanelUC: IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }
        event EventHandler casementPanelUCSizeChangedEventRaised;
        event EventHandler casementPanelUCMouseEnterEventRaised;
        event EventHandler casementPanelUCMouseLeaveEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
        event PaintEventHandler casementPanelUCPaintEventRaised;
        void InvalidateThis();
    }
}