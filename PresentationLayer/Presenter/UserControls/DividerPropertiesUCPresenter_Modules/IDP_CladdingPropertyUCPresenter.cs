using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public interface IDP_CladdingPropertyUCPresenter
    {
        IDP_CladdingPropertyUC GetCladdingPropertyUC();
        IDP_CladdingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel, IMainPresenter mainPresenter, IDividerPropertiesUCPresenter divPropUCP);
    }
}