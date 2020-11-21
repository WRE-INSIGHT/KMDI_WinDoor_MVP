using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.User;
using System;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView);
        void AddBasePlatform(IBasePlatformUC basePlatform);
    }
}