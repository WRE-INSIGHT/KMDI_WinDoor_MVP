using System;

namespace PresentationLayer.Views
{
    public interface IMainView
    {
        event EventHandler MainViewLoadEventRaised;
        string Nickname { set; }
        void ShowMainView();
    }
}