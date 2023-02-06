using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface IAssignProjectsView
    {
        DataGridView DGV_Projects { get; }
        string SearchProjStr { get; }

        event EventHandler AssignProjectsViewLoadEventRaised;
        event EventHandler assignCostEngrToolStripMenuItemClickEventRaised;
        event EventHandler btnSearchProjClickEventRaised;
        event EventHandler customerRefNoToolStripMenuItemClickEventRaised;
        event EventHandler clearToolStripMenuItemClickEventRaised;
        event EventHandler deleteProjectToolStripMenuItemClickEventRaised;

        void ShowThis();
        void SetEnableThis(bool enabled);
    }
}