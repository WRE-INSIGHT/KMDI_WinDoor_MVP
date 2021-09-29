using CommonComponents;
using System;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_ExtensionPropertyUC : IViewCommon
    {
        string Panel_Type { get; set; }

        FrameProfile_ArticleNo Frame_ArtNo { get; set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }
        event EventHandler PPExtensionUCLoadEventRaised;
        event EventHandler chkToAddExtension2CheckedChangedEventRaised;
        event EventHandler cmbExtensionsSelectedValueChangedEventRaised;

        Panel GetTopExt2OptionPNL();
        Panel GetBotExt2OptionPNL();
        Panel GetLeftExt2OptionPNL();
        Panel GetRightExt2OptionPNL();
    }
}