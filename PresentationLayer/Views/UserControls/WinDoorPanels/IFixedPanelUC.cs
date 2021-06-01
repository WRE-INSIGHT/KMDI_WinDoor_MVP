using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC: IViewCommon
    {
        event EventHandler fixedPanelUCSizeChangedEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
        event PaintEventHandler fixedPanelUCPaintEventRaised;
        event EventHandler fixedPanelMouseEnterEventRaised;
        event EventHandler fixedPanelMouseLeaveEventRaised;

        int PanelGlass_ID { get; set; }
    }
}