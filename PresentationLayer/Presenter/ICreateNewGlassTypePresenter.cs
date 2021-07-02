using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICreateNewGlassTypePresenter
    {
        void ShowCreateNewGlassTypeView();
        ICreateNewGlassTypePresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, DataTable glassTypeDT);
    }
}
