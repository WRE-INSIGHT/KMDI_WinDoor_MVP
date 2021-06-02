using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IFixedPanelImagerUC: IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        event PaintEventHandler fixedPanelImagerUCPaintEventRaised;
        event EventHandler fixedPanelImagerUCVisibleChangedEventRaised;
    }
}