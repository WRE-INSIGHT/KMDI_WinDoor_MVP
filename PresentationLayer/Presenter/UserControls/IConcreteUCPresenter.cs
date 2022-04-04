using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IConcreteUCPresenter
    {
        IConcreteUC GetConcreteUC();
        IConcreteUCPresenter GetNewInstance(IUnityContainer unityC, IConcreteModel concreteModel, IMainPresenter mainPresenter, IBasePlatformPresenter basePlatformUCP);
    }
}