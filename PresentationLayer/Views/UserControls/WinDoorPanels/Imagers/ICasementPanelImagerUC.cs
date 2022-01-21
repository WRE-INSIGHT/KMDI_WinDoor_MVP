using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface ICasementPanelImagerUC : IViewCommon
    {
        
        event PaintEventHandler casementPanelImagerUCPaintEventRaised;
        event EventHandler casementPanelImagerUCVisibleChangedEventRaised;

        void InvalidateThis();
    }
}