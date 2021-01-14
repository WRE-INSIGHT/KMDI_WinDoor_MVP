﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IAwningPanelUC: IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        event EventHandler awningPanelUCMouseEnterEventRaised;
        event EventHandler awningPanelUCMouseLeaveEventRaised;
        event PaintEventHandler awningPanelUCPaintEventRaised;
        event EventHandler awningPanelUCSizeChangedEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;

        void InvalidateThis();
    }
}