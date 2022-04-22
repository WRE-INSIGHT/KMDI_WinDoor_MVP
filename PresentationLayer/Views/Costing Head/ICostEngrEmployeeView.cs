using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface ICostEngrEmployeeView
    {
        CheckedListBox ChkList_CE { get; }
        Panel Pnl_Status { get; }
        Label Lbl_Status { get; }

        event EventHandler CostEngrEmployeeViewLoadEventRaised;
        event EventHandler btnAcceptClickEventRaised;

        void ShowThis();
    }
}