using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IConcretePropertiesUCPresenter
    {
        IConcretePropertiesUC GetConcretePropertiesUC();
        IConcretePropertiesUCPresenter GetNewInstance(IConcreteModel concreteModel, IUnityContainer unityC, IMainPresenter mainPresenter);
    }
}