using System.Drawing;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls;
using Unity;
using PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IDividerPropertiesUCPresenter
    {
        IDividerPropertiesUC GetDivProperties();
        IDividerPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel, IMainPresenter mainPresenter);
        IDP_LeverEspagnolettePropertyUCPresenter GetLeverEspagUCP();
        void SetSaveBtnColor(Color color);
    }
}