using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IPanelPropertiesUC: IViewCommon
    {
        int Panel_ID { get; set; }
        int PanelGlass_ID { get; set; }
        bool SashPanel_Visibility { get; set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler ChkOrientationCheckChangedEventRaised;
        event EventHandler CmbGlazingArtNoSelectedValueChangedEventRaised;
        event EventHandler CmbFilmTypeSelectedValueChangedEventRaised;
        event EventHandler CmbSashProfileSelectedValueChangedEventRaised;
        event EventHandler CmbSashReinfSelectedValueChangedEventRaised;
        event EventHandler btnSelectGlassThicknessClickedEventRaised;
        event EventHandler CmbGlassTypeSelectedValueChangedEventRaised;
        event EventHandler CmbHandleTypeSelectedValueChangedEventRaised;

        ComboBox GetCmbHandleArtNo();
        Panel GetPnlRotoswingOptions();
        Panel GetPnlRotaryOptions();
    }
}