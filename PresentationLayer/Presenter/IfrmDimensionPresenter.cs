using PresentationLayer.Views;
using System;

namespace PresentationLayer.Presenter
{
    public interface IfrmDimensionPresenter
    {
        IfrmDimensionView GetDimensionView();
        void SetValues(IMainPresenter mainPresenter);
    }
}