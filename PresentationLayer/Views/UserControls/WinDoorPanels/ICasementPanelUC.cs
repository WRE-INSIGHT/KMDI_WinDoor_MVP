using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface ICasementPanelUC: IViewCommon
    {
        event EventHandler casementPanelUCSizeChangedEventRaised;
        event PaintEventHandler casementPanelUCPaintEventRaised;
    }
}