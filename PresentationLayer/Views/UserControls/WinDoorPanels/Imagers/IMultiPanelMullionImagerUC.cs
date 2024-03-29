﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelMullionImagerUC: IViewCommon
    {
        event PaintEventHandler flpMulltiPaintEventRaised;
        event EventHandler flpMulltiVisibleChangedEventRaised;

        void AddImagerControl(UserControl userctrlObj);
        void DeleteImagerControl(UserControl userctrlObj);
    }
}