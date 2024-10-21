using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICostEngrLandingView
    {
        DataGridView DGV_ASsignedProject { get; }
        DataGridView DGV_CustRefNo { get; }
        DataGridView DGV_QuoteNo { get; }
        string SearchProject { get; set; }
        event EventHandler CostEngrLandingViewLoadEventRaised;
        event DataGridViewCellMouseEventHandler dgvAssignedProjectsCellMouseDoubleClickEventRaised;
        event DataGridViewCellMouseEventHandler dgvCustRefNoCellMouseDoubleClickEventRaised;
        event DataGridViewCellMouseEventHandler dgvQuoteNoCellMouseDoubleClickEventRaised;
        event EventHandler btnbackNavClickEventRaised;
        event EventHandler btnforwardNavClick;
        event EventHandler btnAddNewQuoteClickEventRaised;
        event EventHandler btnSearchProjClickClickEventRaised;
        event EventHandler CostEngrLandingView_FormClosingEventRaised;
        bool SetSelectedIndex_TabpageNav(int index);

        void ShowThis();
        void CloseThis();
        void SetText_LblNav(string text);
        void resizeForm(int formWidth, int formHeight);
    }
}