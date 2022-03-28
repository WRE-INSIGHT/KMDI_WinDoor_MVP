using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICostEngrLandingView
    {
        DataGridView DGV_ASsignedProject { get; }

        event EventHandler CostEngrLandingViewLoadEventRaised;
        event DataGridViewCellMouseEventHandler dgvAssignedProjectsCellMouseDoubleClickEventRaised;

        void ShowThis();
        void SetText_LblNav(string text);
    }
}