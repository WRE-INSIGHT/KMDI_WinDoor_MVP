using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface IAssignProjectsPresenter
    {
        IAssignProjectsPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter);
        void ShowThisView();
    }
}