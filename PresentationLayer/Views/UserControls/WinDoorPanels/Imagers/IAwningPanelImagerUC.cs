using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IAwningPanelImagerUC: IViewCommon
    {
        event PaintEventHandler awningPanelImagerUCPaintEventRaised;

        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }

        void InvalidateThis();
    }
}