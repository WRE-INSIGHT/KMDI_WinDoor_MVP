using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IConcretePropertiesUC
    {
        int FrameID { get; set; }

        event EventHandler ConcretePropertiesUCLoadEventRaised;
        event EventHandler numcHeightValueChangedEventRaised;
        event EventHandler numcWidthValueChangedEventRaised;

        void BringToFrontThis();
    }
}