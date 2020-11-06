using PresentationLayer.Views;
using ModelLayer.Model.User;
using System;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView);
        void OnMainViewLoadEventRaised(object sender, EventArgs e);
    }
}