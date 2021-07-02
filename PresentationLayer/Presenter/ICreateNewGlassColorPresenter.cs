using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICreateNewGlassColorPresenter
    {
        ICreateNewGlassColorPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, DataTable colorDT);
        void ShowCreateNewGlassColorView();
    }
}
