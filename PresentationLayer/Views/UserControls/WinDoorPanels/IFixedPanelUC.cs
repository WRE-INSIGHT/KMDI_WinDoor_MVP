using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC: IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        event EventHandler fixedPanelUCSizeChangedEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
        event PaintEventHandler fixedPanelUCPaintEventRaised;
        event EventHandler fixedPanelMouseEnterEventRaised;
        event EventHandler fixedPanelMouseLeaveEventRaised;

        void InvalidateThis();
    }
}