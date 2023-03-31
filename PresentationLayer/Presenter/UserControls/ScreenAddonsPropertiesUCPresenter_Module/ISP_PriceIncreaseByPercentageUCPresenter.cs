using System.Collections.Generic;
using System.Windows.Forms;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;
using ModelLayer.Model.Quotation.Screen;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_PriceIncreaseByPercentageUCPresenter
    {
        Dictionary<string, Binding> CreateBindingDictionary();
        ISP_PriceIncreaseByPercentageUC GetISP_PriceIncreaseByPercentageUC();

        ISP_PriceIncreaseByPercentageUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                   IMainPresenter mainPresenter,
                                                                   IScreenModel screenModel,
                                                                   IScreenPresenter screenPresenter);
    }

}