using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IScreenAddOnPropertiesUCPresenter
    {
        IScreenAddOnPropertiesUC GetScreenAddOnPropertiesUCView();
        IScreenAddOnPropertiesUCPresenter GetNewInstance(IUnityContainer unityC,
                                                         IMainPresenter mainPresenter,
                                                         IScreenModel screenModel);
    }
}