﻿using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IMainView
    {
        event EventHandler MainViewLoadEventRaised;
        event EventHandler MainViewClosingEventRaised;
        event EventHandler OpenToolStripButtonClickEventRaised;
        event EventHandler NewFrameButtonClickEventRaised;
        event EventHandler NewQuotationMenuItemClickEventRaised;
        string Nickname { set; }
        string ofd_InitialDirectory { get; set; }
        string mainview_title { get; set; }
        int flp_base_Wd { get; set; }
        int flp_base_Ht { get; set; }
        bool flp_base_visibility { get; set; }
        void ShowMainView();
        Panel GetBasePlatform();
    }
}