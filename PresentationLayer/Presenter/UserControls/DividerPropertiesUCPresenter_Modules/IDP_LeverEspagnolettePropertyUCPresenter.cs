using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public interface IDP_LeverEspagnolettePropertyUCPresenter
    {
        IDP_LeverEspagnolettePropertyUC GetDPLeverEspagPropertyUC();
        IDP_LeverEspagnolettePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel);
        void BindSashProfileArtNo();
    }
}