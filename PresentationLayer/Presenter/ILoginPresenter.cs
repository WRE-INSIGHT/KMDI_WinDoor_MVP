using PresentationLayer.Views;

namespace PresentationLayer.Presenter
{
    interface ILoginPresenter
    {
        ILoginView GetLoginView();
        void SetMainView(ILoginView loginView);
    }
}