using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IMultiPanelUC
    {
        int MPanel_ID { get; set; }
        string MPanel_Placement { get; set; }
        bool MPanel_CmenuDeleteVisibility { get; set; }
        void DeletePanel(UserControl obj);
        void InvalidateFlp();
        ToolStripMenuItem GetDivEnabler();
    }
}
