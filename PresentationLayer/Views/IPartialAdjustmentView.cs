using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPartialAdjustmentView
    {
        event EventHandler _printToolStripBtnClickEventRaised;
        event EventHandler _partialAdjustmentViewLoadEventRaised;
        event EventHandler _btn_addItem_ClickEventRaised;
        event EventHandler _ItemPanelToolstripBtn_ClickEventRaised;
        event EventHandler _itemSortToolStrpBtn_ClickEventRaised;
        void ClosePartialAdjustmentView();
        Panel GetPanelBody();
        Panel GetPanelHeader();
        Label GetPrevItemLbl();
        Label GetCurrItemLbl();
        Panel GetItemListPnl();
        CheckedListBox GetItemListCheckListBox();
        void ShowPartialAdjusmentView();
        Form GetThis();
    }
}