using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface IFactorView
    {
        DataGridView DGV_Factor { get; }
        string SearchFactorStr { get; }
        event EventHandler FactorViewLoadEventRaised;
        event EventHandler EditToolStripMenuItemClickEventRaised;
        event EventHandler btnSearchClickEventRaised;
        void ShowThis();
    }
}
