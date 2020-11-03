using PresentationLayer.Views;
using System;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IMainView GetMainView();
        void OnMainViewLoadEventRaised(object sender, EventArgs e);
    }
}