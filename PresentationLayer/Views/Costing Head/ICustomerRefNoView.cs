using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface ICustomerRefNoView
    {
        string CustomerReferenceNo { get; }
        CheckedListBox ChkList_CustRefNo { get; }
        Label Lbl_Status { get; }
        Panel Pnl_Status { get; }

        event EventHandler btnAcceptClickEventRaised;
        event EventHandler CustomerRefNoViewLoadEventRaised;
        event EventHandler btnAddCustRefClickEventRaised;
        event FormClosedEventHandler CustomerRefNoViewFormClosedEventRaised;

        void ShowThis();
        void CloseThis();
    }
}