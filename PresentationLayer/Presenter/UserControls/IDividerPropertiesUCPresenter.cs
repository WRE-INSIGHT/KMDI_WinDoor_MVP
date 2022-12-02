using System.Drawing;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls;
using Unity;
using PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IDividerPropertiesUCPresenter
    {
        int Cladding_Count { get; set; }

        IDividerPropertiesUC GetDivProperties();
        IDividerPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel, IMainPresenter mainPresenter);

        //IDP_LeverEspagnolettePropertyUCPresenter GetLeverEspagUCP();
        IDP_LeverEspagnolettePropertyUCPresenter GetLeverEspagUCP(IUnityContainer unityC, IDividerModel divModel);
        void SetSaveBtnColor(Color color);
        void Refresh_LblTotalCladdingLength();
        void Remove_CladdingUCP(IDP_CladdingPropertyUCPresenter claddUCP);
    }
}