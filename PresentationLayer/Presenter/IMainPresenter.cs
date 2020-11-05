using PresentationLayer.Views;
using ModelLayer.Model.User;
using System;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IMainView GetMainView();
        void SetUserModel(IUserModel userModel);
        void OnMainViewLoadEventRaised(object sender, EventArgs e);
    }
}