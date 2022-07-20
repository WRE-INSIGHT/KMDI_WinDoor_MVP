using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ISetTopViewSlidingPanellingPresenter : IPresenterCommon
    {
        ISetTopViewSlidingPanellingView GetSetTopViewSlidingPanellingView();
        ISetTopViewSlidingPanellingPresenter CreateNewInstance(IUnityContainer unityC,
                                                                      IMainPresenter mainPresenter,
                                                                      IWindoorModel windoorModel);
    }
}