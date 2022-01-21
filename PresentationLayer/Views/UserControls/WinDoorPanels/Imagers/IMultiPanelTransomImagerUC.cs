using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelTransomImagerUC : IViewCommon
    {
        event PaintEventHandler flpMulltiPaintEventRaised;
        event EventHandler flpMultiVisibleChangedEventRaised;

        void AddImagerControl(UserControl userctrlObj);
        void DeleteImagerControl(UserControl userctrlObj);
    }
}