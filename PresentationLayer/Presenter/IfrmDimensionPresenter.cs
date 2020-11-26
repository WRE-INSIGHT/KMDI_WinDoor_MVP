using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using System;
using static PresentationLayer.Presenter.frmDimensionPresenter;
using ModelLayer.Model.Quotation.Frame;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        Show_Purpose purpose { get; set; }
        string profileType_frmDimensionPresenter { get; set; }
        bool mainPresenter_qoutationInputBox_ClickedOK { get; set; }
        IfrmDimensionView GetDimensionView();
        void SetPresenters(IMainPresenter mainPresenter);
        void SetProfileType(string profileType);
        void SetHeight();
    }
}