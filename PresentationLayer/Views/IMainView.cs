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
        string Nickname { set; }
        string ofd_InitialDirectory { get; set; }
        void ShowMainView();
        Panel GetBasePlatform();
    }
}