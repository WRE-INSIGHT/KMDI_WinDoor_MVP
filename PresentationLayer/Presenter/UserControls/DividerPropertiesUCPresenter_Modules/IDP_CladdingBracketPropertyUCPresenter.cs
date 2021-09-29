using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public interface IDP_CladdingBracketPropertyUCPresenter : IPresenterCommon
    {
        IDP_CladdingBracketPropertyUC GetCladdingBracketPropertyUC();
        IDP_CladdingBracketPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel dividerModel);
        void BringToFrontUC();
    }
}
