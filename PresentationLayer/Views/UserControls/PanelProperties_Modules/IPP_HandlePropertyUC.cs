using CommonComponents;
using System;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_HandlePropertyUC : IViewCommon
    {
        FrameProfile_ArticleNo Frame_ArtNo { get; set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }
        string ProfileType_FromMainPresenter { get; set; }
        
        event EventHandler cmbHandleTypeSelectedValueEventRaised;
        event EventHandler PPHandlePropertyLoadEventRaised;

        Panel GetHandleTypePNL();
    }
}