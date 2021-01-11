using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface ICasementPanelImagerUC : IViewCommon
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        event PaintEventHandler casementPanelImagerUCPaintEventRaised;

        void InvalidateThis();
    }
}