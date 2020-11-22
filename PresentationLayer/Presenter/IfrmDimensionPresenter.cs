using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using System;
using static PresentationLayer.Presenter.frmDimensionPresenter;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        Show_Purpose purpose { get; set; }
        IfrmDimensionView GetDimensionView();
        void SetPresenters(IMainPresenter mainPresenter, IBasePlatformPresenter basePlatformPresenter);
        void SetProfileType(string profileType);
        void SetHeight();
    }
}