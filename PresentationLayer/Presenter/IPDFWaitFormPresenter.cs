using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPDFWaitFormPresenter
    {
        IPDFWaitFormPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter);
        IPDFWaitFormView GetPDFWaitFormView();
    }
}