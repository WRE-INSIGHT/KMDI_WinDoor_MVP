using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_CenterProfilePropertyUC : IViewCommon
    {
        void AddHT_FormBody(int addht);
        Panel GetCenterProfileSelectedPanel();
        Button GetBtnSelectCenterProfilePanel();

        event EventHandler CenterProfileArtNoSelectedValueChangedEventRaised;
        event EventHandler CenterProfilePropertyUCLoadEventRaised;
        event EventHandler btnSelectCPPanelClickEventRiased;

        string ProfileType_FromMainPresenter { get; set; }

    }
}