using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface ISlidingPanelImagerUC: IViewCommon
    {

        event PaintEventHandler slidingPanelImagerUCPaintEventRaised;
        event EventHandler slidingPanelImagerUCVisibleChangedEventRaised;

        void InvalidateThis();
    }
}