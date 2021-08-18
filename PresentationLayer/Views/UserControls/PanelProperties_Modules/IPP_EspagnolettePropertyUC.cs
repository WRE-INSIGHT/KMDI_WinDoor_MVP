using CommonComponents;
using System;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_EspagnolettePropertyUC : IViewCommon
    {
        FrameProfile_ArticleNo Frame_ArtNo { get; set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }
        event EventHandler cmbEspagnoletteSelectedValueEventRaised;
        event EventHandler PPEspagnolettePropertyLoadEventRaised;
    }
}