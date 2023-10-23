using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPartialAdjustmentView
    {
        event EventHandler _printToolStripBtnClickEventRaised;
        event EventHandler _partialAdjustmentViewLoadEventRaised;

        void ClosePartialAdjustmentView();
        Panel GetPanelBody();
        Panel GetPanelHeader();
        Label GetPrevItemLbl();
        Label GetCurrItemLbl();
        void ShowPartialAdjusmentView();
        Form GetThis();
    }
}