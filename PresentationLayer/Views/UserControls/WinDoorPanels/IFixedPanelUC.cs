using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public interface IFixedPanelUC: IViewCommon
    {
        event EventHandler fixedPanelUCLoadEventRaised;
        DockStyle thisdock { set; }
    }
}