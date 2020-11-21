using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using System;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        IfrmDimensionView GetDimensionView();
        void SetPresenters(IMainPresenter mainPresenter, IBasePlatformPresenter basePlatformPresenter);
    }
}