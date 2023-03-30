using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Views;
using ServiceLayer.Services.QuotationServices;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPresenter : IPresenterCommon
    {
        IScreenView GetScreenView();
        IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                           IMainPresenter mainPresenter,
                                           IScreenModel screenModel,
                                           IQuotationServices quotationServices);
       



        DataTable PopulateDgvScreen();
        DataRow CreateNewRow_ScreenDT();
        void GetCurrentAmount();
    }
}