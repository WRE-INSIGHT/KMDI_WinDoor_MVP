using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IFixedPanelImagerUC: IViewCommon
    {
        int Panel_ID { get; set; }

        event PaintEventHandler lblFixedUCPaintEventRaised;
    }
}