﻿using System;
using System.Collections.Generic;
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
        event EventHandler PanelMainSizeChangedEventRaised;
        event EventHandler CreateNewItemClickEventRaised;
        event EventHandler LabelSizeClickEventRaised;
        string Nickname { set; }
        string mainview_title { get; set; }
        bool ItemToolStripEnabled { get;  set; }
        bool CreateNewWindoorBtnEnabled { get; set; }
        void ShowMainView();
        void ThisBinding(Dictionary<string, Binding> binding);
        void RemoveBinding(Control ctrl);
        Panel GetPanelMain();
        Panel GetPanelItems();
        Panel GetPanelPropertiesBody();
        Panel GetPanelBot();
        Panel GetPanelControlSub();
        Label GetLblSize();
        Form GetThis();
    }
}