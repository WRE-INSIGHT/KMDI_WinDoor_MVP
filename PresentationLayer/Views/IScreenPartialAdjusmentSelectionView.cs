using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IScreenPartialAdjusmentSelectionView
    {
        event EventHandler btn_addToList_ClickEventRaised;
        event EventHandler ScreenPartialAdjusmentSelectionView_LoadEventRaised;

        void ShowPartialAdjustmentSelectionView();
        void ClosePartialAdjustmentSelecionView();
        Button GetAddToListButton();
        CheckedListBox GetCheckListBox();
    }
}