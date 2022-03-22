using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface ICostEngrEmployeeView
    {
        CheckedListBox ChkList_CE { get; }

        event EventHandler CostEngrEmployeeViewLoadEventRaised;
        event EventHandler btnAcceptClickEventRaised;

        void ShowThis();
    }
}