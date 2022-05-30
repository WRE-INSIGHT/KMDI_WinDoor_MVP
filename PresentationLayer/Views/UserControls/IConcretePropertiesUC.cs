using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IConcretePropertiesUC : IViewCommon
    {
        int Concrete_ID { get; set; }

        event EventHandler ConcretePropertiesUCLoadEventRaised;
        event EventHandler numcHeightValueChangedEventRaised;
        event EventHandler numcWidthValueChangedEventRaised;

        void BringToFrontThis();
    }
}