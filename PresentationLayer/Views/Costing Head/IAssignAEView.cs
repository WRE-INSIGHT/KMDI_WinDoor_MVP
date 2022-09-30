using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface IAssignAEView
    {
        DataGridView DGV_Client { get; }
        DataGridView DGV_AEIC { get; }
        DataGridView DGV_Project { get; }
        string SearchClientStr { get; }
        string SearchAEICStr { get; }
        event EventHandler AssignAEViewLoadEventRaised;
        event EventHandler btnSearchProjClickEventRaised;
        event EventHandler btnSearchAEICClickEventRaised;
        event EventHandler btnSaveClickEventRaised;
        event EventHandler btnEqualClickEventRaised;
        event EventHandler DeleteToolStripButtonClickEventRaised;
        event EventHandler AddProjectToolStripButtonClickEventRaised;
        void ShowThis();
    }
}
