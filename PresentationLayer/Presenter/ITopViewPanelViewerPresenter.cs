using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ITopViewPanelViewerPresenter : IPresenterCommon
    {

        ITopViewPanelViewer GetSetTopViewSlidingPanellingView();
        ITopViewPanelViewerPresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,                                                        
                                                        IWindoorModel windoorModel);
    }
}
