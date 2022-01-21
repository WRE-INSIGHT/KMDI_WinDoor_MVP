using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IAwningPanelUC: IViewCommon
    {
        bool Panel_ExtensionOptionsVisibility { get; set;}

        event EventHandler awningPanelUCMouseEnterEventRaised;
        event EventHandler awningPanelUCMouseLeaveEventRaised;
        event PaintEventHandler awningPanelUCPaintEventRaised;
        event EventHandler deleteToolStripClickedEventRaised;
        event EventHandler extensionToolStripMenuItemClickedEventRaised;
        event EventHandler awningPanelUCSizeChangedEventRaised;
    }
}