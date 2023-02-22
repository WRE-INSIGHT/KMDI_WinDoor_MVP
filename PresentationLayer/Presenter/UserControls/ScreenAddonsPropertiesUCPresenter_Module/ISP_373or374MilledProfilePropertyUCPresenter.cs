using System.Collections.Generic;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_373or374MilledProfilePropertyUCPresenter
    {
        ISP_373or374MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, IScreenModel screenModel);
        ISP_373or374MilledProfilePropertyUC Get373or374MilledProfilePropertyUC();
    }
}