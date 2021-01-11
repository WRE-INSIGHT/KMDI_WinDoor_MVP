using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface ISlidingPanelImagerUC: IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        event PaintEventHandler slidingPanelImagerUCPaintEventRaised;

        void InvalidateThis();
    }
}