using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IPanelUC
    {
        int Panel_ID { get; set; }
        bool pnl_Orientation { get; set; }
        string Panel_Placement { get; }

        void InvalidateThis();
    }
}
