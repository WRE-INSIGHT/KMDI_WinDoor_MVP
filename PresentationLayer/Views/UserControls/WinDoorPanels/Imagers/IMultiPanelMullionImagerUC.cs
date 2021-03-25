using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelMullionImagerUC: IViewCommon
    {
        int MPanel_ID { get; set; }

        event PaintEventHandler flpMulltiPaintEventRaised;
    }
}