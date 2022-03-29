using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICostEngrLandingView
    {
        DataGridView DGV_ASsignedProject { get; }
        DataGridView DGV_CustRefNo { get; }

        event EventHandler CostEngrLandingViewLoadEventRaised;
        event DataGridViewCellMouseEventHandler dgvAssignedProjectsCellMouseDoubleClickEventRaised;
        event EventHandler btnbackNavClickEventRaised;
        event EventHandler btnforwardNavClick;

        bool SetSelectedIndex_TabpageNav(int index);

        void ShowThis();
        void SetText_LblNav(string text);
    }
}