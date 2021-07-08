using CommonComponents;
using System;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls
{
    public interface IPanelPropertiesUC: IViewCommon
    {
        int Panel_ID { get; set; }
        int PanelGlass_ID { get; set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler ChkOrientationCheckChangedEventRaised;
        event EventHandler CmbGlazingArtNoSelectedValueChangedEventRaised;
        event EventHandler CmbFilmTypeSelectedValueChangedEventRaised;
        event EventHandler CmbSashProfileSelectedValueChangedEventRaised;
        event EventHandler CmbSashReinfSelectedValueChangedEventRaised;
        event EventHandler btnSelectGlassThicknessClickedEventRaised;
        event EventHandler CmbGlassTypeSelectedValueChangedEventRaised;
        event EventHandler CmbHandleTypeSelectedValueChangedEventRaised;
        event EventHandler CmbEspagnoletteSelectedValueChangedEventRaised;
        event EventHandler CmbMiddleCloserSelectedValueChangedEventRaised;
        event EventHandler CmbLockingKitSelectedValueChangedEventRaised;
        event EventHandler CmbRotoswingArtNoSelectedValueChangedEventRaised;
        event EventHandler CmbRotaryArtNoSelectedValueChangedEventRaised;
        event EventHandler ChkMotorizedCheckChangedEventRaised;
        event EventHandler CmbMotorizedMechSelectedValueChangedEventRaised;

        Panel GetPnlRotoswingOptions();
        Panel GetPnlRotaryOptions();
    }
}