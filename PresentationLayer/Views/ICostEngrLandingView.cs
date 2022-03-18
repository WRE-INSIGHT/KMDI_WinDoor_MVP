using System;

namespace PresentationLayer.Views
{
    public interface ICostEngrLandingView
    {
        event EventHandler CostEngrLandingViewLoadEventRaised;

        void ShowThis();
    }
}