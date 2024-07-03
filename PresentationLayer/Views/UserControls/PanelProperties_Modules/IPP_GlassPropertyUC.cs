using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_GlassPropertyUC : IViewCommon
    {
        string ProfileType_FromMainPresenter { get; set; }

        event EventHandler btnSelectGlassThicknessClickedEventRaised;
        event EventHandler cmbFilmTypeSelectedValueEventRaised;
        event EventHandler cmbGlassTypeSelectedValueEventRaised;
        event EventHandler cmbGlazingArtNoSelectedValueEventRaised;
        event EventHandler PPGlassPropertyLoadEventRaised;
        event EventHandler chkGlazingAdaptorCheckedChangedEventRaised;
    }
}