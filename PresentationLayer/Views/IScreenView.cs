using System;

namespace PresentationLayer.Views
{
    public interface IScreenView
    {
        decimal screen_factor { get; set; }
        int screen_height { get; set; }
        int screen_width { get; set; }

        event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        event EventHandler ScreenViewLoadEventRaised;
        event EventHandler nudWidthValueChangedEventRaised;
        event EventHandler nudHeightValueChangedEventRaised;
        event EventHandler nudFactorValueChangedEventRaised;
    }
}