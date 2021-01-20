using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using System;
using static PresentationLayer.Presenter.frmDimensionPresenter;
using ModelLayer.Model.Quotation.Frame;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        Show_Purpose purpose { get; set; }
        string profileType_frmDimensionPresenter { get; set; }
        bool mainPresenter_qoutationInputBox_ClickedOK { get; set; }
        bool mainPresenter_newItem_ClickedOK { get; set; }
        bool mainPresenter_AddedFrame_ClickedOK { get; set; }
        IfrmDimensionView GetDimensionView();
        void SetPresenters(IMainPresenter mainPresenter);
        void SetPresenters(IMultiPanelMullionUCPresenter multiUCP);
        void SetProfileType(string profileType);
        void SetHeight();
        void SetValues(int numWD, int numHT);
        bool GetfrmResult();
    }
}