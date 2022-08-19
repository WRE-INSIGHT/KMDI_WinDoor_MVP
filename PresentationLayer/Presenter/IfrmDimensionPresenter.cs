using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views;
using static PresentationLayer.Presenter.frmDimensionPresenter;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        Show_Purpose purpose { get; set; }
        string profileType_frmDimensionPresenter { get; set; }
        string baseColor_frmDimensionPresenter { get; set; }
        bool mainPresenter_qoutationInputBox_ClickedOK { get; set; }
        bool mainPresenter_newItem_ClickedOK { get; set; }
        bool mainPresenter_AddedFrame_ClickedOK { get; set; }
        bool mainPresenter_AddedConcrete_ClickedOK { get; set; }

        IfrmDimensionView GetDimensionView();
        void SetPresenters(IMainPresenter mainPresenter);
        void SetPresenters(IMultiPanelMullionUCPresenter multiUCP);
        void SetPresenters(IMultiPanelTransomUCPresenter multiTransomUCP);
        void SetProfileType(string profileType);
        void SetBaseColor(string baseColor);
        void SetHeight();
        void SetValues(int numWD, int numHT);
        bool GetfrmResult();
    }
}