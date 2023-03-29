using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IExchangeRatePresenter : IPresenterCommon
    {
        IExchangeRateView GetExchangeRateView();
        IExchangeRatePresenter CreateNewInstance(IUnityContainer unityC,
                                                 IMainPresenter mainPresenter,
                                                 IScreenModel screenModel,
                                                 IScreenPresenter screenPresenter);
    }
}