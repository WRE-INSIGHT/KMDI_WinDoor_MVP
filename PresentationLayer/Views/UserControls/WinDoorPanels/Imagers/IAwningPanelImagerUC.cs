using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IAwningPanelImagerUC: IViewCommon
    {
        event PaintEventHandler awningPanelImagerUCPaintEventRaised;
        event EventHandler awningPanelImagerUCVisibleChangedEventRaised;

        int Panel_ID { get; set; }
        //bool pnl_Orientation { get; set; }

        void InvalidateThis();
    }
}