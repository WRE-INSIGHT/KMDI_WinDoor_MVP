using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC: IViewCommon
    {
        int Panel_ID { get; set; }
        event EventHandler fixedPanelUCSizeChangedEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
    }
}