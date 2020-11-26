using System;
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
        string Nickname { set; }
        string ofd_InitialDirectory { get; set; }
        string mainview_title { get; set; }
        bool ItemToolStripEnabled { get;  set; }
        bool CreateNewWindoorBtnEnabled { set; }
        void ShowMainView();
        Panel GetPanelMain();
        Panel GetPanelItems();
        Panel GetPanelPropertiesBody();
    }
}