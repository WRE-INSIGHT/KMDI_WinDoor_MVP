﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_ExtensionPropertyUC : IViewCommon
    {
        event EventHandler PPExtensionUCLoadEventRaised;
        event EventHandler chkToAddExtension2CheckedChangedEventRaised;

        Panel GetTopExt2OptionPNL();
        Panel GetBotExt2OptionPNL();
        Panel GetLeftExt2OptionPNL();
        Panel GetRightExt2OptionPNL();
    }
}