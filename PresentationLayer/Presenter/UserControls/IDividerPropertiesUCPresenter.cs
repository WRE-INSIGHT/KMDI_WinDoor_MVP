using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IDividerPropertiesUCPresenter
    {
        IDividerPropertiesUC GetDivProperties();
        IDividerPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel, IMainPresenter mainPresenter);
    }
}