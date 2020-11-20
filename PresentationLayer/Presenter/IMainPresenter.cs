using PresentationLayer.Views;
using ModelLayer.Model.User;
using System;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView);
        void SetValues_flpBase(int wd, int ht);
    }
}